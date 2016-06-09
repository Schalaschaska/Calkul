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
using System.IO;

namespace C6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Document.Blocks.Clear();
            Window2 w = new Window2();
                w.ShowDialog();
            if (w.flag == 1) this.label.Content = "Введённое число " + w.textBox1.Text;
            if (w.flag == 0) this.label.Content = "Отменено";
        }

        private void btnFileNumber_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Document.Blocks.Clear();
            StreamReader fp = new StreamReader("number.txt");
            string str = fp.ReadLine();
            int n = Convert.ToInt32(str);
            n++;
            str = "Число из файла + 1 = " + Convert.ToString(n);
            richTextBox.AppendText(str);
            fp.Close();

        }

        private void btnFileText_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Document.Blocks.Clear();
            var openFile = new Microsoft.Win32.OpenFileDialog();
            if (openFile.ShowDialog() == false) return;
            StreamReader fp = new StreamReader(openFile.FileName, Encoding.UTF8);
            string str = "";
            while (!fp.EndOfStream)
            {
                str = fp.ReadLine();
                richTextBox.AppendText(str + "\n");
            }
            fp.Close();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            richTextBox.Document.Blocks.Clear();
            this.label.Content = "";
        }
    }
}
