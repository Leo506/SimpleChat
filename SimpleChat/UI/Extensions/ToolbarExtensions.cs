using Toolbar =  AndroidX.AppCompat.Widget.Toolbar;
namespace SimpleChat.UI.Extensions;

public static class ToolbarExtensions
{
    public static TView SetNavigationButton<TView>(this TView toolbar, int icon, Action action) where TView : Toolbar
    {
        toolbar.SetNavigationIcon(icon);
        toolbar.SetNavigationOnClickListener(new OnClickListener(action));
        return toolbar;
    }
}