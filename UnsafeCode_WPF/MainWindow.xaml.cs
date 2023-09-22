using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace UnsafeCode_WPF
{
    //TASK 1
    //Develop an application that utilizes inherited code.
    //You need to use the MessageBox function from the Windows API.
    //Display the message 'Hello, World!' using MessageBox.
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
