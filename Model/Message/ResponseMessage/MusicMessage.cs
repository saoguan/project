using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Message.ResponseMessage
{
    public class MusicMessage : BaseMessage
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string MusicURL { get; set; }

        public string HQMusicUrl { get; set; }

        public string ThumbMediaId { get; set; }


        public override string Message2Xml()
        {
            //<ThumbMediaId><![CDATA[{8}]]></ThumbMediaId>, ThumbMediaId
            string message = @"<xml>
                                <ToUserName><![CDATA[{0}]]></ToUserName>
                                <FromUserName><![CDATA[{1}]]></FromUserName>
                                <CreateTime>{2}</CreateTime>
                                <MsgType><![CDATA[{3}]]></MsgType>
                                <Music>
                                <Title><![CDATA[{4}]]></Title>
                                <Description><![CDATA[{5}]]></Description>
                                <MusicUrl><![CDATA[{6}]]></MusicUrl>
                                <HQMusicUrl><![CDATA[{7}]]></HQMusicUrl>
                                
                                </Music>
                                </xml>";
            return string.Format(message, FromUserName, ToUserName, DateTime.Now.Ticks, BaseMessage.MessageType_Music, Title, Description, MusicURL, HQMusicUrl);
        }
    }
}
