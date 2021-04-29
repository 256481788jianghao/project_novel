using NovelEditor.DB;
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
    /// AddChapterForm.xaml 的交互逻辑
    /// </summary>
    public partial class AddChapterForm : Window
    {
        public AddChapterForm()
        {
            InitializeComponent();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            string ChapterIndex = InputBox_ChapterIndex.ValueStr.ToString();
            string ChapterName = InputBox_ChapterName.ValueStr.ToString();

            if(!string.IsNullOrEmpty(ChapterIndex) && !string.IsNullOrEmpty(ChapterName))
            {
                try
                {
                    if(GVL.Instance.CurNovelTree.Count > 0)
                    {
                        NovelChapter chapter = new NovelChapter();
                        chapter.ChapterIndex = Convert.ToInt32(ChapterIndex);
                        chapter.Name = ChapterName;
                        GVL.Instance.CurNovel.Chapters.Add(chapter);
                        GVL.Instance.UpdateTreeView();
                    }

                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("index or name is null");
            }
        }
    }
}
