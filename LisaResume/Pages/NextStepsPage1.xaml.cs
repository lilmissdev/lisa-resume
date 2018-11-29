using System.Windows;
using System.Windows.Controls;

namespace LisaResume.Pages
{
    /// <summary>
    /// Interaction logic for NextStepsPage1.xaml
    /// </summary>
    public partial class NextStepsPage1 : Page
    {
        public NextStepsPage1()
        {
            InitializeComponent();
        }

        private void Button_NoDuh_Click(object sender, RoutedEventArgs e)
        {
            P1.Content = new NextStepsPage2();
        }

        private void P1_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
