using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;

namespace SimpleChat.UI;

[Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/AppTheme", NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
public class StartActivity : MvxStartActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    }
}