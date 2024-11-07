using MvvmCross.ViewModels;
using SimpleChat.Core.Domain;

namespace SimpleChat.Core.ViewModels.Chats;

public class ChatsViewModel : MvxViewModel
{
    private MvxObservableCollection<Chat> _chats = [];
    public MvxObservableCollection<Chat> Chats
    {
        get => _chats;
        private set => SetProperty(ref _chats, value);
    }

    public override Task Initialize()
    {
        Chats =
        [
            new(Guid.NewGuid(), "Chat 1", default),
            new(Guid.NewGuid(), "Chat 2", default),
            new(Guid.NewGuid(), "Chat 3", default),
            new(Guid.NewGuid(), "Chat 4", default),
            new(Guid.NewGuid(), "Chat 5", default),
            new(Guid.NewGuid(), "Chat 6", default),
            new(Guid.NewGuid(), "Chat 7", default),
        ];
        return Task.CompletedTask;
    }
}