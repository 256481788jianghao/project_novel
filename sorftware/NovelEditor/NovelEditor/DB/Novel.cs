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
        public ObservableCollection<NovelChapter> Chapters { get; set; }
        public Guid GID { get ; }

        public Novel()
        {
            Chapters = new ObservableCollection<NovelChapter>();
            GID = Guid.NewGuid();
        }
    }
}
