﻿#pragma checksum "D:\epc\Ap-Sem3\Windows Forms Programming\Test\HelloWorld\Demo_SQLite\Pages\ListTransactionPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "605BD1FC8F6672E25BD4F5FA9AFD31451D9E66349F4C622274AF78B2B62B952C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo_SQLite.Pages
{
    partial class ListTransactionPage : 
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
            case 1: // Pages\ListTransactionPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                }
                break;
            case 2: // Pages\ListTransactionPage.xaml line 83
                {
                    this.Create = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Create).Click += this.Create_Click;
                }
                break;
            case 3: // Pages\ListTransactionPage.xaml line 84
                {
                    this.Show = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Show).Click += this.Show_Click;
                }
                break;
            case 4: // Pages\ListTransactionPage.xaml line 85
                {
                    this.Delete = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 5: // Pages\ListTransactionPage.xaml line 71
                {
                    this.txtID = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // Pages\ListTransactionPage.xaml line 72
                {
                    this.txtName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // Pages\ListTransactionPage.xaml line 73
                {
                    this.txtDescription = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // Pages\ListTransactionPage.xaml line 74
                {
                    this.txtMoney = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // Pages\ListTransactionPage.xaml line 75
                {
                    this.txtCreated = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // Pages\ListTransactionPage.xaml line 76
                {
                    this.txtCategory = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // Pages\ListTransactionPage.xaml line 66
                {
                    this.cateErr = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // Pages\ListTransactionPage.xaml line 63
                {
                    this.txtFindCate = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBox)this.txtFindCate).SelectionChanged += this.txtFindCate_SelectionChanged;
                }
                break;
            case 13: // Pages\ListTransactionPage.xaml line 64
                {
                    global::Windows.UI.Xaml.Controls.Button element13 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element13).Click += this.Button_Click_1;
                }
                break;
            case 14: // Pages\ListTransactionPage.xaml line 47
                {
                    global::Windows.UI.Xaml.Controls.Button element14 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element14).Click += this.Button_Click;
                }
                break;
            case 15: // Pages\ListTransactionPage.xaml line 56
                {
                    this.dateErr = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // Pages\ListTransactionPage.xaml line 53
                {
                    this.from = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                    ((global::Windows.UI.Xaml.Controls.DatePicker)this.from).SelectedDateChanged += this.from_SelectedDateChanged;
                }
                break;
            case 17: // Pages\ListTransactionPage.xaml line 54
                {
                    this.to = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                    ((global::Windows.UI.Xaml.Controls.DatePicker)this.to).SelectedDateChanged += this.to_SelectedDateChanged;
                }
                break;
            case 18: // Pages\ListTransactionPage.xaml line 21
                {
                    this.ListData = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)this.ListData).SelectionChanged += this.ListData_SelectionChanged;
                }
                break;
            case 19: // Pages\ListTransactionPage.xaml line 16
                {
                    this.title = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

