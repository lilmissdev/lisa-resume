using System.Windows;
using System.Windows.Controls;

namespace LisaResume.Controls
{
    /// <summary>
    /// Interaction logic for AboutMe.xaml
    /// </summary>
    public partial class AboutMe : Button
    {
        public AboutMe()
        {
            InitializeComponent();
        }

        public string AboutMeTitle
        {
            get { return (string)GetValue(AboutMeTitleProperty); }
            set { SetValue(AboutMeTitleProperty, value); }
        }

        public static readonly DependencyProperty AboutMeTitleProperty =
            DependencyProperty.Register("AboutMeTitle", typeof(string), typeof(WatchNowButton), new FrameworkPropertyMetadata("AboutMeTitle", FrameworkPropertyMetadataOptions.AffectsRender));

        public string AboutMeSubTitle
        {
            get { return (string)GetValue(AboutMeSubTitleProperty); }
            set { SetValue(AboutMeSubTitleProperty, value); }
        }

        public static readonly DependencyProperty AboutMeSubTitleProperty =
            DependencyProperty.Register("AboutMeSubTitle", typeof(string), typeof(WatchNowButton), new FrameworkPropertyMetadata("AboutMeSubTitle", FrameworkPropertyMetadataOptions.AffectsRender));
    }
}
