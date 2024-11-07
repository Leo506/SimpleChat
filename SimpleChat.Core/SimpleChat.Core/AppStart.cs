using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace SimpleChat.Core;

public class AppStart(IMvxApplication application, IMvxNavigationService navigationService)
    : MvxAppStart(application, navigationService)
{
    protected override Task NavigateToFirstViewModel(object? hint = null)
    {
        return Task.CompletedTask;
    }
}