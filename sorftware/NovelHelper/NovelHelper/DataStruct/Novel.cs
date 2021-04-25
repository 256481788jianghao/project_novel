using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelHelper.DataStruct
{
    [AddINotifyPropertyChangedInterfaceAttribute]
    public class Novel
    {
        public string ConfigFilePath { get; set; } = "NO FILE";
        public string Novel_Name { get; set; }
        public string Novel_Intruduction { get; set; }
        public List<NovelPeople> Novel_People_List { get; set; } = new List<NovelPeople>();
    }
}
