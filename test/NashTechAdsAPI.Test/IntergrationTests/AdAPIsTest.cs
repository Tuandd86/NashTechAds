//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.Internal;
//using Microsoft.AspNetCore.Mvc.Testing;
//using NashTechAdsAPI.ViewModels;
//using Xunit;

//namespace NashTechAdsAPI.Test.IntergrationTests
//{
//    public class AdsAPIsTest : IClassFixture<TestWebApplicationFactory<Startup>>
//    {
//        private readonly TestWebApplicationFactory<Startup> _factory;

//        public AdsAPIsTest(TestWebApplicationFactory<Startup> factory)
//        {
//            _factory = factory;
//        }

//        [Fact]
//        public async Task GetAds_WithoutLogin_Ok()
//        {
//            var client = _factory.CreateClient();

//            var response = await client.GetAsync("api/ads");

//            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
//        }

//        [Fact]
//        public async Task DeleteAds_WithoutLogin_Fail()
//        {
//            var client = _factory.CreateClient();

//            var response = await client.DeleteAsync("api/ads/1");

//            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
//        }
//    }
//}
