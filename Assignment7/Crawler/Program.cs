﻿using System.Net;

namespace Crawler
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Text;
    using System.Collections;
    using System.Text.RegularExpressions;
    using System.Threading;

    public class Crawler
    {
        private const int MaxCount = 100;
        private Hashtable urls = new Hashtable();
        private int count = 0;
        string webRef = @"^https?://.*\.(?:htm|html|aspx|php|jsp)$";
        private string limit = @".*(://www.cnblogs.com/dstang2000).*";
        static string startUrl = "http://www.cnblogs.com/dstang2000/";

        static void Main(string[] args)
        {

            Crawler myCrawler = new Crawler();
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);
            new Thread(myCrawler.Crawl).Start();
        }

        private void Crawl()
        {
            Console.WriteLine(" 开始爬行");
            while (true)
            {

                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url])
                    {
                        continue;
                    }

                    if (!Regex.IsMatch(url, limit))
                    {
                        continue;
                    }
                    current = url;
                }

                if (current == null || (count > MaxCount)) break;
                Console.WriteLine(current);
                string html = DownLoad(current); 
                urls[current] = true;
                count++;
                if (Regex.IsMatch(current, webRef) || count == 1)
                {
                    Parse(html, current);
                }
            }

            Console.WriteLine("爬行结束");
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                String fileNarne = count.ToString();
                File.WriteAllText(fileNarne, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }

        }

        private string ParseRelativeLink(string url, string relative)
        {
            string root = new Uri(url).GetLeftPart(UriPartial.Authority);
            string protocol = new Uri(url).Scheme;
            if (Regex.IsMatch(relative, @"^.*://.*"))
            {
                return relative;
            }
            if (Regex.IsMatch(relative, @"^//"))
            {
                return protocol + relative;
            }
            if (Regex.IsMatch(relative, @"^/"))
            {
                return root + relative;
            }
            if (Regex.IsMatch(relative, @"^./"))
            {
                return url + relative.Substring(1);
            }
            if (Regex.IsMatch(relative, @"^[a-zA-Z0-9]+"))
            {
                if (url.EndsWith("/"))
                {
                    return url + relative;
                }
                return url + '/' + relative;
            }
            if (Regex.IsMatch(relative, @"^../"))
            {
                int index = url.LastIndexOf('/');
                if (index > 7)
                {
                    return ParseRelativeLink(url.Substring(0, index), relative.Substring(3));
                }
            }
            return relative;
        }


        public void Parse(string html, string url)
        {
            {
                String strRef = @"(href|HREF)[ ]*=[ ]*[""']([^""'#>]+)[""']";
                MatchCollection matches = new Regex(strRef).Matches(html);

                foreach (Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim
                        ('"', '\'', '#', ' ', '>', '"');
                    strRef = ParseRelativeLink(url, strRef);
                    if (strRef.Length == 0) continue;
                    if (urls[strRef] == null) urls[strRef] = false;
                }
            }
        }
    }
}
