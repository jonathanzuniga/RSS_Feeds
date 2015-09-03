using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace RSS_Feeds
{
	public class RssFeedService
	{
		String rssFeedUrl;

		public RssFeedService(string url)
		{
			rssFeedUrl = url;
		}

		public IEnumerable<RssRecord> GetFronteraRecords()
		{
			return XDocument.Load(rssFeedUrl).Descendants("item").Select(
				x => new RssRecord(
					(string)x.Element("title"),
					(string)x.Element("description"),
					(string)x.Element("link"),
					(string)x.Element("pubDate")
				)
			).ToList();
		}
	}
}
