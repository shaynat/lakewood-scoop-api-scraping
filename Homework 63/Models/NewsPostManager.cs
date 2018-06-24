using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;


namespace Homework_63.Models
{
    public class NewsPostManager
    {
        public IEnumerable<NewsPost> GetAllNews()
        {
            var url = "http://www.thelakewoodscoop.com/";
            var client = new WebClient();

            var html = client.DownloadString(url);

            var parser = new HtmlParser();
            var document = parser.Parse(html);

            IEnumerable<IElement> newsPosts = document.QuerySelectorAll(".post");
            return newsPosts.Select(GetPost).Where(np => np != null);
        }

        public NewsPost GetPost(IElement post)
        {
            var result = new NewsPost();

            var title = post.QuerySelector("h2");
            if (title != null)
            {
                result.Title = title.TextContent;
            }           
            
            var img = post.QuerySelector("img");
            if (img != null)
            {
                result.Image = img.Attributes["src"].Value;
            }

            var url = post.QuerySelector(".more-link");
            if (url != null)
            {
                result.Url = url.Attributes["href"].Value;
            }

            var text = post.QuerySelector("p");
            if(text != null)
            {
                result.Text = text.TextContent;
            }

            return result;
        }
    }
}