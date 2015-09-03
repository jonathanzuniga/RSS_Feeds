using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RSS_Feeds
{
	public class RssFeedViewModel : BaseViewModel
	{
		private readonly RssFeedService service;

		public RssFeedViewModel(string url)
		{
			this.service = new RssFeedService(url);
			Records = new ObservableCollection<RssRecordViewModel>();
			InitalizeCommands();
		}

		#region Commands

		public Command ReloadCommand { get; private set; }

		private void InitalizeCommands()
		{
			ReloadCommand = new Command(() => OnReload(), () => CanReload());
		}

		public async void OnReload()
		{
			Records.Clear();
			ShowActivityIndicator = true;

			var records = await GetRecordsAsync();

			foreach (var record in records)
				Records.Add(new RssRecordViewModel(record));

			RaisePropertyChanged("Records");
			ShowActivityIndicator = false;
		}

		public bool CanReload()
		{
			return !ShowActivityIndicator;
		}

		#endregion

		#region Properties

		private RssRecordViewModel selected;
		public RssRecordViewModel Selected
		{
			get { return selected; }
			set {
				if (selected == value)
					return;
				
				selected = value;
				RaisePropertyChanged("Selected");
			}
		}

		public ObservableCollection<RssRecordViewModel> Records { get; set; }

		#endregion

		private Task<IEnumerable<RssRecord>> GetRecordsAsync()
		{
			return Task.Factory.StartNew(() => {
				return service.GetFronteraRecords();
			});
		}
	}
}
