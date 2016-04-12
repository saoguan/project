using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Message.ResponseMessage
{
    public class VideoMessage : BaseMessage
    {
        public string MediaId { get; set; }

        /// <summary>
        /// 视频标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 视频描述
        /// </summary>
        public string Description { get; set; }

        public override string Message2Xml()
        {
            string message = @"<xml>
                                <ToUserName><![CDATA[{0}]]></ToUserName>
                                <FromUserName><![CDATA[{1}]]></FromUserName>
                                <CreateTime>{2}</CreateTime>
                                <MsgType><![CDATA[{3}]]></MsgType>
                                <Video>
                                <MediaId><![CDATA[{4}]]></MediaId>
                                <Title><![CDATA[{5}]]></Title>
                                <Description><![CDATA[{6}]]></Description>
                                </Video> 
                                </xml>";
            return string.Format(message, FromUserName, ToUserName, DateTime.Now.Ticks, BaseMessage.MessageType_Video, MediaId, Title, Description);
        }
    }
}
