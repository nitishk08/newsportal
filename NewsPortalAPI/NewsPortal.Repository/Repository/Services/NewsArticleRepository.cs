using Microsoft.EntityFrameworkCore;
using NewsPortal.Core.ApplicationDbContext;
using NewsPortal.Core.Dtos;
using NewsPortal.Core.Models;
using NewsPortal.Core.Repository.Contracts;

namespace NewsPortal.Core.Repository.Services
{
    public class NewsArticleRepository : INewsArticleRepository
    {
        private readonly NewsPortalDbContext _dbContext;

        public NewsArticleRepository(NewsPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateNewsArticle(NewsArticle newsArticle)
        {          
              _dbContext.NewsArticles.Add(newsArticle);
              await _dbContext.SaveChangesAsync();            
        }

        public async Task DeleteNewsArticle(NewsArticle newsArticle)
        {
            _dbContext.Remove(newsArticle);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(category => category.Name == name);
        }

        public async Task<NewsArticle> GetNewsArticleById(int newsArticleId)
        {
            return await _dbContext.NewsArticles.FirstOrDefaultAsync(n => n.Id == newsArticleId);
        }

        public async Task<IEnumerable<NewsArticleDto>> GetNewsArticles(int page, int pageSize)
        {
            var result = await (from na in _dbContext.NewsArticles
                               join c in _dbContext.Categories on na.CategoryId equals c.Id
                               select new NewsArticleDto
                               {
                                   Id = na.Id,
                                   Title = na.Title,
                                   Description = na.Description,
                                   CreatedDateTime = na.CreatedDateTime,
                                   UpdatedDateTime = na.UpdatedDateTime,
                                   CategoryName = c.Name

                               }).OrderByDescending(na => na.CreatedDateTime)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<NewsArticleDto>> GetNewsArticlesBySearch(string search)
        {
            var items = await (from na in _dbContext.NewsArticles
                               join c in _dbContext.Categories on na.CategoryId equals c.Id
                               where (na.Title + " " + na.Description + " " + c.Name).Contains(search)
                               orderby na.CreatedDateTime descending
                               select new NewsArticleDto
                               {
                                   Id = na.Id,
                                   Title = na.Title,
                                   Description = na.Description,
                                   CreatedDateTime = na.CreatedDateTime,
                                   UpdatedDateTime = na.UpdatedDateTime,
                                   CategoryName = c.Name
                               }).ToListAsync();
            return items;
        }
        public async Task UpdateNewsArticle(NewsArticle newsArticle)
        {
            _dbContext.Update(newsArticle);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetNewsArticlesCount()
        {
            return _dbContext.NewsArticles.ToList().Count;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
           return await _dbContext.Categories.ToListAsync();          
        }      
    }
}
