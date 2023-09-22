using System;
using System.Runtime.InteropServices;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace UnsafeCode_WPF
{
    //TASK 3
    //Develop an application that utilizes inherited code.
    //You need to use the FindWindow function(window search in the system) and SendMessage(message sending) from the Windows API.
    //The application should search for the Notepad window (a standard Windows program) and send a message to close the main Notepad window.
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string? lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        private const int WM_CLOSE = 0x0010;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseNotepad_Click(object sender, RoutedEventArgs e)
        {
            IntPtr notepadHandle = FindWindow(null, "Untitled - Notepad");

            if (notepadHandle != IntPtr.Zero)
            {
                SendMessage(notepadHandle, WM_CLOSE, 0, IntPtr.Zero);
                MessageBox.Show("Notepad closed");
            }
            else
            {
                MessageBox.Show("Notepad window not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
