using Microsoft.SemanticKernel;

namespace backend.Services.Kernel;

public class KernelFactory : IKernelFactory
{
    public Microsoft.SemanticKernel.Kernel GetKernel() => _kernel;
    private readonly Microsoft.SemanticKernel.Kernel _kernel;
    
    private readonly IConfiguration _configuration;
    
    public KernelFactory(IConfiguration configuration)
    {
        _configuration = configuration;
        _kernel = CreateKernel();
    }
    
    private Microsoft.SemanticKernel.Kernel CreateKernel()
    {
        var kernelBuilder = Microsoft.SemanticKernel.Kernel
            .CreateBuilder()
            .WithCustomOpenAiEmbeddingModel(_configuration);

        return kernelBuilder.Build();
    }
}