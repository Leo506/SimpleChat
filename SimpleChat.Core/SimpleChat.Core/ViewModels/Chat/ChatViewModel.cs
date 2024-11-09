using MvvmCross.Commands;
using MvvmCross.ViewModels;
using SimpleChat.Core.Domain;

namespace SimpleChat.Core.ViewModels.Chat;

public class ChatViewModel : MvxViewModel<Domain.Chat>
{
    private MvxObservableCollection<Message> _messages = [];
    private string _currentMessage = string.Empty;
    private IMvxCommand? _sendCommand;
    
    public Domain.Chat Chat { get; private set; } = default!;

    public MvxObservableCollection<Message> Messages
    {
        get => _messages;
        set => SetProperty(ref _messages, value);
    }

    public string CurrentMessage
    {
        get => _currentMessage;
        set
        {
            SetProperty(ref _currentMessage, value);
            RaisePropertyChanged(nameof(SendButtonVisible));
        }
    }

    public bool SendButtonVisible => string.IsNullOrEmpty(CurrentMessage) is false &&
                                     string.IsNullOrWhiteSpace(CurrentMessage) is false;

    public IMvxCommand SendCommand => _sendCommand ??= new MvxAsyncCommand(Send);

    public Action ScrollToNewMessage { get; set; } = default!;

    public override Task Initialize()
    {
        Messages =
        [
            new(default, default, "Mark", DateTime.Now, "Hello"),
            new(default, default, "You", DateTime.Now, "Hello"),
            new(default, default, "Mark", DateTime.Now, "How r u?"),
            new(default, default, "You", DateTime.Now, "Good"),
            new(default, default, "Mark", DateTime.Now, "Hellobgiiuigiibiubb guggygu gou gygugyugogy gyuguguyguguyuoougyugyu gu u yu guo gu gouyguygyug u goygyg o gogogyog l"),
            new(default, default, "You", DateTime.Now, "Hello"),
        ];
        
        return base.Initialize();
    }
    
    private Task Send()
    {
        Messages.AddRange(
        [
            new Message(default, default, "You", DateTime.Now, CurrentMessage),
            new Message(default, default, "Mark", DateTime.Now, "geegegegeg")
        ]);
        CurrentMessage = string.Empty;
        ScrollToNewMessage();
        return Task.CompletedTask;
    }

    public override void Prepare(Domain.Chat parameter) => Chat = parameter;
}