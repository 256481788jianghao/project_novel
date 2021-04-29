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

namespace NovelEditor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GVL.Init();
            this.DataContext = GVL.Instance;
        }

        private void MenuItem_NewNovel_Click(object sender, RoutedEventArgs e)
        {
            NewNovelForm form = new NewNovelForm();
            form.NewNovelEvent += new NewNovelForm.NewNovelDelegate(NewNovelCB);
            form.ShowDialog();
        }

        void NewNovelCB(string filename, string filepath)
        {
            MessageBox.Show(filename);
        }
    }
}
