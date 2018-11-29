using System.Windows;
using System.Windows.Controls;

namespace LisaResume.Pages
{
    /// <summary>
    /// Interaction logic for NextStepsPage2.xaml
    /// </summary>
    public partial class NextStepsPage2 : Page
    {
        public NextStepsPage2()
        {
            InitializeComponent();
        }

        private void OnlyDevelopersWillSeeThatThisChoiceDoesntMatter(object sender, RoutedEventArgs e)
        {
            P2.Content = new NextStepsPage3();
        }

        private void P2_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
