using System.Collections.ObjectModel;
using Xamarin.Forms.Parallax.Models;

namespace Xamarin.Forms.Parallax.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<ParallaxItem> Items { get; set; }

        public override void OnAppearing()
        {
            base.OnAppearing();
            CreateItems();
        }

        private void CreateItems()
        {
            Items = new()
            {
                new()
                {
                    Name = "Paris",
                    BackgroundImage = "france_bg.jpeg",
                    Image = "france.png"
                },
                new()
                {
                    Name = "Iceland",
                    BackgroundImage = "iceland_bg.jpeg",
                    Image = "iceland.png"
                },
                new()
                {
                    Name = "Rio",
                    BackgroundImage = "rio_bg.jpeg",
                    Image = "rio.png"
                }
            };

            OnPropertyChanged(nameof(Items));
        }
    }
}