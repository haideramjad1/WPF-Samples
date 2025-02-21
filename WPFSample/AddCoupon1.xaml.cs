using System.Windows;
using System.Windows.Controls;

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

        //private void OpenCustomCalendar(DatePicker datePicker)
        //{
        //    CustomCalendar customCalendar = new CustomCalendar();
        //    if (customCalendar.ShowDialog() == true)
        //    {
        //        //if (customCalendar.SelectedDate.HasValue)
        //        //{
        //        //    datePicker.SelectedDate = customCalendar.SelectedDate.Value;
        //        //}

        //        // When the user selects a date in the custom calendar
        //        if (customCalendar.SelectedDate.HasValue)
        //        {
        //            // Update the DatePicker's SelectedDate with the value from the custom calendar
        //            datePicker.SelectedDate = customCalendar.SelectedDate.Value;
        //        }
        //    }
        //}

        private void OpenCustomCalendar(DatePicker datePicker)
        {
            CalendarPopup.IsOpen = true;

            CustomCalendarPopup.DateSelected += (sender, selectedDate) =>
            {
                if (selectedDate.HasValue)
                {
                    datePicker.SelectedDate = selectedDate.Value;
                }
                CalendarPopup.IsOpen = false;
            };
        }


        private T GetTemplateChild<T>(Control parent, string childName) where T : DependencyObject
        {
            return parent.Template.FindName(childName, parent) as T;
        }

        private void DOB_DateEdit_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is DatePicker datePicker)
            {
                Button calendarButton = GetTemplateChild<Button>(datePicker, "PART_Button");
                if (calendarButton != null)
                {
                    calendarButton.Click += (s, args) => OpenCustomCalendar(datePicker);
                }
            }
        }
    }
}
