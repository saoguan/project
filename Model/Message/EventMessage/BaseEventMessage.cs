using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Message.EventMessage
{
    /// <summary>
    /// 事件基类
    /// </summary>
    class BaseEventMessage : BaseMessage
    {
        /// <summary>
        /// 事件接收
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 事件来自
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public int CreateTime { get; set; }

        /// <summary>
        /// 事件类型
        /// </summary>
        public string Event { get; set; }
    }
}
