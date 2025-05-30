using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for CashEntry1.xaml
    /// </summary>
    public partial class CashEntry1 : Window
    {
        public CashEntry1()
        {
            InitializeComponent();
        }

        private void Cash_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckLabel != null && CheckTextBox != null)
            {
                CheckLabel.Visibility = Visibility.Hidden;
                CheckTextBox.Visibility = Visibility.Hidden;
                Check_TextEdit.Clear();
            }
        }

        private void Check_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            CheckLabel.Visibility = Visibility.Visible;
            CheckTextBox.Visibility = Visibility.Visible;
        }

        private void ForPlaceHolder_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextEdit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TextEdit_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Numeric_Keyboard_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void MessageInformation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Alphabetic_Keyboard_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void LookupEdit_ComboEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RichTextBox_Alphabetic_Keyboard_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
