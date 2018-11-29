using System.Windows;
using System.Windows.Controls;

namespace LisaResume.Pages
{
    /// <summary>
    /// Interaction logic for NextStepsPage5.xaml
    /// </summary>
    public partial class NextStepsPage5 : Page
    {
        public NextStepsPage5()
        {
            InitializeComponent();
        }

        private void Button_Oh_Click(object sender, RoutedEventArgs e)
        {
            P5.Content = new NextStepsPage6();
        }
    }
}
