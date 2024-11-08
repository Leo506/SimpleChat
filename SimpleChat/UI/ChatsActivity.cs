using _Microsoft.Android.Resource.Designer;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using SimpleChat.Core.ViewModels.Chats;

namespace SimpleChat.UI;

[MvxActivityPresentation]
[Activity(ScreenOrientation = ScreenOrientation.Portrait, LaunchMode = LaunchMode.SingleTask, Theme = "@style/AppTheme")]
public class ChatsActivity : MvxActivity<ChatsViewModel>
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(ResourceConstant.Layout.activity_chats);
    }
}