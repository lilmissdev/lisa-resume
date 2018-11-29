using System.Windows;
using System.Windows.Controls;

namespace LisaResume.Pages
{
    /// <summary>
    /// Interaction logic for NextStepsPage7.xaml
    /// </summary>
    public partial class NextStepsPage7 : Page
    {
        public NextStepsPage7()
        {
            InitializeComponent();
        }

        private void Button_YouTricksyDevil_Click(object sender, RoutedEventArgs e)
        {
            P7.Content = new NextStepsPage8();
        }
    }
}
