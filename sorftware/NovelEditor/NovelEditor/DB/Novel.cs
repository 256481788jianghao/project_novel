using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelEditor.DB
{
    class Novel : INode
    {
        public string Name { get ; set ; }

        public ObservableCollection<INode> Chapters { get; set; }
        public ObservableCollection<INode> Children { 
            get
            {
                return Chapters;
            }

            set
            {
                Chapters = value;
            }
        }

        public Novel()
        {
            Chapters = new ObservableCollection<INode>();
        }
    }
}
