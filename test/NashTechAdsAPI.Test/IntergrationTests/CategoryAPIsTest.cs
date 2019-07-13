//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.Testing;
//using NashTechAdsAPI.Models;
//using Xunit;

//namespace NashTechAdsAPI.Test.IntergrationTests
//{
//    public class CategoryAPIsControllerTest : IClassFixture<TestWebApplicationFactory<Startup>>
//    {
//        private readonly TestWebApplicationFactory<Startup> _factory;

//        public CategoryAPIsControllerTest(TestWebApplicationFactory<Startup> factory)
//        {
//            _factory = factory;
//        }

//        [Fact]
//        public async Task Create_Category_Ok()
//        {
//            var client = _factory.CreateClient();
//            var category = new Category
//            {
//                Name = "Test Cat name"
//            };

//            var response = await client.PostAsJsonAsync("api/categories", category);

//            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
//        }

//        [Fact]
//        public async Task GetCategories_Ok()
//        {
//            var client = _factory.CreateClient();

//            var response = await client.GetAsync("api/categories");
//            var categories =  await response.Content.ReadAsAsync<IList<Category>>();

//            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
//            Assert.Equal(1, categories.Count);
//        }
//    }
//}
