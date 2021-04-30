using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
