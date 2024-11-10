using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SimpleChat.Core.Domain;
using SimpleChat.Core.Services.Chats;
using SimpleChat.Core.Services.Messages;
using SimpleChat.Core.ViewModels.Chat;
using ChatModel = SimpleChat.Core.Domain.Chat;

namespace SimpleChat.Core.ViewModels.Chats;

public class ChatsViewModel(
    IMvxNavigationService navigationService,
    IChatsService chatsService,
    IMessagesService messagesService) : MvxViewModel
{
    private MvxObservableCollection<ObservableChat> _chats = [];
    private IMvxCommand<ObservableChat>? _chatClickCommand;
    
    public MvxObservableCollection<ObservableChat> Chats
    {
        get => _chats;
        private set => SetProperty(ref _chats, value);
    }

    public IMvxCommand<ObservableChat> ChatClickCommand => _chatClickCommand ??= new MvxAsyncCommand<ObservableChat>(OpenChat);
    
    public override async void ViewAppeared()
    {
        base.ViewAppeared();
        await LoadChats().ConfigureAwait(false);
    }

    private async Task LoadChats()
    {
        try
        {
            var chats = await chatsService.GetAll().ConfigureAwait(false);
            List<ObservableChat> observableChats = [];
            foreach (var chat in chats)
            {
                var lastMessage = await messagesService.GetLastMessageForChat(chat.Id).ConfigureAwait(false);
                observableChats.Add(new(chat, lastMessage));
            }

            Chats = new(observableChats);
        }
        catch (Exception)
        {
            // ignore
        }
    }
    
    private Task OpenChat(ObservableChat? chat)
    {
        if (chat is null)
            throw new InvalidOperationException();
        return navigationService.Navigate<ChatViewModel, ChatModel>(chat.Chat);
    }

    public async Task CreateChat(string chatName)
    {
        var newChat = await chatsService.CreateNew(chatName).ConfigureAwait(false);
        Chats.Add(new ObservableChat(newChat, default));
        await navigationService.Navigate<ChatViewModel, ChatModel>(newChat).ConfigureAwait(false);
    }
}