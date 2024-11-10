using _Microsoft.Android.Resource.Designer;
using Android.OS;
using Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace SimpleChat.Android.UI;

[MvxActivityPresentation]
public abstract class AppActivity<TViewModel> : MvxActivity<TViewModel> where TViewModel : class, IMvxViewModel
{
    private Toolbar Toolbar => FindViewById<Toolbar>(ResourceConstant.Id.toolbar);

    protected abstract int LayoutId { get; }

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(LayoutId);
        SetupToolbar(Toolbar);
        SetSupportActionBar(Toolbar);
    }

    protected virtual void SetupToolbar(Toolbar toolbar)
    {
        
    }

    public new TView FindViewById<TView>(int id) where TView : View
    {
        return base.FindViewById<TView>(id)
            ?? throw new InvalidOperationException($"Failed to find {typeof(TView).Name} for id {id}");
    }
}