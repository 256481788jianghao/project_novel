using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelEditor.DB
{
    class NovelChapter
    {
        public int ChapterIndex { get; set; }
        public string Name { get ; set ; }

        public Guid GID { get; }
        public NovelChapter()
        {
            GID = Guid.NewGuid();
        }
    }
}
