using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for Attendence1.xaml
    /// </summary>
    public partial class Attendence1 : Window
    {
        public Attendence1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var workArea = SystemParameters.WorkArea;

            this.Left = workArea.Left;
            this.Top = workArea.Top;
            this.Width = workArea.Width;
            this.Height = workArea.Height;

            Pin_Password.Focus();
        }

        private void Close_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EyeButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button button)
            {
                var closedBrush = FindResource("ClosedEyeImageBrush") as ImageBrush;
                var openBrush = FindResource("OpenEyeImageBrush") as ImageBrush;

                if (button.Tag == closedBrush)
                {
                    button.Tag = openBrush;

                    Pin_TextEdit.Text = Pin_Password.Password;
                    Pin_Password.Clear();

                    Pin_TextEdit.Visibility = Visibility.Visible;
                    Pin_Password.Visibility = Visibility.Hidden;
                    TextBoxFocus();
                }
                else
                {
                    button.Tag = closedBrush;

                    Pin_Password.Password = Pin_TextEdit.Text;
                    Pin_TextEdit.Clear();

                    Pin_TextEdit.Visibility = Visibility.Hidden;
                    Pin_Password.Visibility = Visibility.Visible;
                    TextBoxFocus();
                }
            }
        }

        private void TextBoxFocus()
        {
            if (Pin_TextEdit.Visibility == Visibility.Visible)
            {
                Pin_TextEdit.CaretIndex = Pin_TextEdit.Text.Length;
                Pin_TextEdit.Focus();
            }

            else if (Pin_Password.Visibility == Visibility.Visible)
                Pin_Password.Focus();
        }

        private void pin_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Pin_Tabs != null)
            {
                Pin_Tabs.SelectedItem = Pin_Tab;
                TextBoxFocus();
            }
        }

        private async void card_radioButton_Checked(object sender, RoutedEventArgs e)
        {
            Pin_Tabs.SelectedItem = Card_Tab;
            await SetGifAsync();
            TextBoxFocus();
        }

        private async Task SetGifAsync()
        {

            //var bitmap = new BitmapImage();
            //bitmap.BeginInit();
            //bitmap.UriSource = new Uri("/Resources/scan_card_gif1.gif");
            //bitmap.EndInit();
            //Scan_Image.Source = bitmap;
        }
    }
}
