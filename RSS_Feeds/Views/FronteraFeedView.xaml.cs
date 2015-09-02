using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RSS_Feeds
{
	public partial class FronteraFeedView : ContentPage
	{	
		public FronteraFeedView ()
		{
			InitializeComponent ();
			BindingContext = new FronteraFeedViewModel();

		}

		public void OnItemSelected(object sender, ItemTappedEventArgs args)
		{
			var item = args.Item as FronteraRecordViewModel;

			if (item == null)
				return;
			
			Navigation.PushAsync(new RssWebView(item));
			rsslist.SelectedItem = null;
		}

		private FronteraFeedViewModel ViewModel { get { return BindingContext as FronteraFeedViewModel; }}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (ViewModel.Records.Count == 0)
				ViewModel.OnReload();
		}
	}
}
