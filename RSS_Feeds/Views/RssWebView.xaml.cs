using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RSS_Feeds
{
	public partial class RssWebView : ContentPage
	{
		public RssWebView (RssRecordViewModel viewModel)
		{
			InitializeComponent ();
			BindingContext = viewModel;
		}
	}
}
