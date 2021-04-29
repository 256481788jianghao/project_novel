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
        public string Name { get ; set ; }
        public List<NovelChapter> Chapters { get; set; }
        public Guid GID { get ; }

        public Novel()
        {
            Chapters = new List<NovelChapter>();
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
    }
}
