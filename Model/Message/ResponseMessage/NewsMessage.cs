using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Message.ResponseMessage
{


    /// <summary>
    /// 图文消息
    /// </summary>
    public class NewsMessage : BaseMessage
    {
        public List<ArticlesMessage> Articles = null;

        public int ArticleCount { get; set; }

        public NewsMessage() 
        {
            Articles = new List<ArticlesMessage>();
        }

        public void addArticleMessage(ArticlesMessage message) 
        {
            Articles.Add(message);
        }

        private string getArticles2Xml() 
        {
            string xml = "";
            foreach (ArticlesMessage item in Articles)
            {
                xml += item.Message2Xml();
            }
            return xml;
        }

        public override string Message2Xml()
        {
            string message = @"<xml>
                                <ToUserName><![CDATA[{0}]]></ToUserName>
                                <FromUserName><![CDATA[{1}]]></FromUserName>
                                <CreateTime>{2}</CreateTime>
                                <MsgType><![CDATA[{3}]]></MsgType>
                                <ArticleCount>{4}</ArticleCount>
                                <Articles>
                                    {5}
                                </Articles>
                                </xml> ";
            return string.Format(message, FromUserName, ToUserName, DateTime.Now.Ticks, BaseMessage.MessageType_News, Articles.Count, getArticles2Xml());
        }
    }
}
