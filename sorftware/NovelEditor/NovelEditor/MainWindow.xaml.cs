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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace NovelEditor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer m_SaveTimer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GVL.Init();
            this.DataContext = GVL.Instance;
            m_SaveTimer = new DispatcherTimer();
            m_SaveTimer.Tick += new EventHandler(SaveTimerCB);
            m_SaveTimer.Interval = TimeSpan.FromSeconds(10);
            m_SaveTimer.Start();
        }

        void SaveTimerCB(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(GVL.Instance.NovelFilePath))
                {
                    SaveToFile(GVL.Instance.NovelFilePath);
                    GVL.Instance.Label_WritePanel_Tip_Content = "atuo Save : " + DateTime.Now.ToString();
                }
                else
                {
                    //MessageBox.Show("请导入或新建Novel");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                GVL.Instance.Label_WritePanel_Tip_Content = "auto Save error : " + DateTime.Now.ToString();
            }
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
                    try
                    {
                        if (!string.IsNullOrEmpty(GVL.Instance.CurNovel.DocumentStr))
                        {
                            FlowDocument doc = XamlReader.Parse(GVL.Instance.CurNovel.DocumentStr) as FlowDocument;
                            RichTextBox_MainDoc.Document = doc;
                        }
                        else
                        {
                            RichTextBox_MainDoc.Document = new FlowDocument();
                        }
                    }
                    catch(Exception ex)
                    {

                    }
                    
                }
                else
                {
                    NovelChapter chapter = GVL.Instance.CurNovel.FindChapterByGUID(item.GID);
                    if(chapter != null)
                    {
                        GVL.Instance.Panel_Cpation = chapter.Name;
                        try
                        {
                            if (!string.IsNullOrEmpty(chapter.DocumentStr))
                            {
                                FlowDocument doc = XamlReader.Parse(chapter.DocumentStr) as FlowDocument;
                                RichTextBox_MainDoc.Document = doc;
                            }
                            else
                            {
                                RichTextBox_MainDoc.Document = new FlowDocument();
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }

        private void TextBox_Panel_Cpation_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (GVL.Instance.CurNode != null)
            {
                if (GVL.Instance.CurNovel.IsNovelGUID(GVL.Instance.CurNode.GID))
                {
                    //FIXME:TextBox仅在失去焦点时才进行twoway的更新
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) && e.KeyboardDevice.IsKeyDown(Key.S))
            {
                try
                {
                    if (File.Exists(GVL.Instance.NovelFilePath))
                    {
                        SaveToFile(GVL.Instance.NovelFilePath);
                        GVL.Instance.Label_WritePanel_Tip_Content = "Save : " + DateTime.Now.ToString();
                    }
                    else
                    {
                        MessageBox.Show("请导入或新建Novel");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    GVL.Instance.Label_WritePanel_Tip_Content = "Save error : " + DateTime.Now.ToString();
                }
                e.Handled = true;
            }
        }

        private void RichTextBox_MainDoc_TextChanged(object sender, TextChangedEventArgs e)
        {
            RichTextBox rbox = sender as RichTextBox;
            if (GVL.Instance.CurNode != null)
            {
                if (GVL.Instance.CurNovel.IsNovelGUID(GVL.Instance.CurNode.GID))
                {
                    GVL.Instance.CurNovel.DocumentStr = XamlWriter.Save(RichTextBox_MainDoc.Document);
                }
                else
                {
                    NovelChapter chapter = GVL.Instance.CurNovel.FindChapterByGUID(GVL.Instance.CurNode.GID);
                    if (chapter != null)
                    {
                        chapter.DocumentStr = XamlWriter.Save(RichTextBox_MainDoc.Document);
                        TextRange range = new TextRange(RichTextBox_MainDoc.Document.ContentStart, RichTextBox_MainDoc.Document.ContentEnd);
                        chapter.MainText = range.Text;
                    }
                }
                GVL.Instance.UpdateTreeView();
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl item = sender as TabControl;
            if (item != null)
            {
                if(item.SelectedIndex == 1 && GVL.Instance.CurNovel != null)
                {
                    GVL.Instance.AllText = GVL.Instance.CurNovel.AllText;
                }
            }
            
        }
    }
}
