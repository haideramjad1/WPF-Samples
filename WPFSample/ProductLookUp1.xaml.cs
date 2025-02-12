using System;
using System.Windows;
using System.Windows.Input;

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for ProductLookUp1.xaml
    /// </summary>
    public partial class ProductLookUp1 : Window
    {
        private Point _startPoint;
        private bool _isDragging = false;

        public ProductLookUp1()
        {
            InitializeComponent();
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CapsLock_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Shift_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void KeyboardButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Previous_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void scrollViewer_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(scrollViewer);
            _isDragging = false;  // Reset dragging state on new mouse down
        }

        private void scrollViewer_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) // Only act when the mouse button is pressed
            {
                var currentTouchPoint = e.GetPosition(scrollViewer);
                double deltaX = currentTouchPoint.X - _startPoint.X; // Calculate movement correctly

                if (Math.Abs(deltaX) > 5)  // If movement is significant, start dragging
                {
                    _isDragging = true;
                    double horizontalOffset = scrollViewer.HorizontalOffset - deltaX;  // Update horizontal offset based on mouse movement

                    // Ensure the offset is within valid bounds
                    horizontalOffset = Math.Max(0, Math.Min(horizontalOffset, scrollViewer.ScrollableWidth));

                    scrollViewer.ScrollToHorizontalOffset(horizontalOffset);
                    _startPoint = currentTouchPoint;  // Update start point for smooth dragging

                    e.Handled = true;  // Mark event as handled to avoid button click
                }
            }
        }


        private void scrollViewer_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _isDragging = false;  // Reset dragging state on mouse up
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_isDragging) return; // Ignore button clicks while dragging

            var button = sender as System.Windows.Controls.Button;
            if (button != null)
            {
                string task = button.Tag.ToString();
                MessageBox.Show($"You clicked {button.Content}. Performing {task}!");
            }
        }

    }
}
