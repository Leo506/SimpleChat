using SimpleChat.Core.Domain;

namespace SimpleChat.Core.ViewModels.Chats;

public class ObservableChat(Domain.Chat chat, Message? lastMessage)
{
    public Domain.Chat Chat => chat;
    
    public string Title => chat.Name;

    public string Subtitle => lastMessage is null 
        ? string.Empty 
        : $"{lastMessage?.SendTime:hh:mm} {lastMessage?.Sender}: {lastMessage?.Text}";
}