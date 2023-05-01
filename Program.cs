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
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Console.WriteLine(path);

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