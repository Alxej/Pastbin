using Microsoft.EntityFrameworkCore;
using Pastbin.Core.Models;
using Pastbin.DataAccess.Entites;
using Pastbin.Core.Abstractions;

namespace Pastbin.DataAccess.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly PastbinDbContext _context;

        public PostsRepository(PastbinDbContext context)
        {
            _context = context;
        }

        private Post MapEntityToDomain(PostEntity postEntity)
        {
            var post = Post.Create(
                postEntity.Id,
                postEntity.Header,
                UsersRepository.MapEntityToDomain(postEntity.Author),
                ImagesRepository.MapEntityToDomain(postEntity.Image),
                TextBlocksRepository.MapEntityToDomain(postEntity.Text)
                )
                .Post;

            return post;
        }

        public static PostEntity MapDomainToEntity(Post post)
        {
            var entity = new PostEntity()
            {
                Id = post.Id,
                Header = post.Header,
                Author = UsersRepository.MapDomainToEntity(post.Author),
                Image = ImagesRepository.MapDomainToEntity(post.Image),
                Text = TextBlocksRepository.MapDomainToEntity(post.Text)
            };

            return entity;
        }

        public async Task<List<Post>> Get()
        {
            var postEntities = await _context.Posts
                .AsNoTracking()
                .ToListAsync();

            var posts = postEntities
                .Select(x => MapEntityToDomain(x))
                .ToList();

            return posts;
        }

        public async Task<Guid> Create(Post post)
        {
            var postEntity = new PostEntity
            {
                Id = post.Id,
                Header = post.Header,
                Author = UsersRepository.MapDomainToEntity(post.Author),
                Image = ImagesRepository.MapDomainToEntity(post.Image),
                Text = TextBlocksRepository.MapDomainToEntity(post.Text)
            };

            await _context.AddAsync(postEntity);
            await _context.SaveChangesAsync();

            return postEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string header, User author, Image image, TextBlock text)
        {
            await _context.Posts
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(x => x.Header, x => header)
                    .SetProperty(x => x.Author, x => UsersRepository.MapDomainToEntity(author))
                    .SetProperty(x => x.Image, x => ImagesRepository.MapDomainToEntity(image))
                    .SetProperty(x => x.Text, x => TextBlocksRepository.MapDomainToEntity(text)));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Posts
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
