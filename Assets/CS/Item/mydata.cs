using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyData
{
    /// <summary>
    /// 用来解析json文件
    /// </summary>
    [Serializable]
    public class mydata
    {
        public static mydata md = new mydata();
        [Serializable]
        public struct rank_struct
        {
            public string player_name;
            public string player_score;
        }
        public rank_struct uprank = new rank_struct();
        public List<rank_struct> myrank = new List<rank_struct>();
    }
}
