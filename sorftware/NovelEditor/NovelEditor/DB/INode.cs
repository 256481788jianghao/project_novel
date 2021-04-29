using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelEditor.DB
{
    interface INode
    {
        string Name { get; set; }
        ObservableCollection<INode> Children { get; set; }
    }
}
