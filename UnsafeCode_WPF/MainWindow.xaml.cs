using System.Runtime.InteropServices;
using System;
using System.Windows;

namespace UnsafeCode_WPF
{
    //TASK 2
    //Develop an application that utilizes inherited code.
    //You need to use the MessageBox function from the Windows API.
    //The user guesses a number from 0 to 100. 
    //The computer tries to guess.Provide the option for replaying the game.
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            int userNumber = GetUserNumber();
            int computerNumber = GetComputerNumber();

            ShowResult(userNumber, computerNumber);

            if (MessageBox(IntPtr.Zero, "Do you want to play again?", "Play Again?", 0x0004 | 0x0030) == 6)
            {
                StartGame_Click(sender, e);
            }
        }

        private int GetUserNumber()
        {
            return int.Parse(Microsoft.VisualBasic.Interaction.InputBox("Guess a number from 0 to 10:"));
        }

        private int GetComputerNumber()
        {
            return random.Next(11);
        }

        private void ShowResult(int userNumber, int computerNumber)
        {
            int result = userNumber.CompareTo(computerNumber);

            if (result < 0)
            {
                MessageBox(IntPtr.Zero, "Too low! You lose.", "Result", 0x00000010);
            }
            else if (result > 0)
            {
                MessageBox(IntPtr.Zero, "Too high! You lose.", "Result", 0x00000010);
            }
            else
            {
                MessageBox(IntPtr.Zero, "You win!", "Result", 0x00000040);
            }
        }
    }
}
