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
    <td align="middle" colspan="3">Binary classification</td>
  </tr>
  <tr>
    <td align="middle"><img src="images/sentiment-analysis.png" alt="Binary classification chart"><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>Sentiment Analysis<br><a href="samples/csharp/getting-started/BinaryClassification_SentimentAnalysis">C#</a> &nbsp; &nbsp; <a href="samples/fsharp/getting-started/BinaryClassification_SentimentAnalysis">F#</a></b></td>
    <td align="middle"><img src="images/spam-detection.png" alt="Movie Recommender chart"><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>Spam Detection<br><a href="samples/csharp/getting-started/BinaryClassification_SpamDetection">C#</a> &nbsp; &nbsp; <a href="samples/fsharp/getting-started/BinaryClassification_SpamDetection">F#</a></b></td>
    <td align="middle"><img src="images/anomaly-detection.png" alt="Power Anomaly detection chart"><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>Credit Card Fraud Detection<br>(Binary Classification)<br><a href="samples/csharp/getting-started/BinaryClassification_CreditCardFraudDetection">C#</a> &nbsp;&nbsp;&nbsp;<a href="samples/fsharp/getting-started/BinaryClassification_CreditCardFraudDetection">F#</a></b></td>
  </tr> 
  <tr>
    <td align="middle"><img src="images/disease-detection.png" alt="disease detection chart"><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>Heart Disease Prediction <br><a href="samples/csharp/getting-started/BinaryClassification_HeartDiseaseDetection">C#</a></td>
    <td></td>
    <td></td>
  </tr> 
  <tr>
    <td align="middle" colspan="3">Multi-class classification</td>
  </tr>
  <tr>
    <td align="middle"><img src="images/issue-labeler.png" alt="Issue Labeler chart"><br><img src="images/app-type-e2e-black.png" alt="End-to-end app icon"><br><b>Issues Classification  <br> <a href="samples/csharp/end-to-end-apps/MulticlassClassification-GitHubLabeler">C#</a>&nbsp;&nbsp;<a href="samples/fsharp/end-to-end-apps/MulticlassClassification-GitHubLabeler">F#</a></b></td>
    <td align="middle"><img src="images/flower-classification.png" alt="Movie Recommender chart"><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>Iris Flowers Classification <br><a href="samples/csharp/getting-started/MulticlassClassification_Iris">C#</a> &nbsp; &nbsp;<a href="samples/fsharp/getting-started/MulticlassClassification_Iris">F#</a></b></td>
    <td align="middle"><img src="images/handwriting-classification.png" alt="Movie Recommender chart"><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>MNIST<br><a href="samples/csharp/getting-started/MulticlassClassification_MNIST">C#</a></b></td>
  </tr>
  <tr>
    <td align="middle" colspan="3">Recommendation</td>
  </tr>
  <tr>
    <td align="middle"><img src="images/product-recommendation.png" alt="Product Recommender chart"><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>Product Recommendation<br><a href="samples/csharp/getting-started/MatrixFactorization_ProductRecommendation">C#</a></h4></td>
    <td align="middle"><img src="images/movie-recommendation.png" alt="Movie Recommender chart" ><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>Movie Recommender <br>(Matrix Factorization)<b><br><a href="samples/csharp/getting-started/MatrixFactorization_MovieRecommendation">C#</a></b></td>
    <td align="middle"><img src="images/movie-recommendation.png" alt="Movie Recommender chart"><br><img src="images/app-type-e2e-black.png" alt="End-to-end app icon"><br><b>Movie Recommender <br>(Field Aware Factorization Machines)<br><a href="samples/csharp/end-to-end-apps/Recommendation-MovieRecommender">C#</a></b></td>
  </tr>
  <tr>
    <td align="middle" colspan="3">Regression</td>
  </tr>
  <tr>
    <td align="middle"><img src="images/price-prediction.png" alt="Price Prediction chart"><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>Price Prediction<br><a href="samples/csharp/getting-started/Regression_TaxiFarePrediction">C#</a> &nbsp; &nbsp; <a href="samples/fsharp/getting-started/Regression_TaxiFarePrediction">F#</a></b></td>
    <td align="middle"><br><img src="images/sales-forcasting.png" alt="Sales ForeCasting chart"><br><img src="images/app-type-e2e-black.png" alt="End-to-end app icon"><br><b>Sales Forecasting (Regression)<br><a href="samples/csharp/end-to-end-apps/Forecasting-Sales">C#</a><br><br></b></td>
    <td align="middle"><img src="images/demand-prediction.png" alt="Demand Prediction chart"><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>Demand Prediction<br><a href="samples/csharp/getting-started/Regression_BikeSharingDemand">C#</a> &nbsp;&nbsp;&nbsp;<a href="samples/fsharp/getting-started/Regression_BikeSharingDemand">F#</a></b></td>
  </tr>
  <tr>
    <td align="middle" colspan="3">Time Series Forecasting</td>
  </tr>
  <tr>
    <td align="middle"><br><img src="images/sales-forcasting.png" alt="Sales ForeCasting chart"><br><img src="images/app-type-e2e-black.png" alt="End-to-end app icon"><br><b>Sales Forecasting (Time Series)<br><a href="samples/csharp/end-to-end-apps/Forecasting-Sales">C#</a><br><br></b></td>
    <td></td>
    <td></td>
  </tr>
  <tr>
    <td align="middle" colspan="3">Anomaly Detection</td>
  </tr>
  <tr>
    <td align="middle"><img src="images/spike-detection.png" alt="Spike detection chart"><br><br><b>Sales Spike Detection<br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon">&nbsp;<a href="samples/csharp/getting-started/AnomalyDetection_Sales">C#</a>&nbsp&nbsp;&nbsp;&nbsp;&nbsp;
      <img src="images/app-type-e2e-black.png" alt="End-to-end app icon">&nbsp;<a href="samples/csharp/end-to-end-apps/AnomalyDetection-Sales">C#</a><b></td>
    <td align="middle"><img src="images/spike-detection.png" alt="Spike detection chart"><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>Power Anomaly Detection<br><a href="samples/csharp/getting-started/AnomalyDetection_PowerMeterReadings">C#</a><b></td>
      <td align="middle"><img src="images/anomaly-detection.png" alt="Power Anomaly detection chart"><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>Credit Card Fraud Detection<br>(Anomaly Detection)<br><a href="samples/csharp/getting-started/AnomalyDetection_CreditCardFraudDetection">C#</a><b></td>
  </tr> 
  <tr>
    <td align="middle" colspan="3">Clustering</td>
  </tr>
  <tr>
    <td align="middle"><img src="images/customer-segmentation.png" alt="Customer Segmentation chart"><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>Customer Segmentation<br><a href="samples/csharp/getting-started/Clustering_CustomerSegmentation">C#</a> &nbsp; &nbsp; <a href="samples/fsharp/getting-started/Clustering_CustomerSegmentation">F#</a></b></td>
    <td align="middle"><img src="images/clustering.png" alt="IRIS Flowers chart"><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>IRIS Flowers Clustering<br><a href="samples/csharp/getting-started/Clustering_Iris">C#</a> &nbsp; &nbsp; <a href="samples/fsharp/getting-started/Clustering_Iris">F#</a></b></td>
    <td></td>
  </tr>
  <tr>
    <td align="middle" colspan="3">Ranking</td>
  </tr>
  <tr>
    <td align="middle"><img src="images/ranking-numbered.png" alt="Ranking chart"><br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon"><br><b>Rank Search Engine Results<br><a href="samples/csharp/getting-started/Ranking_Web">C#</a><b></td>
      <td></td>
      <td></td>
  </tr>
  <tr>
    <td align="middle" colspan="3">Computer Vision</td>
  </tr>
  <tr>
      <td align="middle"><img src="images/image-classification.png" alt="Image Classification chart"><br><b>Image Classification Training<br>    (High-Level API)<br>
    <img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon">&nbsp;<a href="samples/csharp/getting-started/DeepLearning_ImageClassification_Training">C#</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </td>
    <td align="middle"><img src="images/image-classification.png" alt="Image Classification chart"><br><b>Image Classification Predictions<br>(Pretrained TensorFlow model scoring)<br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon">&nbsp;<a href="samples/csharp/getting-started/DeepLearning_ImageClassification_TensorFlow">C#</a> &nbsp; <a href="samples/fsharp/getting-started/DeepLearning_ImageClassification_TensorFlow">F#</a>&nbsp;&nbsp&nbsp&nbsp&nbsp;&nbsp;
      <img src="images/app-type-e2e-black.png" alt="End-to-end app icon">&nbsp;<a href="samples/csharp/end-to-end-apps/DeepLearning_ImageClassification_TensorFlow">C#</a><b></td><b></td>
    <td align="middle"><img src="images/image-classification.png" alt="Image Classification chart"><br><b>Image Classification Training<br>    (TensorFlow Featurizer Estimator)<br><img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon">&nbsp;<a href="samples/csharp/getting-started/DeepLearning_TensorFlowEstimator">C#</a> &nbsp; <a href="samples/fsharp/getting-started/DeepLearning_TensorFlowEstimator">F#</a><b></td>
  </tr> 
  <tr>
    <td align="middle"><br><img src="images/object-detection.png" alt="Object Detection chart"><br><b>Object Detection<br>    (ONNX model scoring)<br>
    <img src="images/app-type-getting-started-term-cursor.png" alt="Getting started icon">&nbsp;<a href="samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx">C#</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <img src="images/app-type-e2e-black.png" alt="End-to-end app icon">&nbsp;<a href="/samples/csharp/end-to-end-apps/ObjectDetection-Onnx">C#</a><b></td>
  </tr> 
</table>


# Learn more

See [ML.NET Guide](https://docs.microsoft.com/en-us/dotnet/machine-learning/) for detailed information on tutorials, ML basics, etc.

See [MLNet Autopipeline project wesite](https://littlelittlecloud.github.io/machinelearning-auto-pipeline-site/index.html) for docs and articles.

  

