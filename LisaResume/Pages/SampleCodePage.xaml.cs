using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;

using LisaResume.Back_End_Code;
using LisaResume.Back_End_Code.Classes;

using Path = System.IO.Path;

namespace LisaResume.Pages
{
    /// <summary>
    /// Interaction logic for SampleCodePage.xaml
    /// </summary>
    public partial class SampleCodePage : Page
    {
        private Singleton singleton = Singleton.GetSingleton();

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private Process                    pDocked;
        private IntPtr                     hWndOriginalParent;
        private IntPtr                     hWndDocked;
        public  System.Windows.Forms.Panel panel;

        public string FilePath { get; set; }

        public SampleCodePage(string path)
        {
            InitializeComponent();

            object o   = SampleCodePages.Content;

            if ( path == "" )
            {
                FilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                                  @"Components\DefaultLisaResume.json");
                path = FilePath;
                JsonTranslator json = new JsonTranslator(Translator.CurrentDocType.Json,
                                                         Translator.FutureDocType.Json, FilePath);
                json.Translate(Translator.FutureDocType.Json);

                Clipboard.SetText(FilePath);
            }

            panel      = new System.Windows.Forms.Panel();
            host.Child = panel;
            dockIt("notepad.exe", path);
        }

        private void dockIt(string utility, string path)
        {
            if ( hWndDocked != IntPtr.Zero )
            {
                return;
            }

            pDocked = Process.Start(utility, path);

            while ( hWndDocked == IntPtr.Zero )
            {
                pDocked.WaitForInputIdle(1000);
                pDocked.Refresh();
                if ( pDocked.HasExited )
                {
                    return;
                }

                hWndDocked = pDocked.MainWindowHandle;
            }

            hWndOriginalParent = SetParent(hWndDocked, panel.Handle);
            SizeChanged += window_SizeChanged;

            AlignToPannel();
        }

        private void AlignToPannel()
        {
            MoveWindow(hWndDocked, 0, 0, panel.Width, panel.Height, true);
        }

        void window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AlignToPannel();
        }

        private void ListBoxItem_ViewCurrentDocumentType_OnSelected(object p_sender, RoutedEventArgs p_e)
        {
            FilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                              @"Components\DefaultLisaResume.json");
            JsonTranslator json = new JsonTranslator(Translator.CurrentDocType.Json,
                                                     Translator.FutureDocType.Json, FilePath);
            json.Translate(Translator.FutureDocType.Json);

            Clipboard.SetText(FilePath);

            //SampleCodePages.Content = new SampleCodePage(FilePath);
        }

        private void ListBoxItem_ViewHtmlDocumentType_OnSelected(object p_sender, RoutedEventArgs p_e)
        {
            if ( singleton.DocumentClass is JsonTranslator translatorJson )
            {
                translatorJson.Translate(Translator.FutureDocType.Html);
                Clipboard.SetText(Path.ChangeExtension(translatorJson.FilePath,
                                                                 translatorJson.GetFutureDocType(translatorJson
                                                                                                    .FutureDocumentType)));
                FilePath = translatorJson.FilePath;
            }

            else if ( singleton.DocumentClass is XmlTranslator translatorXml )
            {
                translatorXml.Translate(Translator.FutureDocType.Html);
                Clipboard.SetText(translatorXml.FilePath);
                FilePath = translatorXml.FilePath;
            }

            else if ( singleton.DocumentClass is HtmlTranslator translatorHtml )
            {
                translatorHtml.Publish(translatorHtml.FilePath);
                Clipboard.SetText(translatorHtml.FilePath);
                FilePath = translatorHtml.FilePath;
            }

            Clipboard.SetText(FilePath);
            
            SampleCodePages.Content = new SampleCodePage(FilePath);
        }

        private void ListBoxItem_ViewJsonDocumentType_OnSelected(object p_sender, RoutedEventArgs p_e)
        {
            if ( singleton.DocumentClass is JsonTranslator translatorJson )
            {
                translatorJson.Publish(translatorJson.FilePath);
                Clipboard.SetText(translatorJson.FilePath);
                FilePath = translatorJson.FilePath;
            }

            else if ( singleton.DocumentClass is XmlTranslator translatorXml )
            {
                translatorXml.Translate(Translator.FutureDocType.Json);
                Clipboard.SetText(translatorXml.FilePath);
                FilePath = translatorXml.FilePath;
            }

            else if ( singleton.DocumentClass is HtmlTranslator translatorHtml )
            {
                translatorHtml.Translate(Translator.FutureDocType.Json);
                Clipboard.SetText(translatorHtml.FilePath);
                FilePath = translatorHtml.FilePath;
            }

            Clipboard.SetText(FilePath);
            SampleCodePages.Content = new SampleCodePage(FilePath);
        }

        private void ListBoxItem_ViewXmlDocumentType_OnSelected(object p_sender, RoutedEventArgs p_e)
        {
            if ( singleton.DocumentClass is JsonTranslator translatorJson )
            {
                if ( translatorJson.FilePath.Contains("Default") )
                {
                    translatorJson.FilePath =
                        Path
                              .Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                       @"Components\LisaResume.json");
                    Clipboard.SetText(Path.Combine(Path.GetDirectoryName(translatorJson.FilePath),
                                                             "LisaResume.xml"));
                }

                translatorJson.Translate(Translator.FutureDocType.Xml);
                Clipboard.SetText(Path.Combine(Path.GetDirectoryName(translatorJson.FilePath),
                                                         "LisaResume.xml"));

                FilePath = translatorJson.FilePath;
            }

            else if ( singleton.DocumentClass is XmlTranslator translatorXml )
            {
                translatorXml.Publish(translatorXml.FilePath);
                Clipboard.SetText(translatorXml.FilePath);
                FilePath = translatorXml.FilePath;
            }

            else if ( singleton.DocumentClass is HtmlTranslator translatorHtml )
            {
                translatorHtml.Translate(Translator.FutureDocType.Xml);
                Clipboard.SetText(translatorHtml.FilePath);
                FilePath = translatorHtml.FilePath;
            }

            Clipboard.SetText(FilePath);
            SampleCodePages.Content = new SampleCodePage(FilePath);
        }


        private void ListBoxItem_ViewWordDocumentType_OnSelected(object p_sender, RoutedEventArgs p_e)
        {
            Process.Start("word.exe",
                          Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                       @"Components\LisaResume.docx"));
        }

        private void ButtonBase_OnClick(object p_sender, RoutedEventArgs p_e)
        {
            (Application.Current.MainWindow.FindName("Main") as Frame).Source = null;
        }
    }
}

