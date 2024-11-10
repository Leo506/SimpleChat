using System.Text.Json;
using Microsoft.Maui.Storage;

namespace SimpleChat.Core.Extensions;

public static class PreferencesExtensions
{
    public static T? Get<T>(this IPreferences preferences, string key)
    {
        var value = preferences.Get(key, string.Empty);
        return string.IsNullOrEmpty(value) 
            ? default 
            : JsonSerializer.Deserialize<T>(value);
    }

    public static void Save<T>(this IPreferences preferences, string key, T value)
    {
        var stringValue = JsonSerializer.Serialize(value);
        preferences.Set(key, stringValue);
    }
}