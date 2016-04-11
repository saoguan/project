using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Tool;
using Library.Parse;
using Model.Message;

namespace Library
{
    public class MessageHelp
    {
        private static MessageHelp instance = null;

        /// <summary>
        /// 储存Xml解析后的键值对
        /// </summary>
        private IDictionary<string, string> mDictionary = null;

        public static MessageHelp getInstance()
        {
            if (instance == null)
            {
                instance = new MessageHelp();
            }
            return instance;
        }

        /// <summary>
        /// 统一处理消息接口
        /// </summary>
        /// <param name="postStr">消息的内容 Xml格式</param>
        /// <returns></returns>
        public string HandleMessage(string postStr)
        {
            mDictionary = XmlHelp.Xml2IDictionary(postStr);

            //回复的消息
            string Response = "";
            if (mDictionary.ContainsKey("MsgType")) 
            {
                if (mDictionary["MsgType"] == "event")
                {
                    //事件
                    //EventParse.getInstance()
                }
                else 
                {
                    //消息
                    MessageParse.getInstance()
                }
            }
            return Response;
        }
    }
}
