using Microsoft.EntityFrameworkCore;
using Pastbin.Core.Models;
using Pastbin.DataAccess.Entites;
using Pastbin.Core.Abstractions;

namespace Pastbin.DataAccess.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        private readonly PastbinDbContext _context;

        public ImagesRepository(PastbinDbContext context)
        {
            _context = context;
        }

        public static Image MapEntityToDomain(ImageEntity imageEntity)
        {
            var image = Image.Create(
                imageEntity.Id,
                imageEntity.Name,
                imageEntity.Url,
                imageEntity.AddedAt,
                imageEntity.UrlLifeCycle)
                .Image;

            return image;
        }

        public static ImageEntity MapDomainToEntity(Image image)
        {
            var entity = new ImageEntity()
            {
                Id = image.Id,
                Name = image.Name,
                Url = image.Url,
                AddedAt = image.AddedAt,
                UrlLifeCycle = image.UrlLifeCycle
            };

            return entity;
        }

        public async Task<List<Image>> Get()
        {
            var imageEntities = await _context.Images
                .AsNoTracking()
                .ToListAsync();

            var images = imageEntities
                .Select(x => MapEntityToDomain(x))
                .ToList();

            return images;
        }

        public async Task<Guid> Create(Image image)
        {
            var imageEntity = new ImageEntity
            {
                Id = image.Id,
                Name = image.Name,
                Url = image.Url,
                AddedAt = image.AddedAt,
                UrlLifeCycle = image.UrlLifeCycle
            };

            await _context.AddAsync(imageEntity);
            await _context.SaveChangesAsync();

            return imageEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string url, DateTime addedAt, TimeOnly urlLifeCycle)
        {
            await _context.Images
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(x => x.Name, x => name)
                    .SetProperty(x => x.Url, x => url)
                    .SetProperty(x => x.AddedAt, x => addedAt)
                    .SetProperty(x => x.UrlLifeCycle, x => urlLifeCycle));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Images
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
