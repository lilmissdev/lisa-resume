using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace LisaResume.Pages
{
    /// <summary>
    /// Interaction logic for NextStepsPage8.xaml
    /// </summary>
    public partial class NextStepsPage8 : Page
    {
        public NextStepsPage8()
        {
            InitializeComponent();
        }

        private void Button_ThrowingShade_Click(object sender, RoutedEventArgs e)
        {


            //P8.Content = new MainWindow();
            var address = "lisaconnell@gmail.com";
            var body =
                @"Dear Lisa:
    Your resume application program was totally rad. I am so powerfully impressed that I would like to offer you the job right now. What time works best for you for setting up an interview?
    I am confident that you will be a great member of our team.

Thank you,
Brian Hajost";

            var subject = "Let's schedule an interview.";
            //Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
            //Microsoft.Office.Interop.Outlook.MailItem oMailItem =
            //    (Microsoft.Office.Interop.Outlook.MailItem) oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType
            //                                                                         .olMailItem);
            //Microsoft.Office.Interop.Outlook.Inspector oInspector = oMailItem.GetInspector;
            //oMailItem.To = address;
            //oMailItem.Body = body;
            //oMailItem.Subject = subject;
            //oMailItem.Display(true);


            Process.Start("outlook.exe", $"mailto:{address}?subject={subject}&body={body}");
        }
    }
}
