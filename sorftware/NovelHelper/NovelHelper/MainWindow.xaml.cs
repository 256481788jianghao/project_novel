using EasyGoodLookUI;
using Microsoft.Win32;
using Newtonsoft.Json;
using NovelHelper.DataStruct;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace NovelHelper
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowEx
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void SaveConfig()
        {
            if (GVL.G_Novel == null || string.IsNullOrEmpty(GVL.G_Novel.ConfigFilePath))
            {
                SaveFileDialog dialog = new SaveFileDialog();
                if (dialog.ShowDialog() == true)
                {
                    GVL.G_Novel = new Novel();
                    GVL.G_Novel.ConfigFilePath = dialog.FileName;
                    string alltext = JsonConvert.SerializeObject(GVL.G_Novel);
                    File.WriteAllText(GVL.G_Novel.ConfigFilePath, alltext);
                    this.DataContext = GVL.G_Novel;
                }
            }
            else
            {
                string alltext = JsonConvert.SerializeObject(GVL.G_Novel);
                File.WriteAllText(GVL.G_Novel.ConfigFilePath, alltext);
                MessageBox.Show("保存成功");
            }

        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveConfig();
        }

        private void Button_Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == true)
            {
                string alltext = File.ReadAllText(dialog.FileName);
                GVL.G_Novel = JsonConvert.DeserializeObject<Novel>(alltext);
                GVL.G_Novel.ConfigFilePath = dialog.FileName;
                this.DataContext = GVL.G_Novel;
            }
        }

        private void WindowEx_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = GVL.G_Novel;
        }

        private void WindowEx_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) && e.KeyboardDevice.IsKeyDown(Key.S))
            {
                //SaveConfig();
            }
        }
    }
}
