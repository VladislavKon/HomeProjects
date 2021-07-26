using ImageSharp.Picture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSharp
{
    public partial class Form1 : Form
    {
        private List<Bitmap> _bitmaps = new List<Bitmap>(100);
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _bitmaps.Clear();
                var bitmap = new Bitmap(openFileDialog1.FileName);
                Task.Run(() => Proccesing(bitmap));                
            }
        }
        private void Proccesing(Bitmap bitmap)
        {
            menuStrip1.Enabled = false;
            trackBar1.Enabled = false;
            List<Pixel> pixels = GetPixels(bitmap);            
            Random random = new Random();
            int size = bitmap.Width * bitmap.Height;            
            int pixelPercent = size / 100;
            var currentPixelSet = new List<Pixel>(pixels.Count - pixelPercent);

            for (int i = 1; i < trackBar1.Maximum; i++)
            {
                Text = $"Прогресс обработки {i}%";
                for (int j = 0; j < pixelPercent; j++)
                {                    
                    int index = random.Next(pixels.Count);
                    Task.Run(() => currentPixelSet.Add(pixels[index]));
                    pixels.RemoveAt(index);
                }
                var currentBitmap = new Bitmap(bitmap.Width, bitmap.Height);
                foreach (var pixel in currentPixelSet)
                {
                    Task.Run(() => currentBitmap.SetPixel(pixel.Point.X, pixel.Point.Y, pixel.Color));
                }
                _bitmaps.Add(currentBitmap);
            }
            _bitmaps.Add(bitmap);
            menuStrip1.Enabled = true;
            trackBar1.Enabled = true;
        }
        private List<Pixel> GetPixels(Bitmap bitmap)
        {
            List<Pixel> pixels = new List<Pixel>(bitmap.Width * bitmap.Height);
            for (int x = 0; x < bitmap.Width; x++)
            {                
                for (int y = 0; y < bitmap.Height; y++)
                {
                    pixels.Add(new Pixel
                    {
                        Point = new Point { X = x, Y = y },
                        Color = bitmap.GetPixel(x, y)
                    }); 
                }
            }
            return pixels;
        }
    
       
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Text = $"{trackBar1.Value.ToString()}%";
            if (_bitmaps == null || _bitmaps.Count == 0)
                return;
                pictureBox1.Image = _bitmaps[trackBar1.Value-1];                 
        }
    }
}
