using Prism.Events;
using Prism.Windows.Mvvm;
using PrismBasicsDemo.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace PrismBasicsDemo.ViewModels {
    public class AppShellViewModel : ViewModelBase {
        private IEventAggregator eventAggregator;
        private BackgroundSubscriber subscriber;


        public AppShellViewModel() {
            this.eventAggregator = App.Current.Container.Resolve(typeof(EventAggregator), "EventAggregator") as EventAggregator; ;

            // Subscribe to TitleChangedEvent always on UI Thread
            this.eventAggregator.GetEvent<TitleChangedEvent>().Subscribe(HandleTitleChangedEvent, ThreadOption.UIThread);
        }

        private void HandleTitleChangedEvent(string title) {
            Title = title;
        }

        private string title;
        public string Title {
            get { return title; }
            set { SetProperty<string>(ref title, value); }
        }
    }
}
