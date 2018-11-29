using System.Windows;
using System.Windows.Controls;

namespace LisaResume.Pages
{
    /// <summary>
    /// Interaction logic for NextStepsPage6.xaml
    /// </summary>
    public partial class NextStepsPage6 : Page
    {
        public NextStepsPage6()
        {
            InitializeComponent();
        }

        private void Button_Interview_Click(object sender, RoutedEventArgs e)
        {
            P6.Content = new NextStepsPage7();
        }
    }
}
