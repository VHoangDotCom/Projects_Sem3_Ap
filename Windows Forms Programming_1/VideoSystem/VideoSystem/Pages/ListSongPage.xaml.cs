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
using Windows.UI.Xaml.Media.Imaging;
using Windows.Media.Playback;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VideoSystem.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListSongPage : Page
    {
      
        private SongService songService;
        int indexSong;
        MediaPlaybackList _mediaPlaybackList;
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

            //MyListSong.SelectedIndex = 3;
              _mediaPlaybackList = new MediaPlaybackList();

            for (int i = 0 ; i<list.Count;i++)
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
            /*  var currentSong = MyListSong.SelectedItem as Song;
              Debug.WriteLine(currentSong.name);
              Debug.WriteLine(currentSong.link);
              MyMediaPlayer.MediaPlayer.Source = MediaSource.CreateFromUri(new Uri(currentSong.link));
              MyMediaPlayer.MediaPlayer.Play(); */
            indexSong = MyListSong.SelectedIndex;
            if(indexSong != -1)
            {
                _mediaPlaybackList.MoveTo(Convert.ToUInt32(indexSong));
            }
        }

        private void Image_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            imageSong.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/pepefrg-4.gif"));
            imageSong1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/1FPE.gif"));
            imageSong2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/6K2.gif"));
        }

        private void MyMediaPlayer_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            imageSong.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/pepefrg-4.gif"));
            imageSong1.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/1FPE.gif"));
            imageSong2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Images/6K2.gif"));
        }
    }
}
