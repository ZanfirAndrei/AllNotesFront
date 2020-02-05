using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllNotesFront.Helpers
{
    public class HttpClientHelper
    {
        private const string _basePath = "https://localhost:44342/api/";
        public static Uri GetCustomUri(string path)
        {
            return new Uri(_basePath + path + "/");
        }
    }
}
