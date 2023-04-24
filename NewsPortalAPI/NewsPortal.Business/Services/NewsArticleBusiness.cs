using NewsPortal.Business.Contracts;
using NewsPortal.Core.Dtos;
using NewsPortal.Core.Models;
using NewsPortal.Core.Repository.Contracts;

namespace NewsPortal.Business.Services
{
    public class NewsArticleBusiness : INewsArticleBusiness
    {
        private readonly INewsArticleRepository _newsRepository;

        public NewsArticleBusiness(INewsArticleRepository newsRepository)
        {
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
        }

        ///<inheritdoc/>
        public async Task CreateNewsArticle(NewsArticleDto newsArticleDto)
        {
            if (newsArticleDto == null)
            {
                throw new ArgumentNullException(nameof(newsArticleDto));
            }

            var category = await _newsRepository.GetCategoryByName(newsArticleDto.CategoryName);
            var newsArticle = new NewsArticle
            {
                Title = newsArticleDto.Title,
                Description = newsArticleDto.Description,
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                CategoryId = category.Id
            };

            await _newsRepository.CreateNewsArticle(newsArticle);
        }

        ///<inheritdoc/>
        public async Task<NewsArticle> GetNewsArticleById(int newsArticleId)
        {
            if (newsArticleId <= 0)
            {
                throw new ArgumentException(nameof(newsArticleId));
            }

            return await _newsRepository.GetNewsArticleById(newsArticleId);
        }

        ///<inheritdoc/>
        public async Task DeleteNewsArticle(int newsArticleId)
        {
            if (newsArticleId <= 0)
            {
                throw new ArgumentException(nameof(newsArticleId));
            }

            var newsArticle = await _newsRepository.GetNewsArticleById(newsArticleId);
            if (newsArticle == null)
            {
                throw new Exception($"News article with ID {newsArticleId} not found");
            }

            await _newsRepository.DeleteNewsArticle(newsArticle);
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<NewsArticleDto>> GetNewsArticles(int currentPage, int pageSize)
        {      
            return await _newsRepository.GetNewsArticles(currentPage, pageSize);
        }


        ///<inheritdoc/>
        public async Task<IEnumerable<NewsArticleDto>> SearchNewsArticles(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                throw new ArgumentException("Search text cannot be null or empty");
            }

            return await _newsRepository.GetNewsArticlesBySearch(search);
        }

        ///<inheritdoc/>
        public async Task UpdateNewsArticle(NewsArticleDto newsArticleDto)
        {
            if (newsArticleDto == null)
            {
                throw new ArgumentNullException(nameof(newsArticleDto));
            }

            if (newsArticleDto.Id <= 0)
            {
                throw new ArgumentException("News article ID must be greater than 0");
            }

            var newsArticle = await _newsRepository.GetNewsArticleById(newsArticleDto.Id);
            if (newsArticle == null)
            {
                throw new Exception($"News article with ID {newsArticleDto.Id} not found");
            }

            var category = await _newsRepository.GetCategoryByName(newsArticleDto.CategoryName);

            newsArticle.Title = newsArticleDto.Title;
            newsArticle.Description = newsArticleDto.Description;
            newsArticle.UpdatedDateTime = DateTime.Now;
            newsArticle.CategoryId = category.Id;

            await _newsRepository.UpdateNewsArticle(newsArticle);
        }

        ///<inheritdoc/>
        public async Task<int> GetNewsArticlesCount()
        {
            return await _newsRepository.GetNewsArticlesCount();
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
             var categories =  await _newsRepository.GetCategories();
            var categoryDto = categories.Select(x => new CategoryDto
            {
                Name = x.Name,
            });
            return categoryDto;
            
        }
    }
}
