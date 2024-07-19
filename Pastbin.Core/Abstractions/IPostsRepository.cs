using Pastbin.Core.Models;

namespace Pastbin.Core.Abstractions
{
    public interface IPostsRepository
    {
        Task<Guid> Create(Post post);
        Task<Guid> Delete(Guid id);
        Task<List<Post>> Get();
        Task<Guid> Update(Guid id, string header, User author, Image image, TextBlock text);
    }
}