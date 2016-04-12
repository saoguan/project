using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Message.ResponseMessage
{
    /// <summary>
    /// 图片消息
    /// </summary>
    public class ImageMessage : BaseMessage
    {
        public string MediaId { get; set; }

        public override string Message2Xml()
        {
            string message = @"<xml>
                            <ToUserName><![CDATA[{0}]]></ToUserName>
                            <FromUserName><![CDATA[{1}]]></FromUserName>
                            <CreateTime>{2}</CreateTime>
                            <MsgType><![CDATA[{3}]]></MsgType>
                            <Image>
                            <MediaId><![CDATA[{4}]]></MediaId>
                            </Image>
                            </xml>";
            return string.Format(message, FromUserName, ToUserName, DateTime.Now.Ticks, BaseMessage.MessageType_Image, MediaId);
        }
    }
}
