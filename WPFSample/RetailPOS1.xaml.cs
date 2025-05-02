using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        private int currentQuantity = 10000;
        private int currentUnitPrice = 10000;
        private int currentItemIndex = 1;

        private const int PageSize = 12;
        private int currentPage = 0;

        public ObservableCollection<string> CategoryButtons { get; set; }
        public ObservableCollection<string> PagedCategoryButtons { get; set; } = new ObservableCollection<string>();

        public int TotalPages => (int)Math.Ceiling((double)CategoryButtons.Count / PageSize);
        public int TotalPagesMinusOne => TotalPages - 1;

        private int lastPageIndex = -1;

        private int _currentPage;
        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                if (value >= 0 && value < TotalPages)
                {
                    _currentPage = value;
                    UpdatePagedButtons();
                }
            }
        }

        public GridLength ScrollColumnWidth => TotalPages > 1 ? new GridLength(30) : new GridLength(0);

        public double ThumbHeight
        {
            get
            {
                // Get the actual height of the slider after layout
                double availableHeight = PageScrollSlider.ActualHeight;

                if (availableHeight == 0)
                {
                    return 30; // Fallback value in case ActualHeight is zero for some reason
                }

                // Calculate the thumb height based on the number of pages
                double calculatedThumbHeight = availableHeight / TotalPages;

                // Ensure the thumb height doesn't shrink too much or grow too large
                double minThumbHeight = 30;
                double maxThumbHeight = availableHeight * 0.4; // Limit to 40% of the available height

                double thumbHeight = Math.Max(minThumbHeight, Math.Min(maxThumbHeight, calculatedThumbHeight));

                return thumbHeight;
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ObservableCollection<string> ProductsButtons { get; set; } = new ObservableCollection<string>
        {
            "product 1      product 1.1", "product 2        product 2.1", "product 3        product 3.1",
            "product 4        product 4.1", "product 5       product 5.1",
            "product 6", "product 7", "product 8", "product 9", "product 10",
            "product 11", "product 12", "product 13", "product 14", "product 15",
            "product 16", "product 17", "product 18", "product 19", "product 20",
            "product 21", "product 22", "product 23", "product 24", "product 25",
            "product 16", "product 17", "product 18", "product 19", "product 20",
            "product 21", "product 22", "product 23", "product 24", "product 25",
        };

        public double ScaleFactor { get; set; }

        private DispatcherTimer scrollTimer;
        private bool isScrollingDown;


        public RetailPOS1()
        {
            InitializeComponent();

            // Initialize Data Collection
            Items = new ObservableCollection<Items>();

            // Bind DataGrid to ObservableCollection
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
                "Non Grocery3", "Drinks3", "Snacks3", "LCDs3", "Bottle3"
            };

            UpdatePagedButtons();

            DataContext = this;

            PageScrollSlider.LayoutUpdated += PageScrollSlider_LayoutUpdated;

            double width = SystemParameters.PrimaryScreenWidth;
            ScaleFactor = width <= 1024 ? 0.8 : 1.0;
            DataContext = this; // So XAML can bind to ScaleFactor

            scrollTimer = new DispatcherTimer();
            scrollTimer.Interval = TimeSpan.FromMilliseconds(150); // Adjust speed
            scrollTimer.Tick += ScrollTimer_Tick;
        }

        private void EyeButton_Click(object sender, RoutedEventArgs e)
        {
            GridView_And_Total.Visibility = Visibility.Visible;
            Products_Grid.Visibility = Visibility.Hidden;
        }

        private void PageScrollSlider_LayoutUpdated(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(ThumbHeight)); // This ensures the thumb height gets updated.
        }


        private void ForPlaceHolder_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

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
        }

        //private void CategoryButton_Click(object sender, RoutedEventArgs e)
        //{
        //    GridView_And_Total.Visibility = Visibility.Hidden;
        //    Products_Grid.Visibility = Visibility.Visible;

        //    // Assuming ButtonGrid is inside a ScrollViewer
        //    ButtonGrid.Children.Clear();

        //    // No paging now, just iterate all products
        //    foreach (var product in ProductsButtons)
        //    {
        //        StackPanel stackPanel = new StackPanel { Orientation = Orientation.Vertical };

        //        TextBlock textBlock = new TextBlock
        //        {
        //            Text = product,
        //            TextWrapping = TextWrapping.Wrap,
        //            Margin = new Thickness(5),
        //            FontFamily = new FontFamily("Tahoma"),
        //            FontSize = 20,
        //            TextTrimming = TextTrimming.CharacterEllipsis,
        //            HorizontalAlignment = HorizontalAlignment.Center,
        //            VerticalAlignment = VerticalAlignment.Center,
        //        };

        //        Button button = new Button
        //        {
        //            Tag = product,
        //            Margin = new Thickness(5),
        //            Content = textBlock,
        //            Style = (Style)FindResource("CustomerOrProductButtonStyle")
        //        };

        //        button.Click += Product_Click;

        //        ButtonGrid.Children.Add(button);
        //    }


        //}

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            GridView_And_Total.Visibility = Visibility.Hidden;
            Products_Grid.Visibility = Visibility.Visible;

            ButtonGrid.Children.Clear();

            double buttonWidth = (ButtonGrid.ActualWidth / 5) - 15;

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
                    Height = 110,
                    Width = buttonWidth,
                    Style = (Style)FindResource("RefundButtonStyle"),
                    Margin = new Thickness(5),
                };

                button.Click += Product_Click;

                ButtonGrid.Children.Add(button);
            }
        }


        private void Product_Click(object sender, RoutedEventArgs e)
        {
            //Items.Add(new Items
            var newItem = new Items
            {
                Name = $"New Item {currentItemIndex} text for testing purpose to show",
                Quantity = currentQuantity,
                UnitPrice = currentUnitPrice
            };

            Items.Add(newItem);

            // Increment values
            currentQuantity += 1;
            currentUnitPrice += 1;
            currentItemIndex += 1;

            GridView_And_Total.Visibility = Visibility.Visible;
            Products_Grid.Visibility = Visibility.Hidden;

            dataGrid.SelectedItem = newItem;
            dataGrid.ScrollIntoView(newItem);
        }

        private void UpdatePagedButtons()
        {
            PagedCategoryButtons.Clear();

            var pagedItems = CategoryButtons.Skip(CurrentPage * PageSize).Take(PageSize).ToList();

            foreach (var item in pagedItems)
                PagedCategoryButtons.Add(item);

            while (PagedCategoryButtons.Count < PageSize)
                PagedCategoryButtons.Add(""); // or " " if needed

            OnPropertyChanged(nameof(ThumbHeight));
            OnPropertyChanged(nameof(TotalPages));
            OnPropertyChanged(nameof(ScrollColumnWidth));

        }

        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            if (isScrollingDown)
                BottomButton_Click(null, null);
            else
                TopButton_Click(null, null);
        }


        private void TopButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage > 0)
            {
                CurrentPage--;  // Decrement the page
                UpdatePagedButtons();  // Update the displayed buttons
                PageScrollSlider.Value = CurrentPage;  // Update the slider position
            }
        }

        private void BottomButton_Click(object sender, RoutedEventArgs e)
        {
            if ((CurrentPage + 1) * PageSize < CategoryButtons.Count)
            {
                CurrentPage++;  // Increment the page
                UpdatePagedButtons();  // Update the displayed buttons
                PageScrollSlider.Value = CurrentPage;  // Update the slider position
            }
        }

        private void TopButton_HoldStart(object sender, MouseButtonEventArgs e)
        {
            isScrollingDown = false;
            TopButton_Click(null, null);
            scrollTimer.Start();
        }

        private void BottomButton_HoldStart(object sender, MouseButtonEventArgs e)
        {
            isScrollingDown = true;
            BottomButton_Click(null, null);
            scrollTimer.Start();
        }

        private void Scroll_HoldStop(object sender, MouseEventArgs e)
        {
            scrollTimer.Stop();
        }



        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            //if (sender is Button btn)
            //{
            //    var content = btn.Content as string;
            //    if (string.IsNullOrWhiteSpace(content))
            //    {
            //        btn.Visibility = Visibility.Collapsed; // Hides the button completely
            //    }
            //    else
            //    {
            //        btn.Visibility = Visibility.Visible;
            //    }
            //}

            if (sender is Button btn)
            {
                if (btn.Content is string contentStr)
                {
                    btn.Visibility = string.IsNullOrWhiteSpace(contentStr) ? Visibility.Collapsed : Visibility.Visible;
                }
                else
                {
                    btn.Visibility = Visibility.Visible; // assume valid if not a string
                }
            }
        }

        private void PageScrollSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Convert slider value to integer page index
            int newPageIndex = (int)(e.NewValue);

            // Only update if user crossed into a new page
            if (newPageIndex != lastPageIndex && newPageIndex >= 0 && newPageIndex < TotalPages)
            {
                CurrentPage = newPageIndex;
                lastPageIndex = newPageIndex;
            }
        }
    }
}
