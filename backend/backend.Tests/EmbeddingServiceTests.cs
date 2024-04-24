// using System.Collections.ObjectModel;
// using backend.EmbeddingService;
// using Microsoft.Extensions.Configuration;
// using Microsoft.SemanticKernel;
// using Microsoft.SemanticKernel.Embeddings;
// using Moq;
// using NSubstitute;
// using Xunit;
//
// namespace backend.Tests;
//
// public class EmbeddingServiceTests
// {
//
//     private IConfiguration _configuration;
//     private IEmbeddingService _embeddingService;
//     
//     public EmbeddingServiceTests()
//     {
//         SetupConfiguration();
//         var embeddingMock = new Mock<ITextEmbeddingGenerationService>((e => e.GenerateEmbeddingsAsync().Returns());
//         var kernelMock = new Mock<Kernel>();
//         kernelMock.Setup(kernel => kernel.GetRequiredService<Arg.AnyType>()).Returns(embeddingMock);
//         _embeddingService = new EmbeddingService.EmbeddingService(_configuration, Kernel.);
//     }
//
//     private void SetupConfiguration()
//     {
//         var inMemoryCollection = new Dictionary<string, string>
//         {
//             {"Embedding:ApiKey", "TestingApiKey"},
//             {"Embedding:Model", "MyFavouriteEmbeddingModel"}
//         };
//         var configuration = new ConfigurationBuilder()
//             .AddInMemoryCollection(inMemoryCollection)
//             .Build();
//
//         _configuration = configuration;
//     }
//     
//     [Fact]
//     public void Test1()
//     {
//         var random = new Random();
//         var text = "This is a board game rule that is hard to understand";
//         float[] vector = Enumerable.Range(1, 100).Select(_ => (float)random.NextDouble()).ToArray();
//         var embedding = new ReadOnlyMemory<float>(vector);
//         _embeddingService.GenerateEmbeddings(Arg.Any<string>()).Returns(embedding);
//     }
// }