using Android.Views;

namespace SimpleChat.Android.UI.Extensions;

public static class ViewExtensions
{
    public static TView SetOnClickListener<TView>(this TView view, Action onClick) where TView : View
    {
        view.SetOnClickListener(new OnClickListener(onClick));
        return view;
    }

    
}