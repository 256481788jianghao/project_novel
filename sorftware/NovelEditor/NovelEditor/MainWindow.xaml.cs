using Microsoft.Win32;
using Newtonsoft.Json;
using NovelEditor.DB;
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
            GVL.Instance.NovelFilePath = filepath;
            try
            {
                Novel newNovel = new Novel();
                newNovel.Name = filename;
                GVL.Instance.CurNovel = newNovel;
                SaveToFile(GVL.Instance.NovelFilePath);
                GVL.Instance.UpdateTreeView();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void SaveToFile(string filepath)
        {
            string alltext = JsonConvert.SerializeObject(GVL.Instance);
            File.WriteAllText(filepath, alltext);
        }

        GVL ReadFromFile(string filepath)
        {
            try
            {
                string alltext = File.ReadAllText(filepath);
                GVL tempInstance = JsonConvert.DeserializeObject<GVL>(alltext);
                tempInstance.NovelFilePath = filepath;
                return tempInstance;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            
        }

        private void MenuItem_Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "project file|*.json|all files|*.*";
            if(dialog.ShowDialog() == true)
            {
                GVL.Instance.CopyFrom(ReadFromFile(dialog.FileName));
            }
        }

        private void TreeView_MenuItem_AddChapter_Click(object sender, RoutedEventArgs e)
        {
            AddChapterForm form = new AddChapterForm();
            form.ShowDialog();
        }

        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveToFile(GVL.Instance.NovelFilePath);
                MessageBox.Show("success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void TreeView_Novel_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void TreeView_Novel_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            INode item = e.NewValue as INode;
            if(item != null)
            {
                GVL.Instance.CurNode = new INode(item.GID, item.Name);
                if (GVL.Instance.CurNovel.IsNovelGUID(item.GID))
                {
                    GVL.Instance.Panel_Cpation = GVL.Instance.CurNovel.Name;
                }
                else
                {
                    NovelChapter chapter = GVL.Instance.CurNovel.FindChapterByGUID(item.GID);
                    if(chapter != null)
                    {
                        GVL.Instance.Panel_Cpation = chapter.Name;
                    }
                }
            }
        }

        private void TextBox_Panel_Cpation_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (GVL.Instance.CurNovel.IsNovelGUID(GVL.Instance.CurNode.GID))
            {
                GVL.Instance.CurNovel.Name = box.Text;
            }
            else
            {
                NovelChapter chapter = GVL.Instance.CurNovel.FindChapterByGUID(GVL.Instance.CurNode.GID);
                if (chapter != null)
                {
                    chapter.Name = box.Text;
                }
            }
            GVL.Instance.UpdateTreeView();
        }
    }
}
