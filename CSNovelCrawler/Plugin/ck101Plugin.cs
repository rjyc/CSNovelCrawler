﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using CSNovelCrawler.Class;
using CSNovelCrawler.Interface;

namespace CSNovelCrawler.Plugin
{
    [PluginInformation("ck101Downloader", "ck101.com插件", "Montoli", "1.0.1.0", "卡提諾下載插件", "http://ck101.com")]
    public class Ck101Plugin : IPlugin
    {
        public Ck101Plugin()
        {
            Extensions =new Dictionary<string, object>();
        }

        public IDownloader CreateDownloader()
        {
            return new Ck101Downloader();
        }

        public bool CheckUrl(string url)
        {
            Regex r = new Regex(@"(^http:\/\/\w*\.*ck101.com\/thread-\d+-\d+-\w+\.html)");
            Match m = r.Match(url);
            if (m.Success)
            {
                return true;
            }
            return false;
        }

        public string GetHash(string url)
        {
            Regex r = new Regex(@"(^http:\/\/\w*\.*ck101.com\/thread-(?<TID>\d+)-\d+-\w+\.html)");
            Match m = r.Match(url);
            if (m.Success)
            {

                return "ck101" + m.Groups["TID"].Value;
            }
            return null;
        }

        public Dictionary<string, object> Extensions { get; private set; }

        public DictionaryExtension<string, string> Configuration { get; set; }
    }
}
