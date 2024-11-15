﻿using Android.Views;

namespace SimpleChat.Android.UI.Extensions;

public class OnClickListener(Action onClick) : Java.Lang.Object, View.IOnClickListener
{
    public void OnClick(View? v) => onClick();
}