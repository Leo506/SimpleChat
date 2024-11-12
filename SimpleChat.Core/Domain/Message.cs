using SimpleChat.Core.Resources;

namespace SimpleChat.Core.Domain;

public record Message(Guid Id, Guid ChatId, Guid SenderId, DateTime SendTime, string Text)
{
    public string SenderName => SenderId == Constants.BotId 
        ? Translates.Bot 
        : Translates.You;
}