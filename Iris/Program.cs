// <copyright file="Program.cs" company="BigMiao">
// Copyright (c) BigMiao. All rights reserved.
// </copyright>

using Microsoft.ML;
using Microsoft.ML.Data;
using MLNet.AutoPipeline;
using System;
using System.Threading.Tasks;

namespace Iris
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var context = new MLContext();
            var dataset = context.Data.LoadFromTextFile<Iris>(@".\iris.csv", separatorChar: ',', hasHeader: true);
            var split = context.Data.TrainTestSplit(dataset, 0.3);

            var estimatorChain = context.Transforms.Conversion.MapValueToKey("species", "species")
                          .Append(context.Transforms.Concatenate("features", new string[] { "sepal_length" }))
                          .Append(context.AutoML().MultiClassification.LbfgsMaximumEntropy("species", "features"));

            var experimentOption = new Experiment.Option()
            {
                EvaluateFunction = (MLContext context, IDataView data) =>
                {
                    return context.MulticlassClassification.Evaluate(data, "species").MicroAccuracy;
                }
            };

            var experiment = context.AutoML().CreateExperiment(estimatorChain, experimentOption);
            var reporter = new Reporter();
            var result = await experiment.TrainAsync(split.TrainSet, validateFraction: 0.1f, reporter: reporter);
            var bestModel = result.BestModel;

            // evaluate on test
            var eval = bestModel.Transform(split.TestSet);
            var metric = context.MulticlassClassification.Evaluate(eval, "species");
            Console.WriteLine($"best model validate score: {result.BestIteration.EvaluateScore}");
            Console.WriteLine($"best model test score: {metric.MicroAccuracy}");
        }

        private class Iris
        {
            [LoadColumn(0)]
            public float sepal_length;

            [LoadColumn(1)]
            public float sepal_width;

            [LoadColumn(2)]
            public float petal_length;

            [LoadColumn(3)]
            public float petal_width;

            [LoadColumn(4)]
            public string species;
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
