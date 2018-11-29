using System.Windows;

namespace LisaResume.Windows
{
    /// <summary>
    /// Interaction logic for VideoWindow.xaml
    /// </summary>
    public partial class VideoWindow : Window
    {
        public VideoWindow()
        {
            InitializeComponent();
        }

        public void PlayVideo(object sender, RoutedEventArgs e)


        {


            VideoPreview.Visibility = Visibility.Collapsed;


            LisaVideo.Visibility = Visibility.Visible;


            LisaVideo.Play();


        }


        public void PauseVideo(object sender, RoutedEventArgs e)


        {


            VideoPreview.Visibility = Visibility.Collapsed;


            LisaVideo.Visibility = Visibility.Visible;


            LisaVideo.Pause();


        }


        public void StopVideo(object sender, RoutedEventArgs e)


        {


            VideoPreview.Visibility = Visibility.Collapsed;


            LisaVideo.Visibility = Visibility.Visible;


            LisaVideo.Stop();


        }
    }
}
