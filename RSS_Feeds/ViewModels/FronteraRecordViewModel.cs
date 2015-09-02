using System;

namespace RSS_Feeds
{
	public class FronteraRecordViewModel : BaseViewModel
	{
		private readonly FronteraRecord model;

		public FronteraRecordViewModel(FronteraRecord model)
		{
			this.model = model;
		}

		public string Title { get { return model.Title; }}
		public string Link { get { return model.Link; }}
		public string Image { get { return model.Image; }}
		public string PubDate { get { return model.PubDate; }}
	}
}
