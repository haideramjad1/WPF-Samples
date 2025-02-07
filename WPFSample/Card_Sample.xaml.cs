using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


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

        // cards code
        private int currentprofile = 0;


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
            Items.Add(new Item { Name = "New Item long text for testing purpose to show what will happen", Quantity = 1, UnitPrice = 10, ENTN = 1 });
        }

        private void ScrollViewer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Capture the touch or mouse starting point
            _startPoint = e.GetPosition(dataGrid);
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

        // Helper method to find the ScrollViewer inside the DataGrid
        private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                {
                    return (T)child;
                }

                var result = FindVisualChild<T>(child);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
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


        // Cards code
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int index = (int)slider.Value;

            switch (index)
            {
                case 0:
                    grid0.Height = 280;
                    bord0.Height = 280;
                    grid1.Height = 250;
                    bord1.Height = 250;
                    grid2.Height = 250;
                    bord2.Height = 250;
                    currentprofile = 0;
                    elips0.Visibility = Visibility.Visible;
                    elips1.Visibility = Visibility.Collapsed;
                    elips2.Visibility = Visibility.Collapsed;
                    stackPanel.UpdateLayout();
                    break;

                case 1:
                    grid0.Height = 250;
                    bord0.Height = 250;
                    grid1.Height = 280;
                    bord1.Height = 280;
                    grid2.Height = 250;
                    bord2.Height = 250;
                    currentprofile = 1;
                    elips0.Visibility = Visibility.Collapsed;
                    elips1.Visibility = Visibility.Visible;
                    elips2.Visibility = Visibility.Collapsed;
                    stackPanel.UpdateLayout();
                    break;

                case 2:
                    grid0.Height = 250;
                    bord0.Height = 250;
                    grid1.Height = 250;
                    bord1.Height = 250;
                    grid2.Height = 280;
                    bord2.Height = 280;
                    currentprofile = 2;
                    elips0.Visibility = Visibility.Collapsed;
                    elips1.Visibility = Visibility.Collapsed;
                    elips2.Visibility = Visibility.Visible;
                    stackPanel.UpdateLayout();
                    break;
            }
        }

        private void PrevBtn_Click(object sender, RoutedEventArgs e)
        {
            currentprofile++;
            if (currentprofile < 0)
            {
                currentprofile = 2;
            }
            slider.Value = currentprofile;
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            currentprofile++;
            if (currentprofile > 2)
            {
                currentprofile = 0;
            }
            slider.Value = currentprofile;
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
        public double ENTN { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
