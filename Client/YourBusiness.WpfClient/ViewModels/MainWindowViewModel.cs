using Prism.Events;
using Prism.Mvvm;
using YourBusiness.WpfClient.Events;

namespace YourBusiness.WpfClient.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IEventAggregator _events;

        public MainWindowViewModel(IEventAggregator aggregator)
        {
            Title = "Your-Business Benutzeroberfläche (WPF) v1.0.0";
            IsBusy = false;
            CurrentStatus = "Ready.";
            _events = aggregator;
            _events.GetEvent<IsBusyChangedEvent>().Subscribe(OnIsBusyChanged);
        }

        private void OnIsBusyChanged(IsBusyChangedEventArgs args)
        {
            IsBusy = args.IsBusy;
            CurrentStatus = IsBusy ? args.Reason : "Ready.";
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _currentStatus;

        public string CurrentStatus
        {
            get { return _currentStatus; }
            set { SetProperty(ref _currentStatus, value); }
        }

        private bool _loggedIn;

        public bool IsLoggedIn
        {
            get { return _loggedIn; }
            set { SetProperty(ref _loggedIn, value); }
        }
    }
}