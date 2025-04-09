using System.Windows;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for UpsertCategory1.xaml
    /// </summary>
    public partial class UpsertCategory1 : Window
    {
        public UpsertCategory1()
        {
            InitializeComponent();
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ForPlaceHolder_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Alphabetic_Keyboard_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void MessageInformation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextEdit_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }

        private void TextEdit_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void Numeric_Keyboard_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAsSubCategory_ComboEdit_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void AddAsSubCategory_CheckEdit_Checked(object sender, RoutedEventArgs e)
        {
            Row7Container.Visibility = Visibility.Visible;
            Row7.Height = GridLength.Auto;
        }

        private void AddAsSubCategory_CheckEdit_Unchecked(object sender, RoutedEventArgs e)
        {
            Row7Container.Visibility = Visibility.Collapsed;
            Row7.Height = new GridLength(0);
        }

        private void IsAgeRestricted_CheckEdit_Checked(object sender, RoutedEventArgs e)
        {
            Row5Container.Visibility = Visibility.Visible;
            Row5.Height = GridLength.Auto;
        }

        private void IsAgeRestricted_CheckEdit_Unchecked(object sender, RoutedEventArgs e)
        {
            Row5Container.Visibility = Visibility.Collapsed;
            Row5.Height = new GridLength(0);
        }

        private void Tax_ComboEdit_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void DeleteGridButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
