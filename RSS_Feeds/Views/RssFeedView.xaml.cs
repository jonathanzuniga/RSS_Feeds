using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Connectivity.Plugin;

namespace RSS_Feeds
{
	public partial class RssFeedView : ContentPage
	{	
		public RssFeedView (string url, string title)
		{
			InitializeComponent ();
			BindingContext = new RssFeedViewModel(url);
			Title = title;

			if (!CrossConnectivity.Current.IsConnected)
				DisplayAlert ("Error", "Revisa tu conexión de internet y vuelve a intentarlo.", "Aceptar");
		}

		public void OnItemSelected(object sender, ItemTappedEventArgs args)
		{
			var item = args.Item as RssRecordViewModel;

			if (item == null)
				return;
			
			Navigation.PushAsync(new RssWebView(item));
			rsslist.SelectedItem = null;
		}

		private RssFeedViewModel ViewModel { get { return BindingContext as RssFeedViewModel; }}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (CrossConnectivity.Current.IsConnected) {
				if (ViewModel.Records.Count == 0)
					ViewModel.OnReload ();
			}
		}
	}
}
