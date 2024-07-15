using Microsoft.EntityFrameworkCore;
using Pastbin.Core.Models;
using Pastbin.DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly PastbinDbContext _context;

        public UserRepository(PastbinDbContext context)
        {
            _context = context;
        }

        private User MapEntityToDomain(UserEntity userEntity)
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

        public async Task<List<User>> Get()
        {
            var bookEntities = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            var users = bookEntities
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
    }
}
