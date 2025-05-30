using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for login1.xaml
    /// </summary>
    public partial class login1 : Window
    {
        //private Loading_screen1 waitForm;

        public login1()
        {
            InitializeComponent();

            //// Show the wait form
            //waitForm = new Loading_screen1();
            //waitForm.Show();
            //waitForm.FadeIn();  // Apply fade-in effect

            //// Simulate work
            //Task.Run(() =>
            //{
            //    Thread.Sleep(1000); // Simulating some work
            //    Dispatcher.Invoke(() => waitForm.StartLoadingAnimation());  // Start the loading spinner

            //    Thread.Sleep(3000); // Wait for 3 seconds to simulate work

            //    Dispatcher.Invoke(() =>
            //    {
            //        waitForm.FadeOut();  // Fade out the splash screen after work is done
            //        this.Show();  // Show the main window
            //    });
            //});

            //this.Hide();  // Hide the main window until the work is done
        }

        private void Alphabetic_Keyboard_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ForPlaceHolder_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Attendance_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PinLogin_CheckEdit_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void PinLogin_CheckEdit_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void EyeButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var closedBrush = FindResource("ClosedEyeImageBrush") as ImageBrush;
                var openBrush = FindResource("OpenEyeImageBrush") as ImageBrush;

                if (button.Tag == closedBrush)
                {
                    button.Tag = openBrush;
                }
                else
                {
                    button.Tag = closedBrush;
                }
            }
        }
    }
}
