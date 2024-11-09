using Android.Content;
using Android.Util;
using AndroidX.RecyclerView.Widget;

namespace SimpleChat.UI.Pages.ChatPage;

public class SmoothScroller(Context? context) : LinearSmoothScroller(context)
{
    protected override float CalculateSpeedPerPixel(DisplayMetrics? displayMetrics)
    {
        const float speedModifier = 4;  // The higher the number, the slower the speed
        return base.CalculateSpeedPerPixel(displayMetrics) * speedModifier;
    }
}