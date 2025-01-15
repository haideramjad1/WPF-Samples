using System.Windows;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Increment = 0;

        public MainWindow()
        {
            InitializeComponent();

            //// Get the screen dimensions
            //var screenWidth = SystemParameters.PrimaryScreenWidth;
            //var screenHeight = SystemParameters.PrimaryScreenHeight;

            //// Set window position
            //this.Left = screenWidth - this.Width; // Align to the right edge
            //this.Top = screenHeight - this.Height - 40; // Align to the bottom edge
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Increment = Increment + 1;
            if (Increment > 3)
            {
                Increment = 1;
            }
            switch (Increment)
            {
                case 1:
                    Label_Message.Text = " This is some random message ";
                    break;
                case 2:
                    Label_Message.Text = " This is some random message which is used to define long text alignments ";
                    break;
                case 3:
                    Label_Message.Text = " This is some random message which is used to define long text alignments " +
                        "and to check if the form size increases or just the text wrap works";
                    break;
                default:
                    Label_Message.Text = " This is some random message ";
                    break;

            }

        }
    }
}
