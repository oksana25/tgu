using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf
{
    public partial class MainWindow : Window
    {      
   
        private void button1_Click(object sender, RoutedEventArgs e)  
        {
            Avtors w1 = new Avtors();
            w1.ShowDialog();
        }  
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Books w1 = new Books();
            w1.ShowDialog();
        }

    }
}
