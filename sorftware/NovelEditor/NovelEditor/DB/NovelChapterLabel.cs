using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelEditor.DB
{
    class NovelChapterLabel
    {
        public Guid GID { get; set; }
        public string LabelType { get; set; }
        public string LabelContent { get; set; }

        public NovelChapterLabel()
        {
            GID = Guid.NewGuid();
        }
    }
}
