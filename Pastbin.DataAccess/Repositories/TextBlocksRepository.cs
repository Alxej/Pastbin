using Microsoft.EntityFrameworkCore;
using Pastbin.Core.Models;
using Pastbin.DataAccess.Entites;
using Pastbin.Core.Abstractions;

namespace Pastbin.DataAccess.Repositories
{
    public class TextBlocksRepository : ITextBlocksRepository
    {
        private readonly PastbinDbContext _context;

        public TextBlocksRepository(PastbinDbContext context)
        {
            _context = context;
        }

        public static TextBlock MapEntityToDomain(TextBlockEntity textBlockEntity)
        {
            var textBlock = TextBlock.Create(
                textBlockEntity.Id,
                textBlockEntity.TextFileName,
                textBlockEntity.Url,
                textBlockEntity.AddedAt,
                textBlockEntity.UrlLifeCycle)
                .TextBlock;

            return textBlock;
        }

        public static TextBlockEntity MapDomainToEntity(TextBlock textBlock)
        {
            var entity = new TextBlockEntity()
            {
                Id = textBlock.Id,
                TextFileName = textBlock.TextFileName,
                Url = textBlock.Url,
                AddedAt = textBlock.AddedAt,
                UrlLifeCycle = textBlock.UrlLifeCycle
            };

            return entity;
        }

        public async Task<List<TextBlock>> Get()
        {
            var textBlockEntities = await _context.TextBlocks
                .AsNoTracking()
                .ToListAsync();

            var textBlocks = textBlockEntities
                .Select(x => MapEntityToDomain(x))
                .ToList();

            return textBlocks;
        }

        public async Task<Guid> Create(TextBlock TextBlock)
        {
            var textBlockEntity = new TextBlockEntity
            {
                Id = TextBlock.Id,
                TextFileName = TextBlock.TextFileName,
                Url = TextBlock.Url,
                AddedAt = TextBlock.AddedAt,
                UrlLifeCycle = TextBlock.UrlLifeCycle
            };

            await _context.AddAsync(textBlockEntity);
            await _context.SaveChangesAsync();

            return textBlockEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string textFileName, string url, DateTime addedAt, TimeOnly urlLifeCycle)
        {
            await _context.TextBlocks
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(x => x.TextFileName, x => textFileName)
                    .SetProperty(x => x.Url, x => url)
                    .SetProperty(x => x.AddedAt, x => addedAt)
                    .SetProperty(x => x.UrlLifeCycle, x => urlLifeCycle));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.TextBlocks
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
