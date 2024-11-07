using MvvmCross.ViewModels;

namespace SimpleChat.Core;

public class App : MvxApplication
{
    public override void Initialize()
    {
        RegisterCustomAppStart<AppStart>();
    }
}