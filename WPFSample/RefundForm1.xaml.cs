using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for RefundForm1.xaml
    /// </summary>
    public partial class RefundForm1 : Window
    {
        public ObservableCollection<Items> Items { get; set; }

        public RefundForm1()
        {
            InitializeComponent();

            // Initialize Data Collection
            Items = new ObservableCollection<Items>();

            // Bind DataGrid to ObservableCollection
            DataContext = this;
        }

        private void DoneBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Items item)
            {
                Items.Remove(item);
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Items.Add(new Items { Name = "New Item long text for testing purpose to show what will happen to the long text if it is provided", Quantity = 10000, UnitPrice = 10000 });
        }
    }

    // Data Model with Auto-Update for Subtotal
    public class Items : INotifyPropertyChanged
    {
        private int _quantity;

        public string Name { get; set; }
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
                OnPropertyChanged("Subtotal"); // Auto-update subtotal
            }
        }
        public double UnitPrice { get; set; }
        public double Subtotal => Quantity * UnitPrice; // Auto-calculated
        public double ENTN { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
