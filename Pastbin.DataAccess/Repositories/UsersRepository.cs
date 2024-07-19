using Microsoft.EntityFrameworkCore;
using Pastbin.Core.Models;
using Pastbin.DataAccess.Entites;
using Pastbin.Core.Abstractions;

namespace Pastbin.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly PastbinDbContext _context;
        public UsersRepository(PastbinDbContext context)
        {
            _context = context;
        }

        public static User MapEntityToDomain(UserEntity userEntity)
        {
            var user = User.Create(
                userEntity.Id,
                userEntity.UserName,
                userEntity.Password,
                userEntity.Name,
                userEntity.LastName,
                userEntity.Surname)
                .User;

            return user;
        }

        public static UserEntity MapDomainToEntity(User user)
        {
            var entity = new UserEntity()
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Name = user.Name,
                LastName = user.LastName,
                Surname = user.Surname
            };

            return entity;
        }

        public async Task<List<User>> Get()
        {
            var userEntities = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            var users = userEntities
                .Select(x => MapEntityToDomain(x))
                .ToList();

            return users;
        }

        public async Task<Guid> Create(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Name = user.Name,
                LastName = user.LastName,
                Surname = user.Surname,
            };

            await _context.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string userName, string password, string name, string lastName, string surname)
        {
            await _context.Users
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(x => x.UserName, x => userName)
                    .SetProperty(x => x.Password, x => User.EncryptPassword(password))
                    .SetProperty(x => x.Name, x => name)
                    .SetProperty(x => x.LastName, x => lastName)
                    .SetProperty(x => x.Surname, x => surname));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Users
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
