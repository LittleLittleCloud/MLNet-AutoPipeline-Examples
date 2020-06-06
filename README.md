# ML.Net AutoPipeline Samples
[ML.NET](https://www.microsoft.com/net/learn/apps/machine-learning-and-ai/ml-dotnet) is a cross-platform open-source machine learning framework that makes machine learning accessible to .NET developers.

[`ML.Net AutoPipeline`](https://github.com/LittleLittleCloud/machinelearning-auto-pipeline) is a set of packages build on top of ML.Net that provide AutoML feature. 

In this GitHub repo, we provide samples which will help you get started with `ML.Net AutoPipeline`.

# What's ML.Net AutoPipeline
[`ML.Net AutoPipeline`](https://github.com/LittleLittleCloud/machinelearning-auto-pipeline) is a set of libraries build on top of ML.Net that provides AutoML feature. In short, it is aimed to solve the two following problems that vastly exists in Machinelearning:
- Given a MLNet pipeline, find the best hyper-parameters for its transformers or trainers.
- Given a dataset and a ML task, find the best pipeline for solving this task.

[`ML.Net AutoPipeline`](https://github.com/LittleLittleCloud/machinelearning-auto-pipeline) solves the first problem by sweepable pipeline, which sweeps over a pre-defined hyper-parameter set and finds the best candidate. And it solves the second problem by `MLNet.Expert`, which automatically construct sweepable pipelines based on dataset and tasks. `ML.Net AutoPipeline` contains four libraries:
-  [MLNet.AutoPipeline](https://littlelittlecloud.github.io/machinelearning-auto-pipeline-site/api/MLNet.AutoPipeline.html): Provides API for creating sweepable MLNet pipelines. 
- [MLNet.Sweeper](https://littlelittlecloud.github.io/machinelearning-auto-pipeline-site/api/MLNet.Sweeper.html): Provides different sweepers which can be used to optimize hyper-parameter in `MLNet.AutoPipeline`. Right now the available sweepers are [UniformRandomSweeper](https://littlelittlecloud.github.io/machinelearning-auto-pipeline-site/api/MLNet.Sweeper.UniformRandomSweeper.html), [RandomGridSweeper](https://littlelittlecloud.github.io/machinelearning-auto-pipeline-site/api/MLNet.Sweeper.RandomGridSweeper.html) and [GaussProcessSweeper](https://littlelittlecloud.github.io/machinelearning-auto-pipeline-site/api/MLNet.Sweeper.GaussProcessSweeper.html).
- [MLNet.Expert](https://littlelittlecloud.github.io/machinelearning-auto-pipeline-site/api/MLNet.Expert.html): (coming soon) An AutoML library build on top of `MLNet.AutoPipeline`. It's your best choice if you don't want to define pipeline yourself but want to rely on the power of AutoML. As what it name says, it's your MLNet expert.
- [MLNet.CodeGenerator](https://littlelittlecloud.github.io/machinelearning-auto-pipeline-site/api/MLNet.CodeGenerator.html): (coming soon) Provides API for generating C# code for creating ML.Net pipeline.

# Examples

<table align="middle" width=100%>  
  <tr>
    <td align="middle" colspan="3">Classification</td>
  </tr>
  <tr>
    <td align="middle"><img src="images/sentiment-analysis.png" alt="Binary classification chart"><br><b>Sentiment Analysis<br></b></td>
    <td align="middle"><img src="images/flower-classification.png" alt="Movie Recommender chart"><br><b>Iris Flowers Classification <br></b></td>
    <td align="middle"></td>
  </tr> 
    <td></td>
  </tr> 
  <tr>
    <td align="middle" colspan="3">Recommendation</td>
  </tr>
  <tr>
    <td align="middle"><img src="images/movie-recommendation.png" alt="Movie Recommender chart" ><br><b>Movie Recommender <br>(Matrix Factorization)<br></b></td>
    <td></td>
    <td></td>
  </tr>
</table>


# Learn more

See [ML.NET Guide](https://docs.microsoft.com/en-us/dotnet/machine-learning/) for detailed information on tutorials, ML basics, etc.

See [MLNet Autopipeline project wesite](https://littlelittlecloud.github.io/machinelearning-auto-pipeline-site/index.html) for docs and articles.

  

