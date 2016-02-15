using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace ScreenshotViewer.ViewModels {
    public class ScreenshotViewModel : ValidatableBindableBase {
        private int id;
        public int Id {
            get { return id; }
            set { SetProperty<int>(ref id, value); }
        }

        private string name;
        public string Name {
            get { return name; }
            set { SetProperty<string>(ref name, value); }
        }

        private string description;
        public string Description {
            get { return description; }
            set { SetProperty<string>(ref description, value); }
        }

        private string imagePath;
        public string ImagePath {
            get { return imagePath; }
            set { SetProperty<string>(ref imagePath, value); }
        }

        private string repository;
        public string Repository {
            get { return repository; }
            set { SetProperty<string>(ref repository, value); }
        }

        private string app;
        public string App {
            get { return app; }
            set { SetProperty<string>(ref app, value); }
        }

        private string notes;
        public string Notes {
            get { return notes; }
            set { SetProperty<string>(ref notes, value); }
        }

        public ImageSource ScreenshotImage {
            get {
                // ImagePath contains a path of the form "Mvvm1.png".
                return new BitmapImage(new Uri(new Uri("ms-appdata:///local/"), this.ImagePath));
            }
        }
    }
}
