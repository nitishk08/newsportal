using NewsPortal.Core.Dtos;
using NewsPortal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Core.Repository.Contracts
{
    public interface INewsArticleRepository
    {
        /// <summary>
        /// Returns a collection of news articles that match the given search criteria.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<IEnumerable<NewsArticleDto>> GetNewsArticlesBySearch(string search);

        /// <summary>
        /// Returns a collection of news articles for a given page number and page size.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<NewsArticleDto>> GetNewsArticles(int page, int pageSize);

        /// <summary>
        /// Returns the news article with the specified news article ID.
        /// </summary>
        /// <param name="newsArticleId"></param>
        /// <returns></returns>
        Task<NewsArticle> GetNewsArticleById(int newsArticleId);

        /// <summary>
        /// Returns the category with the specified category name.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        Task<Category> GetCategoryByName(string name);

        /// <summary>
        /// Creates a new news article with the given news article.
        /// </summary>
        /// <param name="newsArticle"></param>
        /// <returns></returns>
        Task CreateNewsArticle(NewsArticle newsArticle);

        /// <summary>
        /// Updates an existing news article with the specified news article.
        /// </summary>
        /// <param name="newsArticle"></param>
        /// <returns></returns>
        Task UpdateNewsArticle(NewsArticle newsArticle);

        /// <summary>
        /// Deletes an existing news article from the database.
        /// </summary>
        /// <param name="newsArticle"></param>
        /// <returns></returns>
        Task DeleteNewsArticle(NewsArticle newsArticle);

        /// <summary>
        /// Return the total count of news articles present in the database.
        /// </summary>      
        /// <returns></returns>
        Task<int> GetNewsArticlesCount();

        /// <summary>
        /// Get the all list of category.
        /// </summary>    
        /// <returns></returns>
        Task<IEnumerable<Category>> GetCategories();
    }
}
