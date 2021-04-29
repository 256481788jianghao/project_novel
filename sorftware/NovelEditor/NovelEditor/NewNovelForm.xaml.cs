using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace NovelEditor
{
    /// <summary>
    /// NewNovelForm.xaml 的交互逻辑
    /// </summary>
    public partial class NewNovelForm : Window
    {
        public delegate void NewNovelDelegate(string filename, string filepath);
        public event NewNovelDelegate NewNovelEvent;
        public NewNovelForm()
        {
            InitializeComponent();
        }

        private void Button_FilePathSelect_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = InputBox_FileName.ValueStr.ToString() + ".json";
            dialog.Filter = "project file|*.json|all files|*.*";
            if(dialog.ShowDialog() == true)
            {
                InputBox_FilePath.ValueStr = dialog.FileName;
            }
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            string filename = InputBox_FileName.ValueStr.ToString();
            string filepath = InputBox_FilePath.ValueStr.ToString();
            if(!string.IsNullOrEmpty(filename) && !string.IsNullOrEmpty(filepath))
            {
                NewNovelEvent?.Invoke(filename, filepath);
                this.Close();
            }
            else
            {
                MessageBox.Show("Novel name and path is null");
            }
            
        }
    }
}
