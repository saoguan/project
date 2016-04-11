using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Message
{
    public abstract class BaseMessage
    {
        public string ToUserName { get; set; }

        public string FromUserName { get; set; }

        public int CreateTime { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; set; }

        public abstract string Model2Xml();
    }
}
