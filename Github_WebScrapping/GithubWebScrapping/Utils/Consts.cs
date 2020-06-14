using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubWebScraping.Utils
{
    public class Consts
    {
        public const double KB = 1024;
        public const double MB = 1024 * KB;
        public const double GB = 1024 * MB;
        public const double TB = 1024 * MB;
        public const double PB = 1024 * TB;
        public const double HB = 1024 * PB;
        public const double YB = 1024 * HB;


        public static string ConvertToBytes(string toBytes)
        {
            try
            {
                string bytesConvert = "";

                var listToBytes = toBytes.Split();

                if (listToBytes.Length == 2)
                {
                    if (listToBytes[1] == "Bytes")
                        return toBytes;
                    switch (listToBytes[1])
                    {
                        case "KB":
                            bytesConvert = (double.Parse(listToBytes[0]) *  KB).ToString();
                            break;
                        case "MB":
                            bytesConvert = (double.Parse(listToBytes[0]) * MB).ToString();
                            break;
                        case "GB":
                            bytesConvert = (double.Parse(listToBytes[0]) * GB).ToString();
                            break;
                        case "TB":
                            bytesConvert = (double.Parse(listToBytes[0]) * TB).ToString();
                            break;
                        case "PB":
                            bytesConvert = (double.Parse(listToBytes[0]) * PB).ToString();
                            break;
                        case "HB":
                            bytesConvert = (double.Parse(listToBytes[0]) * HB).ToString();
                            break;
                        case "YB":
                            bytesConvert = (double.Parse(listToBytes[0]) * YB).ToString();
                            break;
                        default:
                            break;
                    }
                    bytesConvert += " bytes";
                }

                return bytesConvert;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
