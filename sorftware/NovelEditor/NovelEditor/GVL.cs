using NovelEditor.DB;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelEditor
{
    [AddINotifyPropertyChangedInterfaceAttribute]
    class GVL
    {
        static GVL _instance;
        public static GVL Instance { get { return _instance; } }

        public static void Init()
        {
            _instance = new GVL();
        }

        public Novel CurNovel;
        public Novel LastNovel;
    }
}
