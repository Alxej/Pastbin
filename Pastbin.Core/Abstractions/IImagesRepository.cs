using Pastbin.Core.Models;

namespace Pastbin.Core.Abstractions
{
    public interface IImagesRepository
    {
        Task<Guid> Create(Image image);
        Task<Guid> Delete(Guid id);
        Task<List<Image>> Get();
        Task<Guid> Update(Guid id, string name, string url, DateTime addedAt, TimeOnly urlLifeCycle);
    }
}