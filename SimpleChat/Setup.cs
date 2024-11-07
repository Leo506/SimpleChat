using Microsoft.Extensions.Logging;
using MvvmCross.Core;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Core;
using SimpleChat.Core;
using SimpleChat.Core.ViewModels.Chats;
using SimpleChat.UI;

namespace SimpleChat;

public class Setup : MvxAndroidSetup<App>
{
    protected override ILoggerProvider? CreateLogProvider() => default;

    protected override ILoggerFactory? CreateLogFactory() => default;

    protected override IDictionary<Type, Type> InitializeLookupDictionary(IMvxIoCProvider iocProvider)
    {
        return new Dictionary<Type, Type>
        {
            { typeof(ChatsViewModel), typeof(ChatsActivity) }
        };
    }
}