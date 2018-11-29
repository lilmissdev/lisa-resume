using System.Windows;
using System.Windows.Controls;

namespace LisaResume.Controls
{
    /// <summary>
    /// Interaction logic for SampleCode.xaml
    /// </summary>
    public partial class SampleCode : Button
    {
        public SampleCode()
        {
            InitializeComponent();
        }

        public string SampleCodeTitle
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(SampleCode), new FrameworkPropertyMetadata("Title", FrameworkPropertyMetadataOptions.AffectsRender));

        public string SampleCodeSubTitle
        {
            get { return (string)GetValue(SubTitleProperty); }
            set { SetValue(SubTitleProperty, value); }
        }

        public static readonly DependencyProperty SubTitleProperty =
            DependencyProperty.Register("SubTitle", typeof(string), typeof(SampleCode), new FrameworkPropertyMetadata("SubTitle", FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(FrameworkElement), typeof(SampleCode), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
    }
}
