﻿using System;

namespace RSS_Feeds
{
	public class RssRecordViewModel : BaseViewModel
	{
		private readonly RssRecord model;

		public RssRecordViewModel(RssRecord model)
		{
			this.model = model;
		}

		public string Title { get { return model.Title; }}
		public string Link { get { return model.Link; }}
		public string Image { get { return model.Image; }}
		public string PubDate { get { return model.PubDate; }}
	}
}
