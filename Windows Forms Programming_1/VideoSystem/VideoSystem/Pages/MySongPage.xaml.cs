using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VideoSystem.Entity;
using VideoSystem.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
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
   
    public sealed partial class MySongPage : Page
    {
        private SongService songService;
        int indexSong;
        MediaPlaybackList _mediaPlaybackList;
        public MySongPage()
        {
            this.InitializeComponent();
            this.songService = new SongService();
            this.
            Loaded += MySongPage_LoadedAsync;
        }

        private async void MySongPage_LoadedAsync(object sender, RoutedEventArgs e)
        {
            List<Song> list = await this.songService.GetMyList();
            ObservableCollection<Song> observabSongs = new ObservableCollection<Song>(list);
            MyListSong.ItemsSource = observabSongs;

            //MyListSong.SelectedIndex = 3;
            _mediaPlaybackList = new MediaPlaybackList();

            for (int i = 0; i < list.Count; i++)
            {
                try
                {
                    var mediaPlaybackItem = new MediaPlaybackItem(MediaSource.CreateFromUri(new Uri(list[i].link)));
                    _mediaPlaybackList.Items.Add(mediaPlaybackItem);
                }
                catch (Exception ex)
                {
                    var mediaItemNull = new MediaPlaybackItem(MediaSource.CreateFromUri(new Uri("about:blank")));
                    _mediaPlaybackList.Items.Add(mediaItemNull);
                }

            }
            _mediaPlaybackList.CurrentItemChanged += MediaPlaybackList_CurrentItemChanged;


            var _mediaPlayer = new MediaPlayer();
            _mediaPlayer.Source = _mediaPlaybackList; // MediaPlayerElement < MediaPlayer < MediaPlaybackList < MediaPlaybackItem
            MyMediaPlayer.SetMediaPlayer(_mediaPlayer);
        }

        private async void MediaPlaybackList_CurrentItemChanged(MediaPlaybackList sender, CurrentMediaPlaybackItemChangedEventArgs args)
        {
            indexSong = (int)sender.CurrentItemIndex;
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                MyListSong.SelectedIndex = indexSong;
            });
        }

        private void MyListSong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            indexSong = MyListSong.SelectedIndex;
            if (indexSong != -1)
            {
                _mediaPlaybackList.MoveTo(Convert.ToUInt32(indexSong));
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
    }
}
