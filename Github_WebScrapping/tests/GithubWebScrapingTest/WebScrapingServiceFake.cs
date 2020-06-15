using GithubWebScraping.Models;
using GithubWebScraping.Services;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubWebScrapingTest
{
    public class WebScrapingServiceFake : IWebScrapingService
    {
        public Dictionary<string, TotalByExtension> dict; 
        public WebScrapingServiceFake()
        {
            dict = new Dictionary<string, TotalByExtension>();
            dict.Add("gitignore", new TotalByExtension(104.0, 119808.0));
            dict.Add("py", new TotalByExtension(212.0, 497122.0));
        }


        public Dictionary<string, TotalByExtension> StartScrap(string url)
        {
            return dict;
        }
    }
}
