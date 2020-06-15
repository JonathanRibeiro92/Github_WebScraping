using GithubWebScraping.Models;
using GithubWebScraping.Services;
using GithubWebScrapping.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GithubWebScrapingTest
{
    public class GithubScraperControllerTest
    {
        GithubScraperController _controller;
        IWebScrapingService _service;
        string urlTest = "https://github.com/ia-organization/particle_filter";



        public GithubScraperControllerTest()
        {
            _service = new WebScrapingServiceFake();
            _controller = new GithubScraperController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get(urlTest);
            // Assert
            Assert.IsType<ActionResult<string>>(okResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get(urlTest);
            // Assert
            //var items = Assert.IsType<Dictionary<string, TotalByExtension>>(okResult);
            var serviceFake = new WebScrapingServiceFake();
            Assert.Equal(JsonConvert.SerializeObject(serviceFake.dict), okResult);
        }


    }
}
