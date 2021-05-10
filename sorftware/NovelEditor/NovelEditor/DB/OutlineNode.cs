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

        public OutlineNode FindInChildren(Guid ID)
        {
            OutlineNode ans = null;
            foreach(OutlineNode item in Children)
            {
                if(item.GID == ID)
                {
                    ans = item;
                }
            }
            return ans;
        }

        public void DelItem(Guid ID)
        {
            OutlineNode node = FindInChildren(ID);
            if(node != null)
            {
                Children.Remove(node);
            }
            else
            {
                if(Children.Count == 0)
                {
                    return;
                }
                else
                {
                    foreach(OutlineNode item in Children)
                    {
                        item.DelItem(ID);
                    }
                }
            }
        }
    }
}
