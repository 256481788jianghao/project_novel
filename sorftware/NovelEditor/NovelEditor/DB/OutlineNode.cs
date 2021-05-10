using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace NovelEditor.DB
{
    [AddINotifyPropertyChangedInterfaceAttribute]
    class OutlineNode
    {
        public Guid GID { get; set; }
        public SolidColorBrush BKColor { get; set; }
        public string Content { get; set; }
        public ObservableCollection<OutlineNode> Children { get; }

        public OutlineNode()
        {
            GID = Guid.NewGuid();
            BKColor = Brushes.Red;
            Content = "New";
            Children = new ObservableCollection<OutlineNode>();
        }
    }
}
