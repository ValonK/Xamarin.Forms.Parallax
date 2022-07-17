using System;
using PanCardView;
using PanCardView.EventArgs;
using Xamarin.Essentials;
using Xamarin.Forms.Parallax.ViewModels;

namespace Xamarin.Forms.Parallax.Pages
{
    public partial class MainPage
    {
        private Image _currentImage;
        private float _previousXReading;
        private const int AnimationLength = 80;
        
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

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ToggleOrientationSensor();
            OrientationSensor.ReadingChanged -= OrientationSensorOnReadingChanged;
        }

        private static void ToggleOrientationSensor()
        {
            try
            {
                if (OrientationSensor.IsMonitoring)
                {
                    OrientationSensor.Stop();
                }
                else
                {
                    OrientationSensor.Start(SensorSpeed.UI);
                }
            }
            catch (FeatureNotSupportedException)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Orientation Sensor not supported", "Cancel");
            }
            catch (Exception)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Something went wrong", "Cancel");
            }
        }
        
        private async void OrientationSensorOnReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            var xReading = e.Reading.Orientation.X;
            
            if (Math.Abs(_previousXReading - xReading) <= Math.Pow(10.0, -2)) return;
            
            _currentImage ??= GetCurrentBackgroundImage();

            await _currentImage.TranslateTo(xReading * 150, 0, AnimationLength);
            _previousXReading = xReading;
        }
        
        private Image GetCurrentBackgroundImage()
        {
            if (CarouselView.CurrentView is not ContentView {Content: Frame {Content: Grid grid}}) return null;
            return grid.Children[0] as Image;
        }

        private void CarouselView_OnItemSwiped(CardsView view, ItemSwipedEventArgs args) => _currentImage = null;
    }
}
