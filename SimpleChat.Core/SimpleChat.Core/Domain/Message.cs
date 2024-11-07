namespace SimpleChat.Core.Domain;

public record Message(Guid Id, Guid ChatId, string Sender, DateTime SendTime, string Text);