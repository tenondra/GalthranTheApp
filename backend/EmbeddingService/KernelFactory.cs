using Microsoft.SemanticKernel;

namespace backend.EmbeddingService;

public class KernelFactory : IKernelFactory
{
    private readonly IConfiguration _configuration;

    public KernelFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public Kernel CreateKernel()
    {
        var kernelBuilder = Kernel
            .CreateBuilder()
            .WithCustomOpenAiEmbeddingModel(_configuration);

        return kernelBuilder.Build();
    }
}