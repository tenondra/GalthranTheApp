using Microsoft.SemanticKernel;

namespace backend.EmbeddingService;

public interface IKernelFactory
{
    public Kernel CreateKernel();
}