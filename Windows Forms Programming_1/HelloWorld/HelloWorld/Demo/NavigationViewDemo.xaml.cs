using HelloWorld.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class NavigationViewDemo : Page
    {
        private bool LoggedIn;
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
{
    ("listSong", typeof(Demo.ListSongPage)),
    ("imformation", typeof(Pages.AccountInformation)),

};

        public NavigationViewDemo() 
        {
            this.InitializeComponent();
            this.Loaded += NavigationViewDemo_Loaded;
        }

        private void NavigationViewDemo_Loaded(object sender, RoutedEventArgs e)
        {

            if (App.currentLoggedIn != null)
            {
              LoggedIn = true;
            }
            else
            {
                LoggedIn = false;
            }
            MainContent.Navigate(typeof(Demo.ListSongPage));

        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                MainContent.Navigate(typeof(Pages.SettingPage));
            }
            else
            {
                var selectedItem = sender.SelectedItem as NavigationViewItem;
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(selectedItem.Tag));
                MainContent.Navigate(item.Page);
            }
           
        }
    }
}
