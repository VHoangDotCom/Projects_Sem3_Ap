﻿#pragma checksum "D:\epc\Ap-Sem3\Windows Forms Programming\Test\HelloWorld\HelloWorld\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "51B01DA013B8D8A3D9F7DD80EB73642524108E08DB79A9DE46F489AD3600F9CA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelloWorld
{
    partial class MainPage : 
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
            case 2: // MainPage.xaml line 113
                {
                    this.login = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.login).Click += this.Button_Click;
                }
                break;
            case 3: // MainPage.xaml line 106
                {
                    this.intrErr = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // MainPage.xaml line 107
                {
                    this.intro = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // MainPage.xaml line 99
                {
                    this.birthdayErr = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // MainPage.xaml line 100
                {
                    this.birthday = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                    ((global::Windows.UI.Xaml.Controls.DatePicker)this.birthday).IsEnabledChanged += this.birthday_IsEnabledChanged;
                    ((global::Windows.UI.Xaml.Controls.DatePicker)this.birthday).PointerEntered += this.birthday_PointerEntered;
                }
                break;
            case 7: // MainPage.xaml line 90
                {
                    this.emailErr = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // MainPage.xaml line 91
                {
                    this.email = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.email).TextChanged += this.email_TextChanged;
                }
                break;
            case 9: // MainPage.xaml line 80
                {
                    this.genderErr = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // MainPage.xaml line 82
                {
                    this.male = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.male).Click += this.male_Click;
                }
                break;
            case 11: // MainPage.xaml line 83
                {
                    this.female = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.female).Click += this.female_Click;
                }
                break;
            case 12: // MainPage.xaml line 71
                {
                    this.avatarErr = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // MainPage.xaml line 72
                {
                    this.avatar = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.avatar).TextChanged += this.avatar_TextChanged;
                }
                break;
            case 14: // MainPage.xaml line 65
                {
                    this.addressErr = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // MainPage.xaml line 66
                {
                    this.address = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.address).SelectionChanged += this.address_SelectionChanged;
                }
                break;
            case 16: // MainPage.xaml line 54
                {
                    this.phoneErr = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17: // MainPage.xaml line 55
                {
                    this.phone = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.phone).SelectionChanged += this.phone_SelectionChanged;
                }
                break;
            case 18: // MainPage.xaml line 47
                {
                    this.passwordErr = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 19: // MainPage.xaml line 49
                {
                    this.password = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.password).SelectionChanged += this.password_SelectionChanged;
                }
                break;
            case 20: // MainPage.xaml line 37
                {
                    this.lNameErr = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 21: // MainPage.xaml line 38
                {
                    this.lName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.lName).SelectionChanged += this.lName_SelectionChanged;
                }
                break;
            case 22: // MainPage.xaml line 31
                {
                    this.fNameErr = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 23: // MainPage.xaml line 32
                {
                    this.fName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.fName).SelectionChanged += this.fName_SelectionChanged;
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.fName).PointerEntered += this.fName_PointerEntered;
                }
                break;
            case 24: // MainPage.xaml line 22
                {
                    this.title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 25: // MainPage.xaml line 23
                {
                    this.DialogResult = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

