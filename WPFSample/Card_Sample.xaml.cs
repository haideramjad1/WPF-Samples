using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for Card_Sample.xaml
    /// </summary>
    public partial class Card_Sample : Window
    {
        public ObservableCollection<Item> Items { get; set; }

        private Point _startPoint;
        private bool _isDragging = false;

        public Card_Sample()
        {
            InitializeComponent();

            // Initialize Data Collection
            Items = new ObservableCollection<Item>();

            // Bind DataGrid to ObservableCollection
            DataContext = this;
        }

        private void SubButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Item item)
            {
                if (item.Quantity > 1)
                    item.Quantity--;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Item item)
            {
                item.Quantity++;
            }
        }

        private void EntnButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Item item)
            {
                MessageBox.Show($"ENTN Button Clicked for {item.Name}");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Item item)
            {
                Items.Remove(item);
            }
        }

        private void butn2_Click(object sender, RoutedEventArgs e)
        {
            Items.Add(new Item { Name = "New Item", Quantity = 1, UnitPrice = 10 });
        }

        private void ScrollViewer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Capture the touch or mouse starting point
            _startPoint = e.GetPosition(ScrollViewer);
            _isDragging = false;  // Reset the dragging state
            dataGrid.SelectedItem = null;
        }

        private void ScrollViewer_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var currentTouchPoint = e.GetPosition(ScrollViewer);
                double deltaY = _startPoint.Y - currentTouchPoint.Y;

                // Start dragging only if the movement exceeds 5 pixels
                if (!_isDragging && Math.Abs(deltaY) > 5)
                {
                    _isDragging = true;
                }

                if (_isDragging)
                {
                    double verticalOffset = ScrollViewer.VerticalOffset + deltaY;

                    // Ensure the scroll stays within bounds
                    verticalOffset = Math.Max(0, Math.Min(verticalOffset, ScrollViewer.ScrollableHeight));
                    ScrollViewer.ScrollToVerticalOffset(verticalOffset);

                    _startPoint = currentTouchPoint;  // Update reference point for smooth scrolling
                }
            }
        }

        private void ScrollViewer_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isDragging)  // If dragging is active, prevent selection change
            {
                dataGrid.SelectedItem = null;  // Deselect row during drag
            }
        }
    }

    // Data Model with Auto-Update for Subtotal
    public class Item : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
