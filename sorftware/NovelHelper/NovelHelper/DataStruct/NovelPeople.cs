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
        /// <summary>
        /// 名字
        /// </summary>
        public string People_Name { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        public string People_IDStr { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string People_Intruduction { get; set; }
        /// <summary>
        /// 标签---性格等特征
        /// </summary>
        public List<string> People_Label_List { get; set; } = new List<string>();
        /// <summary>
        /// 与其他人的关系
        /// </summary>
        public List<NovelPeopleRelation> People_Relation_List { get; set; } = new List<NovelPeopleRelation>();

        public NovelPeople()
        {
            GID = Guid.NewGuid();
        }
    }
}
