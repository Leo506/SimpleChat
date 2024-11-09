using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SimpleChat.Core.Domain;
using SimpleChat.Core.ViewModels.Chat;
using ChatModel = SimpleChat.Core.Domain.Chat;

namespace SimpleChat.Core.ViewModels.Chats;

public class ChatsViewModel(IMvxNavigationService navigationService) : MvxViewModel
{
    private MvxObservableCollection<ObservableChat> _chats = [];
    private IMvxCommand<ObservableChat>? _chatClickCommand;
    
    public MvxObservableCollection<ObservableChat> Chats
    {
        get => _chats;
        private set => SetProperty(ref _chats, value);
    }

    public IMvxCommand<ObservableChat> ChatClickCommand => _chatClickCommand ??= new MvxAsyncCommand<ObservableChat>(OpenChat);

    public override Task Initialize()
    {
        Chats =
        [
            new(new ChatModel(Guid.NewGuid(), "Chat 1"), new Message(default, default, "Mark", DateTime.Now, "Hello")),
            new(new ChatModel(Guid.NewGuid(), "Chat 2"), default),
            new(new ChatModel(Guid.NewGuid(), "Chat 3"), default),
            new(new ChatModel(Guid.NewGuid(), "Chat 4"), default),
            new(new ChatModel(Guid.NewGuid(), "Chat 5"), default),
            new(new ChatModel(Guid.NewGuid(), "Chat 6"), default),
            new(new ChatModel(Guid.NewGuid(), "Chat 7"), default)
        ];
        return Task.CompletedTask;
    }
    
    private Task OpenChat(ObservableChat? chat)
    {
        if (chat is null)
            throw new InvalidOperationException();
        return navigationService.Navigate<ChatViewModel, ChatModel>(chat.Chat);
    }

    public Task CreateChat(string chatName)
    {
        Chats.Add(new(new ChatModel(Guid.NewGuid(), chatName), default));
        return Task.CompletedTask;
    }
}