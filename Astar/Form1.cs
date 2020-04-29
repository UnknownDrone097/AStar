using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace AStar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sx.Text = "0"; sy.Text = "0";
            ex.Text = "49"; ey.Text = "49";
            length.Text = "50"; width.Text = "50";
            density.Text = "0.7";
        }
        private static readonly ImageConverter _imageConverter = new ImageConverter();
        public void InitTimer()
        {
            Timer timer = new Timer();
            timer = new Timer();
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Interval = 2000; // in miliseconds
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RunBtn_Click(sender, e);
        }
        private void RunBtn_Click(object sender, EventArgs e)
        {
            //Input validation
            bool one = int.TryParse(sx.Text, out int sxi);
            bool two = int.TryParse(sy.Text, out int syi);
            bool three = int.TryParse(ex.Text, out int exi);
            bool four = int.TryParse(ey.Text, out int eyi);
            bool five = int.TryParse(length.Text, out int li);
            bool six = int.TryParse(width.Text, out int wi);
            bool seven = double.TryParse(density.Text, out double d);

            if (sxi < 0 || syi < 0 || exi >= li || eyi >= wi || !one || d > 1
                || !two || !three || !four || !five || !six || !seven)
            { MessageBox.Show("Invalid inputs"); return; }
            if (li > 151 || wi > 151)
            { MessageBox.Show("Size must be no larger than 150"); return; }

            //Algorithm
            int[] start = new int[2] { sxi, syi };
            int[] end = new int[2] { exi, eyi };
            AStar AS = new AStar(li, wi, start, end);
            int iterator = 0;
        //run the maze algorithm until a solution is found or until it does so X times
        start:
            AS.Obstacles = AS.GenerateMaze(li, wi, start, end, d);
            List<int[]> list = AS.Algorithm(start, end);
            if (list.Count == 0 && iterator < 50) { iterator++; goto start; }

            if (list.Count == 0) { return; }
            foreach (int[] i in list)
            {
                AS.Obstacles[i[0], i[1]] = AStar.PathShade / 2;
            }
            AS.Scaler(ImageBox.Size.Height, ImageBox.Size.Width);
            ImageBox.Image = FromTwoDimIntArrayGray(AS.Obstacles);
            ImageBox.Refresh();
        }
        public static Bitmap FromTwoDimIntArrayGray(Int32[,] data)
        {
            // Transform 2-dimensional Int32 array to 1-byte-per-pixel byte array
            Int32 width = data.GetLength(0);
            Int32 height = data.GetLength(1);
            Int32 byteIndex = 0;
            Byte[] dataBytes = new Byte[height * width];
            for (Int32 y = 0; y < height; y++)
            {
                for (Int32 x = 0; x < width; x++)
                {
                    // logical AND to be 100% sure the int32 value fits inside
                    // the byte even if it contains more data (like, full ARGB).
                    dataBytes[byteIndex] = (Byte)(((UInt32)data[x, y]) & 0xFF);
                    // More efficient than multiplying
                    byteIndex++;
                }
            }
            // generate palette
            Color[] palette = new Color[256];
            for (Int32 b = 0; b < 256; b++)
            {
                if (b == 0 || b == 255) { palette[b] = Color.FromArgb(b, b, b); }
                else { palette[b] = Color.FromArgb(255, 0, 0); }
            }
            // Build image
            return BuildImage(dataBytes, width, height, width, PixelFormat.Format8bppIndexed, palette, null);
        }

        public static Bitmap BuildImage(Byte[] sourceData, Int32 width, Int32 height, Int32 stride, PixelFormat pixelFormat, Color[] palette, Color? defaultColor)
        {
            Bitmap newImage = new Bitmap(width, height, pixelFormat);
            BitmapData targetData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, newImage.PixelFormat);
            Int32 newDataWidth = ((Image.GetPixelFormatSize(pixelFormat) * width) + 7) / 8;
            // Compensate for possible negative stride on BMP format.
            Boolean isFlipped = stride < 0;
            stride = Math.Abs(stride);
            // Cache these to avoid unnecessary getter calls.
            Int32 targetStride = targetData.Stride;
            Int64 scan0 = targetData.Scan0.ToInt64();
            for (Int32 y = 0; y < height; y++)
                Marshal.Copy(sourceData, y * stride, new IntPtr(scan0 + y * targetStride), newDataWidth);
            newImage.UnlockBits(targetData);
            // Fix negative stride on BMP format.
            if (isFlipped)
                newImage.RotateFlip(RotateFlipType.Rotate180FlipX);
            // For indexed images, set the palette.
            if ((pixelFormat & PixelFormat.Indexed) != 0 && palette != null)
            {
                ColorPalette pal = newImage.Palette;
                for (Int32 i = 0; i < pal.Entries.Length; i++)
                {
                    if (i < palette.Length)
                        pal.Entries[i] = palette[i];
                    else if (defaultColor.HasValue)
                        pal.Entries[i] = defaultColor.Value;
                    else
                        break;
                }
                newImage.Palette = pal;
            }
            return newImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitTimer();
        }
    }
}
