﻿#pragma checksum "D:\epc\Ap-Sem3\Windows Forms Programming\Test\VideoSystem\VideoSystem\Views\UserSelection.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7EC89E3296B6382E00A11B265751C3E721B371B3F6DA61A8C2E237C770C99528"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoSystem.Views
{
    partial class UserSelection : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\UserSelection.xaml line 13
                {
                    this.Title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // Views\UserSelection.xaml line 15
                {
                    this.UserListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 4: // Views\UserSelection.xaml line 25
                {
                    this.AddUserButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.AddUserButton).Click += this.AddUserButton_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
