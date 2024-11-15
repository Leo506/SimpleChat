﻿using _Microsoft.Android.Resource.Designer;
using Android.Content.PM;
using Google.Android.Material.FloatingActionButton;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using SimpleChat.Android.UI.Extensions;
using SimpleChat.Core.Resources;
using SimpleChat.Core.ViewModels.Chats;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;

namespace SimpleChat.Android.UI.Pages.Chats;

[MvxActivityPresentation]
[Activity(ScreenOrientation = ScreenOrientation.Portrait, LaunchMode = LaunchMode.SingleTask)]
public class ChatsActivity : AppActivity<ChatsViewModel>
{
    protected override int LayoutId => ResourceConstant.Layout.activity_chats;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        FindViewById<FloatingActionButton>(ResourceConstant.Id.create_chat_button)
            .SetOnClickListener(ShowCreateChatDialog);
    }

    private void ShowCreateChatDialog() => CreateChatDialog.Show(this, CreateChat);

    private async void CreateChat(string chatName) => await ViewModel.CreateChat(chatName).ConfigureAwait(false);

    protected override void SetupToolbar(Toolbar toolbar)
    {
        toolbar.Title = Translates.Chats;
    }
}