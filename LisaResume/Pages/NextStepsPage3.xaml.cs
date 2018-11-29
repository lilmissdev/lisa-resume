using System.Windows;
using System.Windows.Controls;

namespace LisaResume.Pages
{
    /// <summary>
    /// Interaction logic for NextStepsPage3.xaml
    /// </summary>
    public partial class NextStepsPage3 : Page
    {
        public NextStepsPage3()
        {
            InitializeComponent();
        }

        private void Button_TellMeMore_Click(object sender, RoutedEventArgs e)
        {
            P3.Content = new NextStepsPage5();
        }
    }
}
