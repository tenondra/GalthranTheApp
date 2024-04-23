using Microsoft.KernelMemory;
using Microsoft.SemanticKernel;

namespace backend.EmbeddingService;

public class KernelFactory : IKernelFactory
{
    public Kernel GetKernel() => _kernel;
    private readonly Kernel _kernel;
    
    private readonly IConfiguration _configuration;
    
    public KernelFactory(IConfiguration configuration)
    {
        _configuration = configuration;
        _kernel = CreateKernel();
    }
    
    private Kernel CreateKernel()
    {
        var kernelBuilder = Kernel
            .CreateBuilder()
            .WithCustomOpenAiEmbeddingModel(_configuration);

        return kernelBuilder.Build();
    }
}