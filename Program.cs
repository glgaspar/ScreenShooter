using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace screenRecorder
{
    internal class Program
    {
        // import some dll stuff just so I can minimize the console for the capture
        // kinda useless if it screenshots and half the screen is itself
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select option \n0 - to cancel\n1 - for screenshot\n2 - For recording");
                string option = Console.ReadLine();
                IntPtr hWnd = GetConsoleWindow();


                if (option == "1")
                {
                    ShowWindow(hWnd, 0);
                    Shoot();
                    ShowWindow(hWnd, 1);
                    Console.WriteLine("OK, done. Bye...");
                    break;
                }
                else if (option == "2")
                {
                    ShowWindow(hWnd, 0);
                    Rec();
                    ShowWindow(hWnd, 1);
                    Console.WriteLine("OK, done. Bye...");
                    break;
                }
                else if (option == "0")
                {
                    Console.WriteLine("Ending program...");
                    break;
                }
                else
                {
                    Console.WriteLine("Please select a valid option");
                };
            }

        }

        static void Rec()
        {

        }

        static void Shoot()
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // getting screen dimensions
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // creating bitmap obj
            Bitmap captureBitmap = new Bitmap(screenWidth, screenHeight, PixelFormat.Format64bppArgb);


            Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

            Graphics graphic = Graphics.FromImage(captureBitmap);

            graphic.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
            captureBitmap.Save($"{path}/screenShotter.jpg", ImageFormat.Jpeg);
        }
    }
}