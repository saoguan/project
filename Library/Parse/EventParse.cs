using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Parse
{
    /// <summary>
    /// 事件解析
    /// </summary>
    public class EventParse
    {
        private static EventParse instance = null;

        public static EventParse getInstance() 
        {
            if (instance == null) 
            {
                instance = new EventParse();
            }
            return instance;
        }


    }
}
