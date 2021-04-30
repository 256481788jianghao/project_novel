using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace NovelEditor.DB
{
    class NovelChapter:IComparable<NovelChapter>
    {
        public int ChapterIndex { get; set; }
        public string Name { get ; set ; }

        public Guid GID { get; }
        public byte[] XMLContent { get; set; }
        public NovelChapter()
        {
            GID = Guid.NewGuid();
            XMLContent = new byte[Novel.XMLContentLength];
        }

        public string MainText
        {
            get
            {
                FlowDocument doc = MainDocMgr.ContentToDocument(XMLContent);
                if(doc == null)
                {
                    return "";
                }
                else
                {
                    return MainDocMgr.DocumentToText(doc);
                }
            }
        }

        public int CompareTo(NovelChapter other)
        {
            if(ChapterIndex > other.ChapterIndex)
            {
                return 1;
            }
            else if(ChapterIndex < other.ChapterIndex)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
