// <copyright file="Program.cs" company="BigMiao">
// Copyright (c) BigMiao. All rights reserved.
// </copyright>

using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms.Text;
using MLNet.AutoPipeline;
using MLNet.Sweeper;
using System;
using System.Collections.Generic;

namespace MLNet.Examples.SentimentAnalysis
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new MLContext();
            context.Log += Context_Log;

            // Load Data
            var trainDataset = context.Data.LoadFromTextFile<ModelInput>(@".\datasets\wikipedia-detox-250-line-data-train.tsv", hasHeader: true);
            var testDataset = context.Data.LoadFromTextFile<ModelInput>(@".\datasets\wikipedia-detox-250-line-test.tsv", hasHeader: true);

            var normalizeTextOption = new NormalizeTextOption();
            var applyWordEmbeddingOption = new ApplyWordEmbeddingOption();

            // Create pipeline
            var pipeline = context.Transforms.Conversion.MapValueToKey("Sentiment-key", "Sentiment")
                           .Append(context.AutoML().SweepableTrainer(
                               // Create NormalizeText transformer and sweep over it.
                               (context, option) =>
                               {
                                   return context.Transforms.Text.NormalizeText(
                                       option.OutputColumnName,
                                       option.InputColumnName,
                                       option.CaseMode,
                                       option.KeepDiacritics,
                                       option.KeepPunctuations,
                                       option.KeepNumbers);
                               },
                               normalizeTextOption,
                               new string[] { "SentimentText" },
                               new string[] { "txt" },
                               nameof(TextNormalizingEstimator)))
                           .Append(context.Transforms.Text.TokenizeIntoWords("txt", "txt"))
                           .Append(context.Transforms.Text.RemoveDefaultStopWords("txt", "txt"))
                           .Append(context.AutoML().SweepableTrainer(
                               // Create ApplyWordEmbedding transformer and sweep over it
                               (context, option) =>
                               {
                                   return context.Transforms.Text.ApplyWordEmbedding(
                                       option.outputColumnName,
                                       option.inputColumnName,
                                       option.ModelKind);
                               },
                               applyWordEmbeddingOption,
                               new string[] { "txt" },
                               new string[] { "txt" },
                               nameof(WordEmbeddingEstimator)))
                           .Append(
                                   // use SdcaLogisticRegression and FastForest as trainer
                                   context.AutoML().BinaryClassification.SdcaLogisticRegression("Sentiment", "txt"),
                                   context.AutoML().BinaryClassification.FastForest("Sentiment", "txt"));

            var experimentOption = new Experiment.Option()
            {
                EvaluateFunction = (MLContext context, IDataView data) =>
                {
                    return context.BinaryClassification.EvaluateNonCalibrated(data, "Sentiment").Accuracy;
                },
                MaximumTrainingTime = 60 * 60,
                ParameterSweeperIteration = 100,
            };

            var experiment = context.AutoML().CreateExperiment(pipeline, experimentOption);
            var result = experiment.TrainAsync(trainDataset, 0.1f, new Reporter()).Result;

            // evaluate on test
            var eval = result.BestModel.Transform(testDataset);
            var metric = context.BinaryClassification.EvaluateNonCalibrated(eval, "Sentiment");
            Console.WriteLine($"best model validate score: {result.BestIteration.EvaluateScore}");
            Console.WriteLine($"best model test score: {metric.Accuracy}");
        }

        private static void Context_Log(object sender, LoggingEventArgs e)
        {
            if (e.Source == "AutoPipeline")
            {
                Console.WriteLine(e.Message);
            }
        }

        public class NormalizeTextOption : SweepableOption<NormalizeTextOption>
        {
            public string OutputColumnName = "txt";

            public string InputColumnName = "SentimentText";

            public TextNormalizingEstimator.CaseMode CaseMode;

            [Parameter(nameof(CaseMode))]
            public Parameter<TextNormalizingEstimator.CaseMode> CaseModeSweeper = CreateDiscreteParameter(TextNormalizingEstimator.CaseMode.Lower, TextNormalizingEstimator.CaseMode.None, TextNormalizingEstimator.CaseMode.Upper);

            public bool KeepDiacritics;

            [Parameter(nameof(KeepDiacritics))]
            public Parameter<bool> KeepDiacriticsSweeper = CreateDiscreteParameter(true, false);

            public bool KeepPunctuations;

            [Parameter(nameof(KeepPunctuations))]
            public Parameter<bool> KeepPunctuationsSweeper = CreateDiscreteParameter(true, false);


            public bool KeepNumbers;

            [Parameter(nameof(KeepNumbers))]
            public Parameter<bool> keepNumbers = CreateDiscreteParameter(true, false);
        }

        public class ApplyWordEmbeddingOption : SweepableOption<ApplyWordEmbeddingOption>
        {
            public string outputColumnName = "txt";

            public string inputColumnName = "txt";

            public WordEmbeddingEstimator.PretrainedModelKind ModelKind;

            [Parameter(nameof(ModelKind))]
            public Parameter<WordEmbeddingEstimator.PretrainedModelKind> ModelKindSweeper = CreateDiscreteParameter(WordEmbeddingEstimator.PretrainedModelKind.FastTextWikipedia300D,
                                                                                                                WordEmbeddingEstimator.PretrainedModelKind.GloVe300D,
                                                                                                                WordEmbeddingEstimator.PretrainedModelKind.GloVeTwitter100D,
                                                                                                                WordEmbeddingEstimator.PretrainedModelKind.SentimentSpecificWordEmbedding);
        }

        private class Reporter : IProgress<IterationInfo>
        {
            public void Report(IterationInfo value)
            {
                Console.WriteLine(value.ParameterSet);
                Console.WriteLine($"validate score: {value.EvaluateScore}");
                Console.WriteLine($"training time: {value.TrainingTime}");
            }
        }
    }
}
