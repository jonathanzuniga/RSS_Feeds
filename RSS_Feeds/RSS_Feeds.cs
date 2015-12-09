using System;
using Xamarin.Forms;

namespace RSS_Feeds
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application.
			var tabbedPage = new TabbedPage { Title = "Noticias recientes" };

			tabbedPage.Children.Add(new RssFeedView(@"http://www.frontera.info/rss/rss.xml", "Frontera"));
			tabbedPage.Children.Add(new RssFeedView(@"http://www.el-mexicano.com.mx/rss/ultimasnoticiasrss.xml", "El Mexicano"));
			tabbedPage.Children.Add(new RssFeedView(@"http://www.oem.com.mx/ElSoldeTijuana/rss/rss_mexico.xml", "El Sol de Tijuana"));
			tabbedPage.Children.Add(new RssFeedView(@"http://eluniversal.com.mx/rss.xml", "El Universal"));
			tabbedPage.Children.Add(new RssFeedView(@"http://siglo21.com.mx/index.php/industry-report?format=feed&amp;type=rss", "Siglo 21 Industry Report"));

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
