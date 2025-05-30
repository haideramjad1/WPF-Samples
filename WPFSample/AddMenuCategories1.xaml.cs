using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for AddMenuCategories1.xaml
    /// </summary>
    public partial class AddMenuCategories1 : Window
    {
        public AddMenuCategories1()
        {
            InitializeComponent();
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Alphabetic_Keyboard_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void MessageInformation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddAsParentCategory_CheckEdit_Checked(object sender, RoutedEventArgs e)
        {
            ParentCategoryRow.RowDefinitions[6].Height = new GridLength(2, GridUnitType.Star);
            ParentCategory.Visibility = Visibility.Visible;
            this.Height = 500;
        }

        private void AddAsParentCategory_CheckEdit_Unchecked(object sender, RoutedEventArgs e)
        {
            ParentCategoryRow.RowDefinitions[6].Height = new GridLength(0, GridUnitType.Star);
            ParentCategory.Visibility = Visibility.Collapsed;
            this.Height = 407;
        }

        private void ParentCategory_ComboEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ForPlaceHolder_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
