using MvvmHelpers;

namespace Xamarin.Forms.Parallax.ViewModels;

public abstract class BaseViewModel : ObservableObject
{
   public virtual void OnAppearing(){}
   public virtual void OnDisappearing(){}
}