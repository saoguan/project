using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Message
{
    /// <summary>
    /// 抽象类 消息基类
    /// </summary>
    public abstract class BaseMessage
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        public const string MessageType_Text = "text";

        /// <summary>
        /// 图片消息
        /// </summary>
        public const string MessageType_Image = "image";

        /// <summary>
        /// 音频消息
        /// </summary>
        public const string MessageType_Voice = "voice";

        /// <summary>
        /// 视频消息
        /// </summary>
        public const string MessageType_Video = "video";

        /// <summary>
        /// 小视频消息
        /// </summary>
        public const string MessageType_ShortVideo = "shortvideo";

        /// <summary>
        /// 地理位置消息
        /// </summary>
        public const string MessageType_Location = "location";

        /// <summary>
        /// 链接消息
        /// </summary>
        public const string MessageType_Link = "link";

        /// <summary>
        /// 音乐消息
        /// </summary>
        public const string MessageType_Music = "music";

        /// <summary>
        /// 图文消息
        /// </summary>
        public const string MessageType_News = "news";

        public string ToUserName { get; set; }

        public string FromUserName { get; set; }

        public string CreateTime { get; set; }

        public string MsgType { get; set; }

        /// <summary>
        /// 抽象方法,将对象转换为xml
        /// </summary>
        /// <returns></returns>
        public abstract string Message2Xml();
    }
}
