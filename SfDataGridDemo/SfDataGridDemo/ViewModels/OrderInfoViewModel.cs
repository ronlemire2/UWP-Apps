using Prism.Mvvm;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Primitives;

namespace SfDataGridDemo.ViewModels {
    public class OrderInfoViewModel : BindableBase {
        public Popup CustomChooser { get; set; }

        #region Constructors

        public OrderInfoViewModel() {

            this.CustomChooser = new Popup();
            comboBoxItemsSource = styleName.ToList();
            PasteOptions.Add(GridPasteOption.None);
            PasteOptions.Add(GridPasteOption.PasteData);
            PasteOptions.Add(GridPasteOption.ExcludeFirstLine);
            CopyOptions.Add(GridCopyOption.None);
            CopyOptions.Add(GridCopyOption.CopyData);
            CopyOptions.Add(GridCopyOption.CutData);
            CopyOptions.Add(GridCopyOption.IncludeHeaders);
            CopyOptions.Add(GridCopyOption.IncludeFormat);
        }

        #endregion


        #region Properties

        private List<OrderViewModel> orderVMs;
        public List<OrderViewModel> OrderVMs {
            get { return orderVMs; }
            set { orderVMs = value; }
        }

        private List<OrderViewModel> orderDetailVMs;
        public List<OrderViewModel> OrderDetailVMs {
            get { return orderDetailVMs; }
            set { orderDetailVMs = value; }
        }

        private List<string> comboBoxItemsSource;
        public List<string> ComboBoxItemsSource {
            get { return comboBoxItemsSource; }
            set { comboBoxItemsSource = value; }
        }

        private List<GridCopyOption> copyOptions = new List<GridCopyOption>();
        public List<GridCopyOption> CopyOptions {
            get { return copyOptions; }
            set {
                SetProperty<List<GridCopyOption>>(ref copyOptions, value);
            }
        }

        private List<GridPasteOption> pasteOptions = new List<GridPasteOption>();
        public List<GridPasteOption> PasteOptions {
            get { return pasteOptions; }
            set {
                SetProperty<List<GridPasteOption>>(ref pasteOptions, value);
            }
        }

        private bool showColumnChooser = true;
        public bool ShowColumnChooser {
            get {
                return showColumnChooser;
            }
            set {
                SetProperty<bool>(ref showColumnChooser, value);
            }
        }

        private bool useDefaultColumnChooser = true;
        public bool UseDefaultColumnChooser {
            get {
                return useDefaultColumnChooser;
            }
            set {
                SetProperty<bool>(ref useDefaultColumnChooser, value);
            }
        }

        private bool useCustomColumnChooser = false;
        public bool UseCustomColumnChooser {
            get {
                return useCustomColumnChooser;
            }
            set {
                SetProperty<bool>(ref useCustomColumnChooser, value);
            }
        }

        string[] styleName = new string[]
        {
            "Windows7",
            "Metro",
            "Blend",
            "GlassyGreen",
            "Office2007Black",
            "Office2007Blue",
            "Office2007Silver",
            "Office2010Black",
            "Office2010Blue",
            "Office2010Silver"
        };

        #endregion

        #region Delegate Command

        //public DelegateCommand<object> _ColumnChooserCommand;

        /// <summary>
        /// Gets the column chooser command.
        /// </summary>
        /// <value>The column chooser command.</value>
        //public DelegateCommand<object> ColumnChooserCommand
        //{
        //    get { return _ColumnChooserCommand; }
        //    set
        //    {
        //        _ColumnChooserCommand = value;
        //        RaisePropertyChanged("ColumnChooserCommand");
        //    }
        //}

        #endregion
    }
}
