using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Threading;

namespace UnsafeCode_WPF
{
    //TASK 4
    //Develop an application that utilizes inherited code.
    //You need to use the FindWindow function(window search in the system) and SendMessage(message sending) from the Windows API.
    //The application should search for the Notepad window (a standard Windows program) and display the current time in the title of the Notepad window.
    //The application should update the time in the Notepad title every second.
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        private const int WM_SETTEXT = 0x000C;

        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            IntPtr notepadHandle = FindWindow(null, "Untitled - Notepad");

            if (notepadHandle != IntPtr.Zero)
            {
                string currentTime = DateTime.Now.ToString("HH:mm:ss");
                SendMessage(notepadHandle, WM_SETTEXT, 0, Marshal.StringToHGlobalAuto(currentTime));
            }
        }

        private void UpdateNotepadTitle_Click(object sender, RoutedEventArgs e)
        {
            Timer_Tick(sender, e);
        }
    }
}
