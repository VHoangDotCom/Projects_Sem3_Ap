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
    /// 

    
    public sealed partial class SplitViewDemo : Page
    {
        public SplitViewDemo()
        {
            this.InitializeComponent();
        }
        private void SymbolIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void Link_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var textBlock = sender as TextBlock;
            switch (textBlock.Tag)
            {
                case "GridLayout":
                     GridLayoutDemo p = new GridLayoutDemo();
                      p.Visibility = Visibility.Visible;
                    break;
                case "page2":
                     MainFrame.Navigate(typeof(Demo.GridLayoutDemo));
                    break;
                case "listview":
                     MainFrame.Navigate(typeof(Demo.ListViewDemo));
                    break;
                    //listview
            }
        }
    }
}
