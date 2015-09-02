using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RSS_Feeds
{
	public partial class RssWebView : ContentPage
	{
		public RssWebView (FronteraRecordViewModel viewModel)
		{
			InitializeComponent ();
			BindingContext = viewModel;
		}
	}
}
