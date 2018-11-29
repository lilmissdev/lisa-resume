using System.Windows;
using System.Windows.Controls;

namespace LisaResume.Controls
{
    /// <summary>
    /// Interaction logic for NextSteps.xaml
    /// </summary>
    public partial class NextSteps : Button
    {
        public NextSteps()
        {
            InitializeComponent();
        }

        public string NextStepsTitle
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(NextSteps), new FrameworkPropertyMetadata("Title", FrameworkPropertyMetadataOptions.AffectsRender));

        public string NextStepsSubTitle
        {
            get { return (string)GetValue(SubTitleProperty); }
            set { SetValue(SubTitleProperty, value); }
        }

        public static readonly DependencyProperty SubTitleProperty =
            DependencyProperty.Register("SubTitle", typeof(string), typeof(NextSteps), new FrameworkPropertyMetadata("SubTitle", FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(FrameworkElement), typeof(NextSteps), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
    }
}

