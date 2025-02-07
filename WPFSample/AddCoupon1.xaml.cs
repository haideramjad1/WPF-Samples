using System.Windows;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for AddCoupon1.xaml
    /// </summary>
    public partial class AddCoupon1 : Window
    {
        public AddCoupon1()
        {
            InitializeComponent();
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            Save_Btn.Content = "Update";
            AddAndGo_Btn.Content = "Update & Go";

            Save_Btn.MinWidth = 110;
            AddAndGo_Btn.MinWidth = 170;
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ForPlaceHolder_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void HearAboutUs_ComboEdit_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void AddAndGo_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
