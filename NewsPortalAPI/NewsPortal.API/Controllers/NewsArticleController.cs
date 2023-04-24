using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsPortal.Business.Contracts;
using NewsPortal.Core.Dtos;
using NewsPortal.Core.Models;
using System;

namespace NewsPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsArticleController : ControllerBase
    {
        private readonly INewsArticleBusiness _articleBusiness;
        private readonly ILogger<NewsArticleController> _logger;
        private readonly ResponseDto response;

        public NewsArticleController(INewsArticleBusiness articleBusiness, ILogger<NewsArticleController> logger)
        {
            _articleBusiness = articleBusiness ?? throw new ArgumentNullException(nameof(articleBusiness));
            response = new ResponseDto();
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logger.LogInformation("NewsArticlesController initialized.");
        }

        [HttpGet("GetArticles")]
        public async Task<ActionResult<IEnumerable<NewsArticleDto>>> GetAllNewsArticles(int currentPage, int pageSize)
        {
            if (currentPage <= 0 || pageSize <= 0 || pageSize > 5)
            {
                response.IsSuccess = false;
                response.DisplayMessage = "Invalid page or pageSize parameters.";
                response.ErrorMessage = new List<string> { "page must be greater than 0 and pageSize must be between 1 and 5." };

                return BadRequest(response);
            }
            try
            {
                
                var articles = await _articleBusiness.GetNewsArticles(currentPage, pageSize);
                return Ok(articles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting news articles.");

                response.IsSuccess = false;
                response.DisplayMessage = "An error occurred while getting news articles.";
                response.ErrorMessage = new List<string> { ex.Message };
               
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ResponseDto>> CreateNewsArticle(NewsArticleDto newsArticleCreateDto)
        {


            try
            {
                await _articleBusiness.CreateNewsArticle(newsArticleCreateDto);

                response.IsSuccess = true;
                response.DisplayMessage = "News article created successfully.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a news article.");

                response.ErrorMessage = new List<string> { "An error occurred while creating a news article." };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }


        [HttpPut("Update")]
        public async Task<ActionResult<ResponseDto>> UpdateNewsArticle(NewsArticleDto newsArticleDto)
        {


            try
            {
                await _articleBusiness.UpdateNewsArticle(newsArticleDto);

                response.IsSuccess = true;
                response.DisplayMessage = "News article updated successfully.";

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating a news article with Id {newsArticleDto.Id}.");

                response.IsSuccess = false;
                response.ErrorMessage = new List<string> { $"An error occurred while updating a news article with Id {newsArticleDto.Id}." };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }


        [HttpDelete("Delete")]
        public async Task<ActionResult<ResponseDto>> DeleteNewsArticle(int newsArticleId)
        {


            try
            {
                await _articleBusiness.DeleteNewsArticle(newsArticleId);
                response.IsSuccess = true;
                response.DisplayMessage = "News article deleted successfully.";
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting a news article with Id {newsArticleId}.");
                response.IsSuccess = false;
                response.ErrorMessage = new List<string> { $"An error occurred while deleting a news article with Id {newsArticleId}." };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }


        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<NewsArticleDto>>> SearchNewsArticles(string search)
        {

            try
            {      
                var articles = await _articleBusiness.SearchNewsArticles(search);
                return Ok(articles);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = new List<string> { ex.Message };
                _logger.LogError(ex, "An error occurred in SearchNewsArticles");
            }
            return BadRequest(response);
        }

        [HttpGet("GetNewsArticleCount")]
        public async Task<IActionResult> GetNewsArticleCountForPagination()
        {
            try
            {
                var count = await _articleBusiness.GetNewsArticlesCount();    
                return Ok(count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting news article count.");

                response.IsSuccess = false;
                response.DisplayMessage = "An error occurred while getting news article count.";
                response.ErrorMessage = new List<string> { ex.Message };

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategoryList()
        {
            try
            {
                var categories = await _articleBusiness.GetCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting categories.");

                response.IsSuccess = false;
                response.DisplayMessage = "An error occurred while getting categories.";
                response.ErrorMessage = new List<string> { ex.Message };

                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
