using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace RSS_Feeds
{
	public class FronteraFeedService
	{
		public IEnumerable<FronteraRecord> GetFronteraRecords()
		{
			return XDocument.Load(@"http://www.frontera.info/rss/rss.xml").Descendants("item").Select(
				x => new FronteraRecord(
					(string)x.Element("title"),
					(string)x.Element("description"),
					(string)x.Element("link"),
					(string)x.Element("pubDate")
				)
			).ToList();
		}
	}
}
