using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Parse
{
    /// <summary>
    /// 消息解析
    /// </summary>
    public class MessageParse
    {
        private static MessageParse instance = null;

        public static MessageParse getInstance()
        {
            if (instance == null)
            {
                instance = new MessageParse();
            }
            return instance;
        }

        public string ParseMessage(IDictionary<string, string> mDictionary) 
        {

            return "";
        }
    }
}
