using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VideoSystem.Entity;
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

namespace VideoSystem.Pages
{
    
    public sealed partial class NavigationListSong : Page
    {
       

        public NavigationListSong()
        {
            this.InitializeComponent();
            this.Loaded += NavView_Loaded;
        }
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
           ("listSong", typeof(ListSongPage)),
           ("account", typeof(UserPage)),
            ("logout", typeof(LoginPage)),
             ("createSong", typeof(CreateSong)),
              ("mySong", typeof(MySongPage)),
        };


        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(typeof(Pages.ListSongPage));

        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                MainContent.Navigate(typeof(Pages.SettingPage));
            }
            else
            {
                var selectedItem = sender.SelectedItem as NavigationViewItem;
                var item = _pages.First(p => p.Tag.Equals(selectedItem.Tag));
                MainContent.Navigate(item.Page);
            }

        }

        private void NavViewSearchBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }
    }
}
