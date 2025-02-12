using System.Windows;

namespace WPFSample.WPFUserControls
{
    /// <summary>
    /// Interaction logic for RefundGridUserControl.xaml
    /// </summary>
    public partial class RefundGridUserControl : System.Windows.Controls.UserControl
    {
        public RefundGridUserControl()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
                DependencyProperty.Register("Text", typeof(string), typeof(RefundGridUserControl), new PropertyMetadata(string.Empty));

    }
}
