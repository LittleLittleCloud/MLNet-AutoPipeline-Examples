// <copyright file="Program.cs" company="BigMiao">
// Copyright (c) BigMiao. All rights reserved.
// </copyright>

using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Trainers.Recommender;
using MLNet.AutoPipeline;
using MLNet.Sweeper;
using System;
using static Microsoft.ML.Trainers.MatrixFactorizationTrainer;

namespace Movie_Recommendation
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MLContext();
            var paramaters = new MFOption();
            var train_data = context.Data.LoadFromTextFile<ModelInput>(@".\recommendation-ratings-train.csv", separatorChar: ',', hasHeader: true);
            var test_data = context.Data.LoadFromTextFile<ModelInput>(@".\recommendation-ratings-test.csv", separatorChar: ',', hasHeader: true);

            var gpSweeper = new GaussProcessSweeper(new GaussProcessSweeper.Option() { InitialPopulation = 50 });
            var pipeline = context.Transforms.Conversion.MapValueToKey("userId", "userId")
                           .Append(context.Transforms.Conversion.MapValueToKey("movieId", "movieId"))
                           .Append(context.AutoML().CreateSweepableEstimator(
                               (context, option) =>
                               {
                                   return context.Recommendation().Trainers.MatrixFactorization(option);
                               },
                               MFOption.Default,
                               new string[] {"userId", "movieId"},
                               new string[] {"Score"},
                               nameof(MatrixFactorizationTrainer)))
                           .Append(context.Transforms.CopyColumns("output", "Score"));

            Console.WriteLine(pipeline.Summary());

            var experimentOption = new Experiment.Option()
            {
                ParameterSweeper = gpSweeper,
                ParameterSweeperIteration = 100,
                EvaluateFunction = (MLContext context, IDataView data) =>
                {
                    return context.Recommendation().Evaluate(data, "rating").RootMeanSquaredError;
                },
                IsMaximizing = false
            };

            var experiment = context.AutoML().CreateExperiment(pipeline, experimentOption);
            var result = experiment.TrainAsync(train_data, validateFraction: 0.1f, new Reporter()).Result;
            var bestModel = result.BestModel;

            // evaluate on test
            var eval = bestModel.Transform(test_data);
            var rmse = context.Recommendation().Evaluate(eval, "rating").RootMeanSquaredError;
            Console.WriteLine($"best model validate score: {result.BestIteration.EvaluateScore}");
            Console.WriteLine($"best model test score: {rmse}");
        }

        private class MFOption : SweepableOption<MatrixFactorizationTrainer.Options>
        {
            public static MFOption Default = new MFOption();

            [Parameter]
            public Parameter<string> MatrixColumnIndexColumnName = CreateFromSingleValue("userId");

            [Parameter]
            public Parameter<string> MatrixRowIndexColumnName = CreateFromSingleValue("movieId");

            [Parameter]
            public Parameter<string> LabelColumnName = CreateFromSingleValue("rating");

            [Parameter]
            public Parameter<bool> Quiet = CreateFromSingleValue(true);

            [Parameter]
            public Parameter<int> NumberOfIterations = CreateInt32Parameter(10, 1000);

            [Parameter]
            public Parameter<float> C = CreateFloatParameter(1E-5f, 1E-1f);

            [Parameter]
            public Parameter<float> Alpha = CreateFloatParameter(1E-5f, 1f);

            [Parameter]
            public Parameter<int> ApproximationRank = CreateInt32Parameter(128, 512);

            [Parameter]
            public Parameter<double> Lambda = CreateDoubleParameter(0.01, 10);

            [Parameter]
            public Parameter<double> LearningRate = CreateDoubleParameter(1E-5, 1E-1);
        }

        private class ModelInput
        {
            [ColumnName("userId"), LoadColumn(0)]
            public float UserId { get; set; }

            [ColumnName("movieId"), LoadColumn(1)]
            public float MovieId { get; set; }

            [ColumnName("rating"), LoadColumn(2)]
            public float Rating { get; set; }
        }

        private class Reporter : IProgress<IterationInfo>
        {
            public void Report(IterationInfo value)
            {
                Console.WriteLine(value.Parameters);
                Console.WriteLine($"validate score: {value.EvaluateScore}");
                Console.WriteLine($"training time: {value.TrainingTime}");
            }
        }
    }
}
