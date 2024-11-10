using Microsoft.Extensions.Logging;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Core;
using SimpleChat.Android.UI;
using SimpleChat.Android.UI.Pages.ChatPage;
using SimpleChat.Android.UI.Pages.Chats;
using SimpleChat.Core;
using SimpleChat.Core.ViewModels.Chat;
using SimpleChat.Core.ViewModels.Chats;

namespace SimpleChat.Android;

public class Setup : MvxAndroidSetup<App>
{
    protected override ILoggerProvider? CreateLogProvider() => default;

    protected override ILoggerFactory? CreateLogFactory() => default;

    protected override IDictionary<Type, Type> InitializeLookupDictionary(IMvxIoCProvider iocProvider)
    {
        return new Dictionary<Type, Type>
        {
            { typeof(ChatsViewModel), typeof(ChatsActivity) },
            { typeof(ChatViewModel), typeof(ChatActivity) }
        };
    }
}