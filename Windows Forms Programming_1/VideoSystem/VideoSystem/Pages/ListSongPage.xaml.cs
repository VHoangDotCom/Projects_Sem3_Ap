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
using VideoSystem.Entity;
using VideoSystem.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.Media.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VideoSystem.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListSongPage : Page
    {
      
        private SongService songService;
        public ListSongPage()
        {
            this.InitializeComponent();
            this.songService = new SongService();
            Loaded += ListSongPage_LoadedAsync;
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
        private async void ListSongPage_LoadedAsync(object sender, RoutedEventArgs e)
        {
            List<Song> list = await this.songService.GetListAsync();
            ObservableCollection<Song> observabSongs = new ObservableCollection<Song>(list);
            MyListSong.ItemsSource = observabSongs;

        }

        private void MyListSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentSong = MyListSong.SelectedItem as Song;
            Debug.WriteLine(currentSong.name);
            Debug.WriteLine(currentSong.link);
            MyMediaPlayer.MediaPlayer.Source = MediaSource.CreateFromUri(new Uri(currentSong.link));
            MyMediaPlayer.MediaPlayer.Play();


        }

      
    }
}
