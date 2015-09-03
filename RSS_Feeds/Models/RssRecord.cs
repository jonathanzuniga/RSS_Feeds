using System;
using System.Text.RegularExpressions;

namespace RSS_Feeds
{
	public class RssRecord
	{
		public RssRecord (string title, string image, string link, string pubDate)
		{
			this.Title = title;

			var match = Regex.Match(image, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase);

			if (match.Success) {
				this.Image = match.Groups[1].Value;
			}

			this.Link = link;
			this.PubDate = pubDate == null ? "Sin fecha de publicación." : pubDate;
		}

		public string Title { get; set; }
		public string Link { get; set; }
		public string Image { get; set; }
		public string PubDate { get; set; }
	}
}
