using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelEditor.DB
{
    class Novel
    {
        public static int XMLContentLength = 1024 * 10; //10M
        public string Name { get ; set ; }
        public List<NovelChapter> Chapters { get; set; }
        public Guid GID { get ; }
        public byte[] XMLContent { get; set; }

        public Novel()
        {
            Chapters = new List<NovelChapter>();
            XMLContent = new byte[XMLContentLength];
            GID = Guid.NewGuid();
        }

        public bool IsNovelGUID(Guid gid)
        {
            return gid == GID;
        }

        public NovelChapter FindChapterByGUID(Guid gid)
        {
            return Chapters.Find(it => it.GID == gid);
        }

        public string AllText
        {
            get
            {
                string allstr = Name+ "\r\n\r\n";
                foreach(NovelChapter chapter in Chapters)
                {
                    allstr += chapter.ChapterIndex.ToString()+"."+chapter.Name+ "\r\n\r\n" + chapter.MainText + "\r\n";
                }
                return allstr;
            }
        }
    }
}
