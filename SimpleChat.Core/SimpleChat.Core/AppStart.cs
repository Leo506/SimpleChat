using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SimpleChat.Core.ViewModels.Chats;

namespace SimpleChat.Core;

public class AppStart(IMvxApplication application, IMvxNavigationService navigationService)
    : MvxAppStart(application, navigationService)
{
    protected override Task NavigateToFirstViewModel(object? hint = null)
    {
        return NavigationService.Navigate<ChatsViewModel>();
    }
}