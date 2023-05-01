using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace screenRecorder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select option \n0 - to cancel\n1 - for screenshot\n2 - For recording");
                string option = Console.ReadLine();


                if (option == "1")
                {
                    Shoot();
                    Console.WriteLine("OK, done. Bye...");
                    break;
                }
                else if (option == "2")
                {
                    Rec();
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
            captureBitmap.Save($"{path}/screenShooter.jpg", ImageFormat.Jpeg);
        }
    }
}