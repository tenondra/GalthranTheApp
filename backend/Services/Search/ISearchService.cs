namespace backend.Services;

public interface ISearchService
{
    public Task<string> Search(string text);
}