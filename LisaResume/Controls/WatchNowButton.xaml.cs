using System.Windows;
using System.Windows.Controls;

namespace LisaResume.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class WatchNowButton : Button
    {

        public WatchNowButton()
        {
            InitializeComponent();

            
        }

        public string WatchNowTitle
        {
            get { return (string)GetValue(WatchNowTitleProperty); }
            set { SetValue(WatchNowTitleProperty, value); }
        }

        public static readonly DependencyProperty WatchNowTitleProperty =
            DependencyProperty.Register("WatchNowTitle", typeof(string), typeof(WatchNowButton), new FrameworkPropertyMetadata("WatchNowTitle", FrameworkPropertyMetadataOptions.AffectsRender));

        public string WatchNowSubTitle
        {
            get { return (string)GetValue(WatchNowSubTitleProperty); }
            set { SetValue(WatchNowSubTitleProperty, value); }
        }

        public static readonly DependencyProperty WatchNowSubTitleProperty =
            DependencyProperty.Register("WatchNowSubTitle", typeof(string), typeof(WatchNowButton), new FrameworkPropertyMetadata("WatchNowSubTitle", FrameworkPropertyMetadataOptions.AffectsRender));

        public FrameworkElement WatchNowImage
        {
            get { return (FrameworkElement)GetValue(WatchNowImageProperty); }
            set { SetValue(WatchNowImageProperty, value); }
        }

        public static readonly DependencyProperty WatchNowImageProperty =
            DependencyProperty.Register("WatchNowImage", typeof(FrameworkElement), typeof(WatchNowButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
    }
}
