using System;

using Xamarin.Forms;

namespace RSS_Feeds
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application.
			var tabbedPage = new TabbedPage();

			tabbedPage.Children.Add(new FronteraFeedView());
			tabbedPage.Children.Add(new ContentPage { BackgroundColor = Color.Blue, Title = "Page 2" });
			tabbedPage.Children.Add(new ContentPage { BackgroundColor = Color.Green, Title = "Page 3" });

			MainPage = new NavigationPage(tabbedPage);
		}

		protected override void OnStart ()
		{
			// Handle when your app starts.
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps.
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes.
		}
	}
}

