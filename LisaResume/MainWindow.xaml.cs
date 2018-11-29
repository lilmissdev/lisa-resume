using LisaResume.Windows;

using System.Windows;

using LisaResume.Pages;

namespace LisaResume
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            //var test = new XmlTranslator(Translator.CurrentDocType.Xml, Translator.FutureDocType.Json,
            //                              System.IO.Path
            //                                    .Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            //                                             @"Components\LisaResume.xml"));
            //test.Translate(Translator.FutureDocType.Json);

            InitializeComponent();
        }



        private void Button_WatchNow_Click(object sender, RoutedEventArgs e)
        {
            VideoWindow win2 = new VideoWindow();
            win2.Show();
        }

        private void Button_AboutMe_Click(object sender, RoutedEventArgs e)
        {
            AboutMeWindow win3 = new AboutMeWindow();
            win3.Show();
        }

        private void Button_SampleCode_Click(object sender, RoutedEventArgs e)
        {
            SampleCodeWindow win4 = new SampleCodeWindow();
            win4.WindowStartupLocation =  WindowStartupLocation.CenterScreen;
            win4.SourceInitialized     += (s, a) => win4.WindowState = WindowState.Maximized;
            win4.Show();

            //Main.Content = new SampleCodePage("");
        }

        private void Button_NextSteps_Click(object sender, RoutedEventArgs e)
        {
            image.Visibility = Visibility.Hidden;
            block.Visibility = Visibility.Hidden;
            textBlock.Visibility = Visibility.Hidden;
            aboutMe.Visibility = Visibility.Hidden;
            watchNowButton.Visibility = Visibility.Hidden;
            nextSteps.Visibility = Visibility.Hidden;
            sampleCode.Visibility = Visibility.Hidden;
            Main.Content = new NextStepsPage1();
        }
    }
}
