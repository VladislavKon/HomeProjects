using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameOfLife
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int width;
        int height;
        byte[,,] pixels;
        byte[,,] newPixels;        
        WriteableBitmap wbitmap;
        DispatcherTimer timer = new DispatcherTimer();
        int gen = 0;
        public MainWindow()
        {
            InitializeComponent();            
            
        }
        public void LifeStart()
        {
            width = (int)grid2.ActualWidth;
            height = (int)grid2.ActualHeight;

            wbitmap = new WriteableBitmap(
                width, height, 96/sResolution.Value, 96/sResolution.Value, PixelFormats.Bgra32, null);
            pixels = new byte[height, width, 4];            
            BlackClear(pixels);            
            SetPixels(pixels);
        }
        public void BlackClear(byte[,,] pixels)
        {
            // Clear to black.
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    for (int i = 0; i < 3; i++)
                        pixels[row, col, i] = 0;
                    pixels[row, col, 3] = 255;
                }
            }         
        }
        public void SetPixels(byte[,,] pixels)
        {
            // Copy the data into a one-dimensional array.
            byte[] pixels1d = new byte[height * width * 4];
            int index = 0;
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    for (int i = 0; i < 4; i++)
                        pixels1d[index++] = pixels[row, col, i];
                }
            }

            // Update writeable bitmap with the colorArray to the image.
            Int32Rect rect = new Int32Rect(0, 0, width, height);
            int stride = 4 * width;
            wbitmap.WritePixels(rect, pixels1d, stride, 0);

            // Create an Image to display the bitmap.
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Stretch = Stretch.None;
            image.Margin = new Thickness(0);

            grid2.Children.Add(image);
            
            //Set the Image source.
            image.Source = wbitmap;
        }
        public void LifeGeneration()
        {
            // Red.
            Random random = new Random();
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if(random.Next(12-(int)sDensity.Value)==0)
                    pixels[row, col, 2] = 255;                    
                }
            }
            SetPixels(pixels);
        }
        public void LifeBegins(string mes)
        {
            if (mes == "Start")
            {
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = new TimeSpan(0, 0, 0, 0, 30);
                timer.Start();
            }
            else if (mes == "Stop")
            { 
                timer.Stop();
                timer = new DispatcherTimer();
            }            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            newPixels = new byte[height, width, 4];
            Task t = Task.Run(NextGen);
            Task.WaitAny(t);
            SetPixels(pixels);            
            gen++;
            window.Title = gen.ToString($"Поколение {gen}");
            
        }
        public void NextGen()
        {            
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    newPixels[row, col, 3] = 255;
                    bool hasLife = pixels[row, col, 2] == 255;
                    int count = CountNeighbours(col, row);
                    if (!hasLife && (count == 3))
                    {
                        newPixels[row, col, 2] = 255;
                    }
                    else if (hasLife && (count < 2 || count > 3))
                    {
                        newPixels[row, col, 2] = 0;
                    }
                    else
                    {
                        newPixels[row, col, 2] = pixels[row, col, 2];                        
                    }
                }
            }
            pixels = newPixels;
        }
        public int CountNeighbours(int x, int y) 
        {
            int count=0;
            for (int j = -1; j < 2; j++)
            {
                for (int i = -1; i < 2; i++)
                {
                    var cols = (x + i + width) % width;
                    var rows = (y + j + height) % height;

                    var isSelfChek = (j == 0  && i == 0);
                    if (pixels[rows, cols, 2] == 255 && !isSelfChek)
                         count++;                    
                }
            }
            return count;
        }

        private void bLife_Click(object sender, RoutedEventArgs e)
        {
            LifeStart();                       
            LifeGeneration();
            LifeBegins("Start");
            bLife.IsEnabled = false;
            bDeath.IsEnabled = true;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bDeath.IsEnabled = false;
            LifeStart();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            LifeStart();
        }

        private void bDeath_Click(object sender, RoutedEventArgs e)
        {
            bLife.IsEnabled = true;
            LifeBegins("Stop");
            bDeath.IsEnabled = false;            
        }
    }
}
