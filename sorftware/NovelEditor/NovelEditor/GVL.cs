using Newtonsoft.Json;
using NovelEditor.DB;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace NovelEditor
{
    [AddINotifyPropertyChangedInterfaceAttribute]
    [JsonObject(MemberSerialization.OptOut)]
    class GVL
    {
        static GVL _instance;
        public static GVL Instance { get { return _instance; } }

        public static void Init()
        {
            _instance = new GVL();
        }

        public GVL()
        {
            CurNovelTree = new ObservableCollection<INode>();
            ChapterLabelList = new ObservableCollection<NovelChapterLabel>();
            OutlineTree = new ObservableCollection<OutlineNode>();
        }

        public string NovelFilePath { get; set; }
        public Novel CurNovel { get; set; }
        public ObservableCollection<OutlineNode> OutlineTree { get; set; }

        [JsonIgnore]
        public OutlineNode CurOutlineNode { get; set; } = null;

        [JsonIgnore]
        public ObservableCollection<INode> CurNovelTree { get; set; }

        [JsonIgnore]
        public ObservableCollection<NovelChapterLabel> ChapterLabelList { get; set; }

        [JsonIgnore]
        public INode CurNode { get; set; }

        [JsonIgnore]
        public string Panel_Cpation { get; set; }
        
        [JsonIgnore]
        public string Label_WritePanel_Tip_Content { get; set; }
        
        [JsonIgnore]
        public string AllText { get; set; }
      
        public void CopyFrom(GVL other)
        {
            this.NovelFilePath = other.NovelFilePath;
            this.CurNovel = other.CurNovel;
            UpdateTreeView();
            foreach(OutlineNode node in other.OutlineTree)
            {
                this.OutlineTree.Add(node);
            }
        }

        public void UpdateTreeView()
        {
            CurNovelTree.Clear();
            INode rootNode = new INode(CurNovel.GID, CurNovel.Name+"("+ GetStrLength(CurNovel.AllText).ToString()+")");
            CurNovel.Chapters.Sort();
            foreach(NovelChapter item in CurNovel.Chapters)
            {
                if (item.MainText != null)
                {
                    rootNode.Children.Add(new INode(item.GID, item.ChapterIndex.ToString() + "." + item.Name + "(" + GetStrLength(item.MainText).ToString() + ")"));
                }
            }
            CurNovelTree.Add(rootNode);
        }

        int GetStrLength(string s)
        {
            return s.Replace("\r\n","").Length;
        }
    }
}
