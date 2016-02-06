using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SfDataGridDemo.Behaviors {
    class ComboBoxEx {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
        typeof(ComboBoxEx), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args) {
            ComboBox comboBox = depObj as ComboBox;
            if (comboBox != null) {
                comboBox.SelectionChanged += comboBox_SelectionChanged;
            }
        }

        static void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null) {
                ICommand command = comboBox.GetValue(CommandProperty) as ICommand;
                if (command != null) {
                    command.Execute(comboBox.SelectedItem);
                }
            }
        }
        public static ICommand GetCommand(UIElement element) {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command) {
            element.SetValue(CommandProperty, command);
        }
    }
}
