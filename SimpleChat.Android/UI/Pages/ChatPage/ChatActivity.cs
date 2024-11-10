using _Microsoft.Android.Resource.Designer;
using Android.Content.PM;
using AndroidX.RecyclerView.Widget;
using Microsoft.Maui.ApplicationModel;
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

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Toolbar.SetNavigationButton(ResourceConstant.Drawable.arrow_back_24, Finish);

        var layoutManager = new LinearLayoutManager(this);
        layoutManager.ReverseLayout = true;
        MessagesRecyclerView.SetLayoutManager(layoutManager);
    }

    protected override void OnViewModelSet()
    {
        base.OnViewModelSet();
        ViewModel.ScrollToLastMessage = () =>
        {
            MessagesRecyclerView.GetLayoutManager()?.StartSmoothScroll(new SmoothScroller(this)
            {
                TargetPosition = 0
            });
        };
    }

    protected override void SetupToolbar(Toolbar toolbar)
    {
        toolbar.Title = ViewModel?.Chat.Name;
    }
}