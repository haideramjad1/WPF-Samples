using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace WPFSample.Splash_screens
{
    /// <summary>
    /// Interaction logic for Loading_screen1.xaml
    /// </summary>
    public partial class Loading_screen1 : Window
    {
        //private Storyboard _spinnerStoryboard;

        public Loading_screen1()
        {
            InitializeComponent();
        }

        //public void StartLoadingAnimation()
        //{
        //    var rotate1 = new DoubleAnimation
        //    {
        //        From = 0,
        //        To = 360,
        //        Duration = TimeSpan.FromSeconds(2),
        //        RepeatBehavior = RepeatBehavior.Forever
        //    };
        //    rotateTransform1.BeginAnimation(RotateTransform.AngleProperty, rotate1);

        //    var rotate2 = new DoubleAnimation
        //    {
        //        From = 360,
        //        To = 0, // Rotate in opposite direction
        //        Duration = TimeSpan.FromSeconds(2),
        //        RepeatBehavior = RepeatBehavior.Forever
        //    };
        //    rotateTransform2.BeginAnimation(RotateTransform.AngleProperty, rotate2);
        //}

        //public void FadeIn()
        //{
        //    var fadeInAnimation = new DoubleAnimation
        //    {
        //        From = 0,
        //        To = 1,
        //        Duration = TimeSpan.FromSeconds(1)
        //    };
        //    this.BeginAnimation(Window.OpacityProperty, fadeInAnimation);
        //}

        //public void FadeOut()
        //{
        //    var fadeOutAnimation = new DoubleAnimation
        //    {
        //        From = 1,
        //        To = 0,
        //        Duration = TimeSpan.FromSeconds(1)
        //    };
        //    fadeOutAnimation.Completed += (s, e) => this.Close();
        //    this.BeginAnimation(Window.OpacityProperty, fadeOutAnimation);
        //}


        public void FadeIn()
        {
            var fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(500));
            this.BeginAnimation(Window.OpacityProperty, fadeIn);
        }

        public void FadeOut()
        {
            var fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(500));
            fadeOut.Completed += (s, e) => this.Close();
            this.BeginAnimation(Window.OpacityProperty, fadeOut);
        }

        public void StartLoadingAnimation()
        {
            //_spinnerStoryboard?.Begin();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var workArea = SystemParameters.WorkArea;

            this.Left = workArea.Left;
            this.Top = workArea.Top;
            this.Width = workArea.Width;
            this.Height = workArea.Height;
        }
    }
}
