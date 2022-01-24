using HelloWorld.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloWorld.Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListViewDemo : Page
    {

        public ListViewDemo()
        {
            this.InitializeComponent();
            List<Account> accounts = new List<Account>() {
                new Account(){
                    id = 1,
                    firstName = "hung01",
                    password = "123",
                    avatar = "https://icdn.dantri.com.vn/thumb_w/660/2021/09/08/316784x441-1631079051594.jpg",
                    status = 1
                },
                new Account(){
                    id = 2,
                    firstName = "hung02",
                    password = "124",
                    avatar = "https://baoquocte.vn/stores/news_dataimages/trunghieu/082021/06/11/hon-300-con-meo-o-anh-chet-vi-mot-can-benh-la.jpg",
                    status = 1
                },
                new Account(){
                    id = 3,
                    firstName = "hung03",
                    password = "125",
                    avatar = "https://dothobattrang.vn/wp-content/uploads/2018/05/con-meo-hoang-vao-nha-la-diem-bao-gi-hen.jpg",
                    status = 1
                }
            };
            MyListView.ItemsSource = accounts;
        }
    }
}
