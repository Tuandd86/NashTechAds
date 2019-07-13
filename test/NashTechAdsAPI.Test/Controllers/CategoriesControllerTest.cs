using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NashTechAdsAPI.Controllers;
using NashTechAdsAPI.Data;
using NashTechAdsAPI.Models;
using NashTechAdsAPI.Test.Helpers;
using Xunit;

namespace NashTechAdsAPI.Test.Controllers
{
    public class CategoriesControllerTest : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public CategoriesControllerTest(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task PostCategory_Ok()
        {
            // Arrange
            var dbContext = _fixture.Context;
            var categoryName = "test category";
            var category = new Category
            {
                Name = categoryName
            };
            var controller = new CategoriesController(dbContext);

            // Act
            var result = await controller.PostCategory(category);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var createdCategory = Assert.IsType<Category>(createdAtActionResult.Value);
            Assert.Equal(categoryName, createdCategory.Name);
        }

        [Fact]
        public async Task GetCategories_Ok()
        {
            // Arrange
            var dbContext = _fixture.Context;
            var cats = await CreateTestCategory(dbContext);
            var controller = new CategoriesController(dbContext);

            // Act
            var result = await controller.GetCategories();

            // Assert
            var categories = Assert.IsType<List<Category>>(result.Value);
            Assert.Equal(cats.Count, categories.Count);
        }

        [Fact]
        public async Task GetCategory_Ok()
        {
            // Arrange
            var dbContext = _fixture.Context;
            await CreateTestCategory(dbContext);
            var controller = new CategoriesController(dbContext);

            // Act
            var result = await controller.GetCategory(1);

            // Assert
            var category = Assert.IsType<Category>(result.Value);
            Assert.Equal("Cat 1", category.Name);
        }

        [Fact]
        public async Task GetCategory_NotFound()
        {
            // Arrange
            var dbContext = _fixture.Context;
            await CreateTestCategory(dbContext);
            var controller = new CategoriesController(dbContext);

            // Act
            var result = await controller.GetCategory(5);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task DeleteCategory_Ok()
        {
            // Arrange
            var dbContext = _fixture.Context;
            await CreateTestCategory(dbContext);
            var controller = new CategoriesController(dbContext);

            // Act
            var result = await controller.DeleteCategory(1);

            // Assert
            var category = Assert.IsType<Category>(result.Value);
            Assert.Equal("Cat 1", category.Name);
            Assert.Equal(1, dbContext.Categories.Count());
        }

        [Fact]
        public async Task UpdateCategory_Ok()
        {
            // Arrange
            var dbContext = _fixture.Context;
            var cats = await CreateTestCategory(dbContext);
            var updatedCategory = new Category
            {
                Id = 1,
                Name = "Updated"
            };

            var controller = new CategoriesController(dbContext);

            // Act
            var result = await controller.PutCategory(1, updatedCategory);

            // Assert
            Assert.IsType<NoContentResult>(result);
            var newCats = dbContext.Categories.ToList();
            Assert.Equal(cats.Count, newCats.Count);
            Assert.Equal("Updated", newCats.First(x => x.Id == 1).Name);
        }

        private async static Task<IList<Category>> CreateTestCategory(AdsDbContext dbContext)
        {
            IList<Category> cats = new List<Category>();
            cats.Add(new Category
            {
                Name = "Cat 1"
            });

            cats.Add(new Category
            {
                Name = "Cat 1"
            });

            dbContext.Categories.AddRange(cats);
            await dbContext.SaveChangesAsync();

            dbContext.DetachAll();

            return cats;
        }
    }
}
