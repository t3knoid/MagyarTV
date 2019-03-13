using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagyarTV
{
    class HtmlAgilityPackEx
    {
        /// <summary>
        /// Load from a saved page
        /// </summary>
        /// <param name="cachedFile">Fully qualified path to the cache file.</param>
        /// <returns></returns>
        static public HtmlAgilityPack.HtmlDocument LoadFromCachedHtmlFile(string cachedFile)
        {
            HtmlAgilityPack.HtmlWeb browser = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument htmlDocument = null;

            if (File.Exists(cachedFile))
            {
                try
                {
                    htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    string cachedHtmlFileText = File.ReadAllText(cachedFile);
                    htmlDocument.LoadHtml(cachedHtmlFileText);
                }
                catch (Exception ex)
                {
                    // Log failure here
                }
            }

            return htmlDocument;
        }

    }
}
