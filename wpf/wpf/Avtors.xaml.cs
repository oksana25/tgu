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
using System.Windows.Shapes;
using System.Data;

namespace wpf
{
    public partial class Avtors : Window
    {
        List<Int32> f = new List<Int32>();

        public Avtors()
        {
            try
            {
                InitializeComponent();
                ControllerAvtors.selectAvtor(dGA, f);
            }
            catch (Exception ex)
            {
                textBlock1.Text = ex.Message;
            }
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int32 id = f[dGA.SelectedIndex];
                textBlock1.Text = ControllerAvtors.updateAvtor(textBox2.Text, textBox1.Text, textBox3.Text, id);
                ControllerAvtors.selectAvtor(dGA, f);
            }
            catch (Exception ex)
            {
                textBlock1.Text = ex.Message;
            }
        }

        private void dGA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox1.Text = ((TextBlock)dGA.Columns[0].GetCellContent(dGA.SelectedItem)).Text;
            textBox2.Text = ((TextBlock)dGA.Columns[1].GetCellContent(dGA.SelectedItem)).Text;
            textBox3.Text = ((TextBlock)dGA.Columns[2].GetCellContent(dGA.SelectedItem)).Text;
        }

        private void button1_ClickInput(object sender, RoutedEventArgs e)
        {
            try
            {
                textBlock1.Text = ControllerAvtors.insertAvtor(textBox2.Text, textBox1.Text, textBox3.Text);
                ControllerAvtors.selectAvtor(dGA, f);
            }
            catch (Exception ex)
            {
                textBlock1.Text = ex.Message;
            }
        }

        private void button1_ClickDelete(object sender, RoutedEventArgs e)
        {
            try
            {
                Int32 id = f[dGA.SelectedIndex];
                textBlock1.Text = textBlock1.Text = ControllerAvtors.deleteAvtors(textBox2.Text, textBox1.Text, textBox3.Text, id);
                ControllerAvtors.selectAvtor(dGA, f);
            }
            catch (Exception ex)
            {
                textBlock1.Text = ex.Message;
            }
        }
    }
}
