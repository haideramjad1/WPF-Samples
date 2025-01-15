using System.Windows;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for ErrorMessageShow1.xaml
    /// </summary>
    public partial class ErrorMessageShow1 : Window
    {
        int Increment = 0;

        public ErrorMessageShow1()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Increment = Increment + 1;
            if (Increment > 3)
            {
                Increment = 1;
            }
            switch (Increment)
            {
                case 1:
                    Description_Label.Text = " This is some random message ";
                    break;
                case 2:
                    Description_Label.Text = " This is some random message which is used to define long text alignments ";
                    break;
                case 3:
                    Description_Label.Text = " This is some random message which is used to define long text alignments " +
                        "and to check if the form size increases or just the text wrap works";
                    break;
                default:
                    Description_Label.Text = " This is some random message ";
                    break;

            }
        }
    }
}
