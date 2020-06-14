using GithubWebScraping.Models;
using GithubWebScraping.Utils;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GithubWebScraping.Services
{
    public class WebScrapingService
    {
        public Dictionary<string, TotalByExtension> dict = new Dictionary<string, TotalByExtension>();
        public Dictionary<string, TotalByExtension> StartScrap(string url)
        {
            try
            {
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument = OpenLink(url);

                var divRepoContent = htmlDocument.DocumentNode.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "").Equals("repository-content ")).ToList();

                ReadFile(divRepoContent.First());
                return dict;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private static HtmlDocument OpenLink(string link)
        {
            try
            {
                HtmlDocument htmlDocument = new HtmlDocument();
                HttpClient httpClient = new HttpClient();
                //Get the html string from page
                var html = httpClient.GetStringAsync(link).Result;
                htmlDocument.LoadHtml(html);
                return htmlDocument;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        private void ReadFile(HtmlNode node)
        {
            try
            {
                var listTrItems = node.Descendants("tr")
                .Where(node => node.GetAttributeValue("class", "").Equals("js-navigation-item")).ToList();

                foreach (var item in listTrItems)
                {
                    var nodeFolder = item.Descendants("a")
                        .Where(node => node.GetAttributeValue("class", "").Equals("js-navigation-open ")).First();
                    string fileLink = nodeFolder.GetAttributeValue("href", "");
                    string urlBase = "https://github.com";
                    var htmlDoc = OpenLink(urlBase + fileLink);
                    var divLinesBytes = htmlDoc.DocumentNode.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "").Equals("text-mono f6 flex-auto pr-3 flex-order-2 flex-md-order-1 mt-2 mt-md-0")).ToList();
                    if (divLinesBytes != null && divLinesBytes.Count > 0)
                    {
                        var nodeLines = divLinesBytes.First();
                        string textLines = nodeLines.InnerText.Trim();
                        var listTextLines = textLines.Split("\n      \n    ");
                        var strongFinalPath = htmlDoc.GetElementbyId("blob-path").Descendants("strong")
                            .Where(node => node.GetAttributeValue("class", "").Equals("final-path")).ToList().First();
                        string fileName = strongFinalPath.InnerText;
                        var listFileType = fileName.Split(".");
                        string fileType = "";
                        if (listFileType != null && listFileType.Length > 0)
                            fileType = listFileType.Last();

                        double nLines = 0;

                        if (listTextLines.Length > 1)
                            nLines = double.Parse(listTextLines.First().Split().First());

                        string sBytes = Consts.ConvertToBytes(listTextLines.Last());
                        double nBytes = double.Parse(sBytes.Split().First());
                        BlobFile blobFile = new BlobFile(fileName, fileType, nLines, nBytes);

                        if (dict.ContainsKey(blobFile.Extension))
                        {
                            dict[blobFile.Extension].Lines += blobFile.NumberLines;
                        }
                        else
                        {
                            TotalByExtension totalByExtension = new TotalByExtension(blobFile.NumberLines, blobFile.NumberBytes);
                            dict.Add(blobFile.Extension, totalByExtension);
                        }
                    }
                    else
                    {
                        var divRepoContent = htmlDoc.DocumentNode.Descendants("div")
                            .Where(node => node.GetAttributeValue("class", "").Equals("repository-content ")).ToList();
                        ReadFile(divRepoContent.First());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
