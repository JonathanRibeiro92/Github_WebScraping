using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubWebScraping.Models
{
    public class BlobFile
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public double NumberLines { get; set; }
        public double NumberBytes { get; set; }

        public BlobFile(string fileName, string extension, double numberLines, double numberBytes)
        {
            FileName = fileName;
            Extension = extension;
            NumberLines = numberLines;
            NumberBytes = numberBytes;
        }
    }
}
