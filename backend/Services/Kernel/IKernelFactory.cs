namespace backend.Services.Kernel;

public interface IKernelFactory
{
    public Microsoft.SemanticKernel.Kernel GetKernel();
}