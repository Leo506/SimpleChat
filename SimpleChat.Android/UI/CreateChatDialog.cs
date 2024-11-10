using _Microsoft.Android.Resource.Designer;
using Android.Content;
using Android.Text;
using Android.Views;
using AndroidX.Core.Content;
using Google.Android.Material.Dialog;
using SimpleChat.Core.Resources;
using AlertDialog = AndroidX.AppCompat.App.AlertDialog;

namespace SimpleChat.Android.UI;

public static class CreateChatDialog
{
    public static void Show(Context context, Action<string> onOkClick)
    {
        var editText = CreateEditText(context);

        var alertDialog = CreateAlertDialog(context, editText, onOkClick);
        alertDialog.Show();
        
        editText.ShowSoftInputOnFocus = true;
        editText.RequestFocus();
    }
    
    private static EditText CreateEditText(Context context)
    {
        var input = new EditText(context)
        {
            LayoutParameters = GetEditTextLayoutParams(context),
            BackgroundTintList = ContextCompat.GetColorStateList(context, ResourceConstant.Color.md_theme_surfaceContainerLow),
            Hint = Translates.ChatName,
            Focusable = true,
            FocusableInTouchMode = true,
        };
        var padding = context.Resources!.GetDimensionPixelSize(ResourceConstant.Dimension.md_theme_indent_1x);
        input.SetPadding(padding, padding, padding, padding);
        input.SetMaxLines(5);
        return input;

        static ViewGroup.LayoutParams GetEditTextLayoutParams(Context context)
        {
            var margin = context.Resources!.GetDimensionPixelSize(ResourceConstant.Dimension.md_theme_indent_2x);
            return new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
            {
                LeftMargin = margin,
                RightMargin = margin,
                TopMargin = margin / 2,
            };
        }
    }

    private static AlertDialog CreateAlertDialog(Context context, EditText editText, Action<string> onOkClick)
    {
        var builder = new MaterialAlertDialogBuilder(context)
            .SetTitle(Translates.NewChat)!
            .SetPositiveButton(Translates.Add, OkButtonOnClick)
            .SetNeutralButton(Translates.Cancel, CancelDialog);

        var container = new FrameLayout(context);
        container.AddView(editText);
        builder.SetView(container);

        return builder.Create();


        void OkButtonOnClick(object? sender, DialogClickEventArgs e)
        {
            if (string.IsNullOrEmpty(editText.Text) || string.IsNullOrWhiteSpace(editText.Text))
            {
                CancelDialog(sender, e);
                return;
            }
            
            onOkClick(editText.Text);
            CancelDialog(sender, e);
        }

        void CancelDialog(object? sender, DialogClickEventArgs e)
        {
            ((AlertDialog)sender!).Cancel();
        }
    }
}