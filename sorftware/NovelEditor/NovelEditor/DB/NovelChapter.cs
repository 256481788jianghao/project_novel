using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelEditor.DB
{
    class NovelChapter : INode
    {
        public Guid GID;
        public string Name { get ; set ; }

        ObservableCollection<INode> _Children;
        public ObservableCollection<INode> Children { get => _Children; set => _Children = value; }

        public NovelChapter()
        {
            GID = Guid.NewGuid();
            _Children = new ObservableCollection<INode>();
        }
    }
}
