using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for RetailPOS1.xaml
    /// </summary>
    public partial class RetailPOS1 : Window
    {
        public ObservableCollection<Items> Items { get; set; }
        public ObservableCollection<PayeeItem> PayeeItems { get; set; }

        private double currentQuantity = 8888.99;
        private double currentUnitPrice = 8888.99;
        private int currentItemIndex = 1;

        public ObservableCollection<string> CategoryButtons { get; set; }

        public ObservableCollection<string> ProductsButtons { get; set; } = new ObservableCollection<string>
        {
            "product 1      product 1.1", "product 2        product 2.1", "product 3        product 3.1",
            "product 4        product 4.1", "product 5       product 5.1",
            "product 6", "product 7", "product 8", "product 9", "product 10",
            "product 11", "product 12", "product 13", "product 14", "product 15",
            "product 16", "product 17", "product 18", "product 19", "product 20",
            "product 21", "product 22", "product 23", "product 24", "product 25",
            "product 26", "product 27", "product 28", "product 29", "product 30",
            "product 31", "product 32", "product 33",
        };

        public double ScaleFactor { get; set; }

        public RetailPOS1()
        {
            InitializeComponent();

            Items = new ObservableCollection<Items>();
            PayeeItems = new ObservableCollection<PayeeItem>();

            DataContext = this;

            CategoryButtons = new ObservableCollection<string>
            {
                "Grocery", "Fish", "Chicken", "Vegetable", "Lamb",
                "Meat", "Produce", "Dairy", "Fruits", "Breads",
                "Non Grocery", "Drinks", "Snacks", "LCDs", "Bottle",
                "Grocery1", "Fish1", "Chicken1", "Vegetable1", "Lamb1",
                "Meat1", "Produce1", "Dairy1", "Fruits1", "Breads1",
                "Non Grocery1", "Drinks1", "Snacks1", "LCDs1", "Bottle1",
                "Grocery2", "Fish2", "Chicken2", "Vegetable2", "Lamb2",
                "Meat2", "Produce2", "Dairy2", "Fruits2", "Breads2",
                "Non Grocery2", "Drinks2", "Snacks2", "LCDs2", "Bottle2",
                "Grocery3", "Fish3", "Chicken3", "Vegetable3", "Lamb3",
                "Meat3", "Produce3", "Dairy3", "Fruits3", "Breads3",
                "Non Grocery3", "Drinks3", "Snacks3", "LCDs3", "Bottle3",
                "Non Grocery4", "Drinks4", "Snacks4", "LCDs4", "Bottle4"
            };

            DataContext = this;
            double width = SystemParameters.PrimaryScreenWidth;
            ScaleFactor = width <= 1024 ? 0.8 : 1.0;
            DataContext = this; // So XAML can bind to ScaleFactor
        }

        private void EyeButton_Click(object sender, RoutedEventArgs e)
        {
            GridView_And_Total.Visibility = Visibility.Visible;
            Products_Grid.Visibility = Visibility.Hidden;
        }

        private void ForPlaceHolder_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Scane_TextEdit.Text))
            {
                ScaneTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                ScaneTextBlock.Visibility = Visibility.Collapsed;
            }
        }

        private void Name_TextEdit_TouchUp(object sender, System.Windows.Input.TouchEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var workArea = SystemParameters.WorkArea;

            this.Left = workArea.Left;
            this.Top = workArea.Top;
            this.Width = workArea.Width;
            this.Height = workArea.Height;

            LoadCategory(null, null);
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            GridView_And_Total.Visibility = Visibility.Hidden;
            Products_Grid.Visibility = Visibility.Visible;

            ButtonGrid.Children.Clear();
            ProductScrollViewer.UpdateLayout();

            double availableWidth = ButtonGrid.ActualWidth;
            double availableHeight = ProductScrollViewer.ActualHeight;

            double buttonWidth = (availableWidth / 5) - 15;
            double buttonHeight = (availableHeight / 5) - 10;

            foreach (var product in ProductsButtons)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = product,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(5),
                    FontFamily = new FontFamily("Tahoma"),
                    FontSize = 20,
                    TextTrimming = TextTrimming.CharacterEllipsis,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };

                Button button = new Button
                {
                    Tag = product,
                    Content = textBlock,
                    Height = buttonHeight,
                    Width = buttonWidth,
                    Style = (Style)FindResource("RefundButtonStyle"),
                    Margin = new Thickness(5),
                };

                button.Click += Product_Click;

                ButtonGrid.Children.Add(button);
            }
        }

        private void ScrollOneRow(ScrollViewer scrollViewer, bool scrollDown, int height)
        {
            scrollViewer.UpdateLayout();
            double rowHeight = scrollViewer.ActualHeight / height;

            double currentOffset = scrollViewer.VerticalOffset;
            double newOffset = scrollDown
                ? currentOffset + rowHeight
                : currentOffset - rowHeight;

            newOffset = Math.Max(0, Math.Min(newOffset, scrollViewer.ScrollableHeight));
            scrollViewer.ScrollToVerticalOffset(newOffset);
        }



        private void ScrollUpButton_Click(object sender, RoutedEventArgs e)
        {
            ScrollOneRow(ProductScrollViewer, scrollDown: false, 5);
        }

        private void ScrollDownButton_Click(object sender, RoutedEventArgs e)
        {
            ScrollOneRow(ProductScrollViewer, scrollDown: true, 5);
        }

        private void TopButton_Click(object sender, RoutedEventArgs e)
        {
            ScrollOneRow(CategoriesScrollViewer, scrollDown: false, 12);
        }

        private void BottomButton_Click(object sender, RoutedEventArgs e)
        {
            ScrollOneRow(CategoriesScrollViewer, scrollDown: true, 12);
        }

        private void LoadCategory(object sender, RoutedEventArgs e)
        {
            CategoryButtonGrid.Children.Clear();
            CategoriesScrollViewer.UpdateLayout();

            double availableWidth = CategoryButtonGrid.ActualWidth;
            double availableHeight = CategoriesScrollViewer.ActualHeight;
            double buttonWidth = availableWidth;

            double totalVerticalMargin = 10; // top + bottom
            double buttonHeight = (availableHeight / 12) - totalVerticalMargin;

            foreach (var product in CategoryButtons)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = product,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(5),
                    FontFamily = new FontFamily("Tahoma"),
                    FontSize = 20,
                    TextTrimming = TextTrimming.CharacterEllipsis,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };

                Button button = new Button
                {
                    DataContext = product,
                    Content = textBlock,
                    Height = buttonHeight,
                    Width = buttonWidth,
                    Style = (Style)FindResource("ManagerBlueButtonStyle"),
                };

                button.Click += CategoryButton_Click;

                CategoryButtonGrid.Children.Add(button);
            }

            Dispatcher.InvokeAsync(() =>
            {
                bool isVerticalScrollVisible = CategoriesScrollViewer.ComputedVerticalScrollBarVisibility == Visibility.Visible;

                if (isVerticalScrollVisible)
                {
                    double scrollbarWidth = SystemParameters.VerticalScrollBarWidth;
                    double visibleWidth = CategoriesScrollViewer.ViewportWidth;
                    double newButtonWidth = visibleWidth - scrollbarWidth + 7;

                    foreach (UIElement element in CategoryButtonGrid.Children)
                    {
                        if (element is Button button)
                        {
                            button.Width = newButtonWidth;
                        }
                    }
                }
            }, DispatcherPriority.Background);
        }


        private void Product_Click(object sender, RoutedEventArgs e)
        {
            //Items.Add(new Items
            var newItem = new Items
            {
                Name = $"New Item {currentItemIndex} long text for testing purpose to show what will happen to the long text if it is provided",
                Quantity = currentQuantity,
                UnitPrice = currentUnitPrice
            };

            Items.Add(newItem);

            currentQuantity += 1;
            currentUnitPrice += 1;
            currentItemIndex += 1;

            dataGrid.SelectedItem = newItem;
            dataGrid.ScrollIntoView(newItem);

            GridView_And_Total.Visibility = Visibility.Visible;
            Products_Grid.Visibility = Visibility.Hidden;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void KeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            if (button.Content is string text)
            {
                Scane_TextEdit.Text += text;
                Scane_TextEdit.CaretIndex = Scane_TextEdit.Text.Length;
                Scane_TextEdit.Focus();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Scane_TextEdit.Text = string.Empty;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Scane_TextEdit.Text))
            {
                Product_Click(sender, e);
                Scane_TextEdit.Text = string.Empty;
            }
        }

        private void Payee_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string name = button.Content is TextBlock tb ? tb.Text : button.Content?.ToString();
                string priceText = Scane_TextEdit.Text;

                if (double.TryParse(priceText, out double parsedPrice))
                {
                    PayeeItems.Add(new PayeeItem
                    {
                        PayeeName = name,
                        PayeePrice = parsedPrice / 100,
                    });

                    Scane_TextEdit.Text = string.Empty;
                }
                else
                {
                }
            }
        }

        private ScrollViewer GetScrollViewer(DependencyObject parent)
        {
            if (parent == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is ScrollViewer viewer)
                    return viewer;

                var result = GetScrollViewer(child);
                if (result != null)
                    return result;
            }

            return null;
        }

        private void CartGridUp_Click(object sender, RoutedEventArgs e)
        {
            var scrollViewer = GetScrollViewer(dataGrid);
            scrollViewer?.LineUp();
        }

        private void CartGridDown_Click(object sender, RoutedEventArgs e)
        {
            var scrollViewer = GetScrollViewer(dataGrid);
            scrollViewer?.LineDown();
        }

        private void Money_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Content is StackPanel panel)
            {
                // Assume the second TextBlock is the numeric part
                foreach (var child in panel.Children)
                {
                    if (child is TextBlock tb && double.TryParse(tb.Text, out double value))
                    {
                        Scane_TextEdit.Text += value.ToString();
                        break;
                    }
                }
            }
        }

    }

    public class PayeeItem
    {
        public string PayeeName { get; set; }
        public double PayeePrice { get; set; }
    }
}
