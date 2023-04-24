using NewsPortal.Core.Dtos;
using NewsPortal.Core.Models;

namespace NewsPortal.Business.Contracts
{
    public interface INewsArticleBusiness
    {
        /// <summary>
        /// Retrieves a paginated list of news articles, given the current page number and page size.
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<NewsArticleDto>> GetNewsArticles(int currentPage, int PageSize);

        /// <summary>
        /// Searches for news articles containing the specified search text.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<IEnumerable<NewsArticleDto>> SearchNewsArticles(string search);

        /// <summary>
        /// Updates an existing news article with the provided newsArticleDto data.
        /// </summary>
        /// <param name="newsArticleDto"></param>
        /// <returns></returns>
        Task UpdateNewsArticle(NewsArticleDto newsArticleDto);

        /// <summary>
        /// Deletes the specified news article from the database.
        /// </summary>
        /// <param name="newsArticleId"></param>
        /// <returns></returns>
        Task DeleteNewsArticle(int newsArticleId);

        /// <summary>
        /// Creates a new news article with the provided newsArticleDto data.
        /// </summary>
        /// <param name="newsArticle"></param>
        /// <returns></returns>
        Task CreateNewsArticle(NewsArticleDto newsArticle);

        /// <summary>
        /// Retrieves a news article by its unique identifier.
        /// </summary>
        /// <param name="newsArticleId"></param>
        /// <returns></returns>
        Task<NewsArticle> GetNewsArticleById(int newsArticleId);

        /// <summary>
        /// Return the total count of news articles present in the database.
        /// </summary>      
        /// <returns></returns>
        Task<int> GetNewsArticlesCount();

        /// <summary>
        /// Get the all list of category Name.
        /// </summary>    
        /// <returns></returns>
        Task<IEnumerable<CategoryDto>> GetCategories();
    }
}
