using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelHelper.DataStruct
{
    public class NovelPeople
    {
        public Guid GID { get; set; }
        public string People_Name { get; set; }
        public string People_IDStr { get; set; }
        public string People_Intruduction { get; set; }
        public List<string> People_Label_List { get; set; } = new List<string>();
        public List<NovelPeopleRelation> People_Relation_List { get; set; } = new List<NovelPeopleRelation>();

        public NovelPeople()
        {
            GID = Guid.NewGuid();
        }
    }
}
