using System;
using System.Windows.Controls;

namespace WPFSample.WPFUserControls
{
    /// <summary>
    /// Interaction logic for CustomCalendar1.xaml
    /// </summary>
    public partial class CustomCalendar1 : UserControl
    {
        public event EventHandler<DateTime?> DateSelected;

        public DateTime? SelectedDate { get; private set; }

        public CustomCalendar1()
        {
            InitializeComponent();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is Calendar calendar && calendar.SelectedDate.HasValue)
            {
                SelectedDate = calendar.SelectedDate.Value;
                DateSelected?.Invoke(this, SelectedDate);
            }
        }
    }
}
