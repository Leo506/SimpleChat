using MvvmCross.Commands;
using MvvmCross.ViewModels;
using SimpleChat.Core.Domain;
using SimpleChat.Core.Resources;
using SimpleChat.Core.Services.Messages;

namespace SimpleChat.Core.ViewModels.Chat;

public class ChatViewModel(IMessagesService messagesService) : MvxViewModel<Domain.Chat>
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
            SetProperty(ref _currentMessage, value.Trim());
            RaisePropertyChanged(nameof(SendButtonVisible));
        }
    }

    public bool SendButtonVisible => string.IsNullOrEmpty(CurrentMessage) is false &&
                                     string.IsNullOrWhiteSpace(CurrentMessage) is false;

    public IMvxCommand SendCommand => _sendCommand ??= new MvxAsyncCommand(Send);

    public Action ScrollToLastMessage { get; set; } = default!;

    public string MessageHint => Translates.YourMessage;

    public override Task Initialize() => Task.Run(LoadMessages);

    private async Task LoadMessages()
    {
        try
        {
            var messages = await messagesService.GetAll(Chat.Id);
            Messages = new(messages);
        }
        catch (Exception)
        {
            // ignore
        }
    }
    
    private async Task Send()
    {
        await messagesService.SendMessage(Chat.Id, CurrentMessage).ConfigureAwait(false);
        var newMessages = await messagesService.GetNewMessages(Chat.Id, Messages.Select(x => x.Id).ToList());
        Messages.InsertRange(0, newMessages);
        CurrentMessage = string.Empty;
        ScrollToLastMessage();
    }

    public override void Prepare(Domain.Chat parameter) => Chat = parameter;
}