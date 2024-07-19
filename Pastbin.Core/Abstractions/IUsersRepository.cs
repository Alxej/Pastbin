using Pastbin.Core.Models;

namespace Pastbin.Core.Abstractions
{
    public interface IUsersRepository
    {
        Task<Guid> Create(User user);
        Task<Guid> Delete(Guid id);
        Task<List<User>> Get();
        Task<Guid> Update(Guid id, string userName, string password, string name, string lastName, string surname);
    }
}