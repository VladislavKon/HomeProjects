using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Data.SqlClient;

namespace Ichiban
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class windowAuto : Window
    {
        public windowAuto()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void tClose_MouseEnter(object sender, MouseEventArgs e)
        {
            tClose.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        }

        private void tClose_MouseLeave(object sender, MouseEventArgs e)
        {
            tClose.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            var windowReg = new windowReg();
            windowReg.Show();
        }
    }
}
