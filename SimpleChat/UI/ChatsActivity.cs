using _Microsoft.Android.Resource.Designer;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using SimpleChat.Core.ViewModels.Chats;

namespace SimpleChat.UI;

[Activity(ScreenOrientation = ScreenOrientation.Portrait, LaunchMode = LaunchMode.SingleTask)]
public class ChatsActivity : MvxActivity<ChatsViewModel>
{
    public override void OnCreate(Bundle? savedInstanceState, PersistableBundle? persistentState)
    {
        base.OnCreate(savedInstanceState, persistentState);
        SetContentView(ResourceConstant.Layout.activity_chats);
    }
}