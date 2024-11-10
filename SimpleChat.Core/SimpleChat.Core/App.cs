using Microsoft.Maui.Storage;
using MvvmCross.ViewModels;
using SimpleChat.Core.Services.Chats;
using SimpleChat.Core.Services.Messages;
using static MvvmCross.Mvx;

namespace SimpleChat.Core;

public class App : MvxApplication
{
    public override void Initialize()
    {
        RegisterCustomAppStart<AppStart>();
        
        IoCProvider?.RegisterType<IChatsService, ChatsService>();
        IoCProvider?.RegisterType<IMessagesService, MessagesService>();
        IoCProvider?.RegisterType(() => Preferences.Default);
    }
}