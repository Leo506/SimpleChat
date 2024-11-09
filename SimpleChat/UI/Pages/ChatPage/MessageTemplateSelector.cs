using _Microsoft.Android.Resource.Designer;
using MvvmCross.DroidX.RecyclerView.ItemTemplates;
using SimpleChat.Core.Domain;

namespace SimpleChat.UI.Pages.ChatPage;

public class MessageTemplateSelector : IMvxTemplateSelector
{
    public int GetItemViewType(object forItemObject)
    {
        var message = (Message)forItemObject;
        return message.Sender == "You"
            ? 0
            : 1;
    }

    public int GetItemLayoutId(int fromViewType)
    {
        return fromViewType == 0
            ? ResourceConstant.Layout.view_your_message
            : ResourceConstant.Layout.view_message;
    }

    public int ItemTemplateId { get; set; }
}