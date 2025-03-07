using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for UserManager1.xaml
    /// </summary>
    public partial class UserManager1 : Window
    {
        private double buttonHeight = 70;

        public UserManager1()
        {
            InitializeComponent();
            AdjustWindowHeight();
            ReorderButtons();
        }

        private void AdjustWindowHeight()
        {
            // Count visible buttons
            int visibleButtons = ButtonGrid.Children.OfType<Button>().Count(b => b.Visibility == Visibility.Visible);

            // Calculate rows based on 4 columns
            int rows = (int)Math.Ceiling(visibleButtons / 4.0);
            double newHeight = (rows * buttonHeight) + 180; // Additional height for the header

            // Apply new height
            this.Height = newHeight;
        }

        private void ReorderButtons()
        {
            var visibleButtons = ButtonGrid.Children.OfType<Button>()
                                                   .Where(b => b.Visibility == Visibility.Visible)
                                                   .ToList();

            ButtonGrid.Children.Clear();

            // Ensure color variation while repositioning buttons
            string[] styles = new string[]
            {
                "ManagerRedButtonStyle",
                "ManagerBlueButtonStyle",
                "ManagerGreenButtonStyle",
                "DarkBlueButtonStyle",
                "OrangeButtonStyle"
            };

            for (int i = 0; i < visibleButtons.Count; i++)
            {
                visibleButtons[i].Style = (Style)FindResource(styles[i % styles.Length]);
                visibleButtons[i].MinHeight = buttonHeight; // Ensure min height is applied
                ButtonGrid.Children.Add(visibleButtons[i]);
            }
        }


        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
