using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SfDataGridDemo.Behaviors {
    class TextBoxEx {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
        typeof(TextBoxEx), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args) {
            TextBox textBox = depObj as TextBox;
            if (textBox != null) {
                textBox.TextChanged += textBox_TextChanged;
            }
        }

        static void textBox_TextChanged(object sender, TextChangedEventArgs e) {
            TextBox textBox = (sender as TextBox);
            if (textBox != null) {
                ICommand command = textBox.GetValue(CommandProperty) as ICommand;
                if (command != null) {
                    command.Execute(textBox.Text);
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
