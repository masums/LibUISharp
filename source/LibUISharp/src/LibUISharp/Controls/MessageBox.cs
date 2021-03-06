﻿using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    // uiMsgBox
    public class MessageBox
    {
        public static void Show(string title, string description = "LibUISharp", bool isError = false, Window owner = null)
        {
            if (isError)
                uiMsgBoxError(owner.Handle ?? Application.MainWindow.Handle, title, description);
            else
                uiMsgBox(owner.Handle ?? Application.MainWindow.Handle, title, description);
        }
    }
}