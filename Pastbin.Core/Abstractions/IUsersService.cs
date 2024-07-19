using Pastbin.Core.Models;

namespace Pastbin.Core.Abstractions
{
    public interface IUsersService
    {
        Task<Guid> CreateUser(User user);
        Task<Guid> DeleteUser(Guid id);
        Task<List<User>> GetAllUsers();
        Task<Guid> UpdateUser(Guid id, string userName, string password, string name, string lastName, string surname);
    }
}