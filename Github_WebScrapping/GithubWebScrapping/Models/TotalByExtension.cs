using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubWebScraping.Models
{
    public class TotalByExtension
    {
        public double Lines { get; set; }
        public double Bytes { get; set; }
        public TotalByExtension(double lines, double bytes)
        {
            Lines = lines;
            Bytes = bytes;
        }
    }
}
