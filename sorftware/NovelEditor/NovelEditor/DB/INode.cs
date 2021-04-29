using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelEditor.DB
{
    class INode
    {
        public Guid GID { get; set; }
        public string Name { get; set; }
        public ObservableCollection<INode> Children { get; }

        public INode()
        {
            Children = new ObservableCollection<INode>();
        }

        public INode(Guid gID, string name):this()
        {
            GID = gID;
            Name = name;
        }
    }
}
