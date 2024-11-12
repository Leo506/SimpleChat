using SimpleChat.Core.Domain;

namespace SimpleChat.Core.Services.Messages;

public interface IMessagesService
{
    Task SendMessage(Guid chatId, string message);

    Task<List<Message>> GetAll(Guid chatId);

    Task<Message?> GetLastMessageForChat(Guid chatId);

    Task<List<Message>> GetNewMessages(Guid chatId, List<Guid> knownMessages);
}