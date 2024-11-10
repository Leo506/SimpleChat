using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;
using SimpleChat.Core;

namespace SimpleChat.Android;

[Application]
public class AndroidApp(IntPtr javaReference, JniHandleOwnership transfer) : MvxAndroidApplication<Setup, App>(javaReference, transfer)
{
    
}