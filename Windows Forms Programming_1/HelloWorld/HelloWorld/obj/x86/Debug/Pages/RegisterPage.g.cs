﻿#pragma checksum "D:\epc\Ap-Sem3\Windows Forms Programming\Test\HelloWorld\HelloWorld\Pages\RegisterPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BDA88115DF697C03D6B103C7F6E6A17AB3D42E00DBED4865B69BB53FE70572D9"
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
    partial class RegisterPage : 
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
            case 2: // Pages\RegisterPage.xaml line 18
                {
                    this.firstName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // Pages\RegisterPage.xaml line 19
                {
                    this.lastName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // Pages\RegisterPage.xaml line 22
                {
                    this.txtEmail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Pages\RegisterPage.xaml line 25
                {
                    this.txtpassword = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 6: // Pages\RegisterPage.xaml line 26
                {
                    this.txtAddress = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7: // Pages\RegisterPage.xaml line 28
                {
                    this.txtAvatar = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // Pages\RegisterPage.xaml line 29
                {
                    this.txtPhone = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // Pages\RegisterPage.xaml line 32
                {
                    this.male = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.male).Checked += this.HandleCheck;
                }
                break;
            case 10: // Pages\RegisterPage.xaml line 33
                {
                    this.female = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.female).Checked += this.HandleCheck;
                }
                break;
            case 11: // Pages\RegisterPage.xaml line 34
                {
                    this.other = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.other).Checked += this.HandleCheck;
                }
                break;
            case 12: // Pages\RegisterPage.xaml line 38
                {
                    this.birthday = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 13: // Pages\RegisterPage.xaml line 39
                {
                    this.checkFirstName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // Pages\RegisterPage.xaml line 40
                {
                    this.checkLastName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // Pages\RegisterPage.xaml line 41
                {
                    this.checkEmail = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // Pages\RegisterPage.xaml line 43
                {
                    this.checkAddress = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17: // Pages\RegisterPage.xaml line 44
                {
                    this.checkPhone = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18: // Pages\RegisterPage.xaml line 46
                {
                    this.passConfirm = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 19: // Pages\RegisterPage.xaml line 48
                {
                    this.checkPassConfirm = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 20: // Pages\RegisterPage.xaml line 49
                {
                    this.intro = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 21: // Pages\RegisterPage.xaml line 50
                {
                    this.checkAvatar = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 22: // Pages\RegisterPage.xaml line 51
                {
                    this.checkGender = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 23: // Pages\RegisterPage.xaml line 52
                {
                    this.checkBirthday = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 24: // Pages\RegisterPage.xaml line 54
                {
                    global::Windows.UI.Xaml.Controls.Button element24 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element24).Click += this.button_Register;
                }
                break;
            case 25: // Pages\RegisterPage.xaml line 55
                {
                    global::Windows.UI.Xaml.Controls.Button element25 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element25).Click += this.button_login;
                }
                break;
            case 26: // Pages\RegisterPage.xaml line 56
                {
                    global::Windows.UI.Xaml.Controls.Button element26 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element26).Click += this.OpenFileAvatar;
                }
                break;
            case 27: // Pages\RegisterPage.xaml line 57
                {
                    this.checkPassword = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 28: // Pages\RegisterPage.xaml line 59
                {
                    this.progress1 = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
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
