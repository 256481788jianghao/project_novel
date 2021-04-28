using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelHelper.DataStruct
{
    public class NovelPeopleRelation
    {
        /// <summary>
        /// 关系名称
        /// </summary>
        public string Relation_Name { get; set; }
        /// <summary>
        /// 关系目标人
        /// </summary>
        public NovelPeople Relation_TargetPeople { get; set; }
    }
}
