using _Microsoft.Android.Resource.Designer;
using Android.Content.PM;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using SimpleChat.Android.UI.Extensions;
using SimpleChat.Core.ViewModels.Chat;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace SimpleChat.Android.UI.Pages.ChatPage;

[MvxActivityPresentation]
[Activity(ScreenOrientation = ScreenOrientation.Portrait)]
public class ChatActivity : AppActivity<ChatViewModel>
{
    protected override int LayoutId => ResourceConstant.Layout.activity_chat;

    private MvxRecyclerView MessagesRecyclerView => FindViewById<MvxRecyclerView>(ResourceConstant.Id.messages);

    protected override void OnViewModelSet()
    {
        base.OnViewModelSet();
        ViewModel.ScrollToLastMessage = () =>
        {
            MessagesRecyclerView.GetLayoutManager()?.StartSmoothScroll(new SmoothScroller(this)
            {
                TargetPosition = ViewModel.Messages.Count - 1
            });
        };
    }

    protected override void SetupToolbar(Toolbar toolbar)
    {
        toolbar.Title = ViewModel?.Chat.Name;
        toolbar.SetNavigationButton(ResourceConstant.Drawable.arrow_back_24, Finish);
    }
}