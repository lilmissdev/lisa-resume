using System.Windows;
using System.Windows.Controls;

namespace LisaResume.Controls
{
    /// <summary>
    /// Interaction logic for Video.xaml
    /// </summary>
    public partial class Video : UserControl
    {
        public Video()
        {
            InitializeComponent();
        }

        public void PlayVideo(object sender, RoutedEventArgs e)


        {


            VideoPreview.Visibility = Visibility.Collapsed;


            redangVideo.Visibility = Visibility.Visible;


            redangVideo.Play();


        }


        public void PauseVideo(object sender, RoutedEventArgs e)


        {


            VideoPreview.Visibility = Visibility.Collapsed;


            redangVideo.Visibility = Visibility.Visible;


            redangVideo.Pause();


        }


        public void StopVideo(object sender, RoutedEventArgs e)


        {


            VideoPreview.Visibility = Visibility.Collapsed;


            redangVideo.Visibility = Visibility.Visible;


            redangVideo.Stop();


        }
    }
}
