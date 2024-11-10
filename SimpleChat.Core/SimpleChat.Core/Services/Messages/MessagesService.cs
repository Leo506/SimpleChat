using Microsoft.Maui.Storage;
using SimpleChat.Core.Domain;
using SimpleChat.Core.Extensions;
using SimpleChat.Core.Resources;

namespace SimpleChat.Core.Services.Messages;

public class MessagesService(IPreferences preferences) : IMessagesService
{
    private const string MessagesKey = "Messages";
    
    public Task SendMessage(Guid chatId, string message)
    {
        var yourMessage = new Message(Guid.NewGuid(), chatId, Constants.YourId, DateTime.Now, message);
        var botMessage = new Message(Guid.NewGuid(), chatId, Constants.BotId, DateTime.Now, GetBotMessage());
        var allMessages = GetAll();
        allMessages.Add(yourMessage);
        allMessages.Add(botMessage);
        preferences.Save(MessagesKey, allMessages);
        return Task.CompletedTask;
    }

    private static string GetBotMessage()
    {
        List<string> messages = [
            Translates.Hello,
            Translates.HowAreYou,
            Translates.HowCanIHelpYou
        ];

        return messages[new Random().Next(0, messages.Count)];
    }

    public Task<List<Message>> GetAll(Guid chatId)
    {
        var messages = GetAll().Where(x => x.ChatId == chatId).OrderBy(x => x.SendTime).ToList();
        return Task.FromResult(messages);
    }

    public async Task<Message?> GetLastMessageForChat(Guid chatId)
    {
        var messages = await GetAll(chatId).ConfigureAwait(false);
        return messages.MaxBy(x => x.SendTime);
    }

    public async Task<List<Message>> GetNewMessages(Guid chatId, List<Guid> knownMessages)
    {
        var messages = await GetAll(chatId).ConfigureAwait(false);
        return messages.Where(x => knownMessages.Contains(x.Id) is false).ToList();
    }

    private List<Message> GetAll() => preferences.Get<List<Message>>(MessagesKey) ?? [];
}