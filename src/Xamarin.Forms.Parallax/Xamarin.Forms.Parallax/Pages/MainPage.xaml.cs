using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms.Parallax.ViewModels;

namespace Xamarin.Forms.Parallax.Pages
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            OrientationSensor.ReadingChanged += OrientationSensorOnReadingChanged;
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            if (BindingContext is MainViewModel mainViewModel)
            {
                mainViewModel.OnAppearing();
                ToggleOrientationSensor();
            }
        }
        
        public void ToggleOrientationSensor()
        {
            try
            {
                if (OrientationSensor.IsMonitoring)
                    OrientationSensor.Stop();
                else
                    OrientationSensor.Start(SensorSpeed.UI);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
        
        private async void OrientationSensorOnReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            var reading = e.Reading;
            var image = GetCurrentBackgroundImage();
            var x = reading.Orientation.X * 60;
            await image.TranslateTo(x, 0, 50);
        }
        
        private Image GetCurrentBackgroundImage()
        {
            if (CarouselView.CurrentView is not ContentView {Content: Frame {Content: Grid grid}}) return null;
            return grid.Children[0] as Image;
        }
    }
}
