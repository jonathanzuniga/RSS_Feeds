using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RSS_Feeds
{
	public class FronteraFeedViewModel : BaseViewModel
	{
		private readonly FronteraFeedService service;

		public FronteraFeedViewModel()
		{
			this.service = new FronteraFeedService();
			Records = new ObservableCollection<FronteraRecordViewModel>();
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
				Records.Add(new FronteraRecordViewModel(record));

			RaisePropertyChanged("Records");
			ShowActivityIndicator = false;
		}

		public bool CanReload()
		{
			return !ShowActivityIndicator;
		}

		#endregion

		#region Properties

		private FronteraRecordViewModel selected;
		public FronteraRecordViewModel Selected
		{
			get { return selected; }
			set {
				if (selected == value)
					return;
				
				selected = value;
				RaisePropertyChanged("Selected");
			}
		}

		public ObservableCollection<FronteraRecordViewModel> Records { get; set; }

		#endregion

		private Task<IEnumerable<FronteraRecord>> GetRecordsAsync()
		{
			return Task.Factory.StartNew(() => {
				return service.GetFronteraRecords();
			});
		}
	}
}
