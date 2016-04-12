using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Message.ResponseMessage
{
    /// <summary>
    /// 图文消息的内容
    /// </summary>
    public class ArticlesMessage
    {
        public string Titile { get; set; }
        public string Description { get; set; }
        public string PicUrl { get; set; }
        public string Url { get; set; }

        public string Message2Xml()
        {
            string message = @"<item>
                                    <Title><![CDATA[{0}]]></Title> 
                                    <Description><![CDATA[{1}]]></Description>
                                    <PicUrl><![CDATA[{2}]]></PicUrl>
                                    <Url><![CDATA[{3}]]></Url>
                                    </item>";
            return string.Format(message, Titile, Description, PicUrl, Url);
        }
    }
}
