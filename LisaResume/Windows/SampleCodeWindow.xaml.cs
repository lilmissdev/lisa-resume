using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;

using LisaResume.Back_End_Code.Classes;
using LisaResume.Pages;

namespace LisaResume.Windows
{
    /// <summary>
    /// Interaction logic for SampleCodeWindow.xaml
    /// </summary>
    public partial class SampleCodeWindow : Window
    {
        private Singleton singleton = Singleton.GetSingleton();
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private Process pDocked;
        private IntPtr hWndOriginalParent;
        private IntPtr hWndDocked;
        public System.Windows.Forms.Panel panel;
        public string FilePath { get; set; }
        public SampleCodeWindow()
        {
            InitializeComponent();
            SampleWindow.Content = new SampleCodePage("");
        }
    }


}
