using Microsoft.Maui.Storage;
using SimpleChat.Core.Extensions;

namespace SimpleChat.Core.Services.Chats;

public class ChatsService(IPreferences preferences) : IChatsService
{
    private const string ChatsKey = "Chats";
    
    public async Task<Domain.Chat> CreateNew(string name)
    {
        var newChat = new Domain.Chat(Guid.NewGuid(), name);
        var allChats = await GetAll().ConfigureAwait(false);
        allChats.Add(newChat);
        preferences.Save(ChatsKey, allChats);
        return newChat;
    }

    public Task<List<Domain.Chat>> GetAll()
    {
        var allChats = preferences.Get<List<Domain.Chat>>(ChatsKey) ?? [];
        return Task.FromResult(allChats);
    }
}