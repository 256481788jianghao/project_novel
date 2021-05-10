using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;

namespace NovelEditor.DB
{
    [JsonObject(MemberSerialization.OptOut)]
    class NovelChapter:IComparable<NovelChapter>
    {
        public int ChapterIndex { get; set; }
        public string Name { get ; set ; }
        public Guid GID { get; }
        public string DocumentStr { get; set; }
        public string Instraction { get; set; }
        //public List<NovelChapterLabel> Labels { get; set; }


        public NovelChapter()
        {
            GID = Guid.NewGuid();
            //Labels = new List<NovelChapterLabel>();
        }

        public string MainText ="";

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
