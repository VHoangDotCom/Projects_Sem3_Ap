#pragma checksum "D:\epc\Ap-Sem3\Windows Forms Programming\Test\HelloWorld\HelloWorld\Pages\LoginPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C0559A33877B69210D014DBB3492B4AFBFA54F2A7AE0B63B072DF992CDC4CD8B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelloWorld.Pages
{
    partial class LoginPage : 
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
            case 2: // Pages\LoginPage.xaml line 14
                {
                    this.ErrorMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // Pages\LoginPage.xaml line 18
                {
                    this.UsernameTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // Pages\LoginPage.xaml line 19
                {
                    this.PassportSignInButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.PassportSignInButton).Click += this.PassportSignInButton_Click;
                }
                break;
            case 5: // Pages\LoginPage.xaml line 23
                {
                    this.RegisterButtonTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.RegisterButtonTextBlock).PointerPressed += this.RegisterButtonTextBlock_OnPointerPressed;
                }
                break;
            case 6: // Pages\LoginPage.xaml line 27
                {
                    this.PassportStatus = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 7: // Pages\LoginPage.xaml line 32
                {
                    this.LoginExplaination = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // Pages\LoginPage.xaml line 29
                {
                    this.PassportStatusText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

