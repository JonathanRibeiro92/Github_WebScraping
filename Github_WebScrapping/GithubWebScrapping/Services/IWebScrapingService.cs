using GithubWebScraping.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubWebScraping.Services
{
    public interface IWebScrapingService
    {
        public Dictionary<string, TotalByExtension> StartScrap(string url);
    }
}
