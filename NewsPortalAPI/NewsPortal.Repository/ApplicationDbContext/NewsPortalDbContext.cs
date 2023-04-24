using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NewsPortal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NewsPortal.Core.ApplicationDbContext
{
    public class NewsPortalDbContext : DbContext
    {
        public NewsPortalDbContext(DbContextOptions<NewsPortalDbContext> options) : base(options)
        {

        }
        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Sports",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 2,
                Name = "Technology",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 3,
                Name = "Health",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 4,
                Name = "Environments",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 5,
                Name = "Politics",
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 6,
                Name = "Weather",
            });
            modelBuilder.Entity<NewsArticle>().HasData(new NewsArticle
            {
                Id = 1,
                Title = "COVID-19 vaccine rollout expands to teens",
                Description = "The COVID-19 vaccine rollout has now been expanded to include teens aged 16 and 17, with many states and cities beginning to offer appointments.",
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                CategoryId = 3,

            });
            modelBuilder.Entity<NewsArticle>().HasData(new NewsArticle
            {
                Id = 2,
                Title = "Record-breaking heatwave hits western United States",
                Description = "Parts of the western United States are experiencing a record-breaking heatwave, with temperatures reaching over 100 degrees Fahrenheit in many areas.",
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                CategoryId = 6,
            });
            modelBuilder.Entity<NewsArticle>().HasData(new NewsArticle
            {
                Id = 3,
                Title = "New study shows benefits of meditation on mental health",
                Description = "A new study has found that practicing meditation regularly can have significant positive effects on mental health, including reducing symptoms of anxiety and depression.",
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                CategoryId = 3,
            });
            modelBuilder.Entity<NewsArticle>().HasData(new NewsArticle
            {
                Id = 4,
                Title = "Government announces new funding for renewable energy projects",
                Description = "The government has announced a new round of funding for renewable energy projects, with a focus on solar and wind power.",
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                CategoryId = 4,
            });
            modelBuilder.Entity<NewsArticle>().HasData(new NewsArticle
            {
                Id = 5,
                Title = "New report highlights effects of climate change on global food supply",
                Description = "A new report has highlighted the growing impact of climate change on the global food supply, with experts warning of potential shortages and price increases.",
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                CategoryId = 4,
            });
            modelBuilder.Entity<NewsArticle>().HasData(new NewsArticle
            {
                Id = 6,
                Title = "New study finds link between air pollution and cardiovascular disease",
                Description = "A new study has found a significant link between exposure to air pollution and an increased risk of cardiovascular disease, including heart attacks and strokes.",
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                CategoryId = 3,
            });
            modelBuilder.Entity<NewsArticle>().HasData(new NewsArticle
            {
                Id = 7,
                Title = "Technology company unveils new smartphone with advanced features",
                Description = "A technology company has unveiled a new smartphone with advanced features, including a foldable screen and 5G connectivity.",
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                CategoryId = 2,
            });
            modelBuilder.Entity<NewsArticle>().HasData(new NewsArticle
            {
                Id = 8,
                Title = "Athlete breaks world record in track and field event",
                Description = "An athlete has broken the world record in a track and field event, setting a new standard for performance in the sport.",
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                CategoryId = 1,
            });
            modelBuilder.Entity<NewsArticle>().HasData(new NewsArticle
            {
                Id = 9,
                Title = "SpaceX successfully launches Falcon 9 rocket",
                Description = "SpaceX launched a Falcon 9 rocket carrying 60 Starlink internet satellites into orbit from Florida's Cape Canaveral Space Force Station on Monday.",
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                CategoryId = 2,
            });
            modelBuilder.Entity<NewsArticle>().HasData(new NewsArticle
            {
                Id = 10,
                Title = "Climate change protests erupt in major cities around the world",
                Description = "Protests demanding action on climate change have erupted in major cities around the world, with thousands of people taking to the streets.",
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                CategoryId = 4,
            });
            modelBuilder.Entity<NewsArticle>().HasData(new NewsArticle
            {
                Id = 11,
                Title = "Apple announces new iPhone with foldable screen",
                Description = "Apple has announced a new iPhone model that features a foldable screen, allowing users to have a larger display when needed.",
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                CategoryId = 2,
            });
            modelBuilder.Entity<NewsArticle>().HasData(new NewsArticle
            {
                Id = 12,
                Title = "UN condemns Myanmar's military for human rights violations",
                Description = "The United Nations has condemned Myanmar's military for human rights violations against the Rohingya minority, including rape, torture, and murder.",
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                CategoryId = 5,
            });
            modelBuilder.Entity<NewsArticle>().HasData(new NewsArticle
            {
                Id = 13,
                Title = "Climate change protests erupt in major cities around the world",
                Description = "Protests demanding action on climate change have erupted in major cities around the world, with thousands of people taking to the streets.",
                CreatedDateTime = DateTime.Now,
                UpdatedDateTime = DateTime.Now,
                CategoryId = 5,
            });      
        }
    }
}
