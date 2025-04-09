using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for Pos_Popup_WPF.xaml
    /// </summary>
    public partial class Pos_Popup_WPF : Window
    {
        public Pos_Popup_WPF()
        {
            InitializeComponent();
            Pos_Tab.SelectedIndex = 0;
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ForPlaceHolder_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Alphabetic_Keyboard_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void Numeric_Keyboard_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void MessageInformation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void KeyboardButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Percent_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RichTextBox_Alphabetic_Keyboard_Click(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
