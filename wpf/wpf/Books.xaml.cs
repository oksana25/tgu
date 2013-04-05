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

namespace wpf
{
    public partial class Books : Window
    {
        List<Int32> f = new List<Int32>();
        List<Int32> b = new List<Int32>();
        List<Int32> b_current = new List<Int32>();
        List<string> b_current_value = new List<string>();

        public Books()
        {
            InitializeComponent();
            ControllerBooks.selectBooks(dGA, f, b, b_current, b_current_value);
            listBox1.ItemsSource = b_current_value;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Int32 id_book = f[dGA.SelectedIndex];
                
                Int32 id_avtor = b_current[listBox1.SelectedIndex];
                textBlock1.Text = ControllerBooks.updateBooks(textBox1.Text, textBox2.Text, id_avtor, id_book);
                ControllerBooks.selectBooks(dGA, f, b, b_current, b_current_value);
                listBox1.ItemsSource = b_current_value;
            }
            catch (Exception ex)
            {
                textBlock1.Text = ex.Message;
            }
        }

        private void dGA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox2.Text = ((TextBlock)dGA.Columns[0].GetCellContent(dGA.SelectedItem)).Text;
            textBox1.Text = ((TextBlock)dGA.Columns[1].GetCellContent(dGA.SelectedItem)).Text;
            listBox1.SelectedIndex = b_current.IndexOf(b[dGA.SelectedIndex]);
        }

        private void button1_ClickInput(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Int32 id_avtor = b_current[listBox1.SelectedIndex];
                textBlock1.Text = ControllerBooks.insertBooks(textBox1.Text, textBox2.Text, id_avtor);
                ControllerBooks.selectBooks(dGA, f, b, b_current, b_current_value);
                listBox1.ItemsSource = b_current_value;
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
                Int32 id_book = f[dGA.SelectedIndex];
                Int32 id_avtor = b[dGA.SelectedIndex];
                textBlock1.Text = textBlock1.Text = ControllerBooks.deleteBooks(textBox1.Text, textBox2.Text, id_avtor, id_book);
                ControllerBooks.selectBooks(dGA, f, b, b_current, b_current_value);
                listBox1.ItemsSource = b_current_value;
            }
            catch (Exception ex)
            {
                textBlock1.Text = ex.Message;
            }
        }
    }
}
