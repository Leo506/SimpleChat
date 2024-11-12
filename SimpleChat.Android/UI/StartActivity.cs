using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;

namespace SimpleChat.Android.UI;

[Activity(Label = "@string/app_name", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
public class StartActivity : MvxStartActivity;