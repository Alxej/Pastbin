using Pastbin.Core.Models;

namespace Pastbin.Core.Abstractions
{
    public interface ITextBlocksRepository
    {
        Task<Guid> Create(TextBlock TextBlock);
        Task<Guid> Delete(Guid id);
        Task<List<TextBlock>> Get();
        Task<Guid> Update(Guid id, string textFileName, string url, DateTime addedAt, TimeOnly urlLifeCycle);
    }
}