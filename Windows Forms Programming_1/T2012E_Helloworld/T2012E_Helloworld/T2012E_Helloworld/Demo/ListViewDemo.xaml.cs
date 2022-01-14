using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T2012E_Helloworld.Entity;
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

namespace T2012E_Helloworld.Demo
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
                    Id = 1,
                    Username = "hung01",
                    Password = "123",
                    Avatar = "https://icdn.dantri.com.vn/thumb_w/660/2021/09/08/316784x441-1631079051594.jpg",
                    Status = 1
                },
                new Account(){
                    Id = 2,
                    Username = "hung02",
                    Password = "124",
                    Avatar = "https://baoquocte.vn/stores/news_dataimages/trunghieu/082021/06/11/hon-300-con-meo-o-anh-chet-vi-mot-can-benh-la.jpg",
                    Status = 1
                },
                new Account(){
                    Id = 3,
                    Username = "hung03",
                    Password = "125",
                    Avatar = "https://dothobattrang.vn/wp-content/uploads/2018/05/con-meo-hoang-vao-nha-la-diem-bao-gi-hen.jpg",
                    Status = 1
                }
            };
            MyListView.ItemsSource = accounts;
        }
    }
}
