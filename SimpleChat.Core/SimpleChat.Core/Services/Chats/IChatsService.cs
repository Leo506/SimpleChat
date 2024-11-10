namespace SimpleChat.Core.Services.Chats;

public interface IChatsService
{
    Task<Domain.Chat> CreateNew(string name);

    Task<List<Domain.Chat>> GetAll();
}