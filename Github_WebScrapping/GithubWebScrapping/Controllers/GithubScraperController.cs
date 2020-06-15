using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GithubWebScraping.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GithubWebScrapping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GithubScraperController : ControllerBase
    {

        private readonly IWebScrapingService _service;

        public GithubScraperController(IWebScrapingService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<String> Get(string url)
        {
            if (string.IsNullOrEmpty(url))
                return NotFound();
            //WebScrapingService webScrapingService = new WebScrapingService();
            var dict = _service.StartScrap(url);
            
            return JsonConvert.SerializeObject(dict);
        }
    }
}
