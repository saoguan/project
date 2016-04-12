using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Message;
using Model.Message.ResponseMessage;
using System.Configuration;

namespace Library.Parse
{
    /// <summary>
    /// 消息解析
    /// </summary>
    public class MessageParse
    {
        private static MessageParse instance = null;

        private static string localhostUrl = "";

        public static MessageParse getInstance()
        {
            if (instance == null)
            {
                instance = new MessageParse();
                localhostUrl = ConfigurationSettings.AppSettings["localhostUrl"];
            }
            return instance;
        }

        public string ParseMessage(IDictionary<string, string> mDictionary)
        {
            BaseMessage bMessage = null;

            //数据库解析相关信息
            switch (mDictionary["MsgType"])
            {
                case BaseMessage.MessageType_Text:
                    if (mDictionary["Content"] == "123")
                    {
                        TextMessage textMessage = new TextMessage();
                        textMessage.FromUserName = mDictionary["FromUserName"];
                        textMessage.ToUserName = mDictionary["ToUserName"];
                        textMessage.Content = "你发送的是123";
                        bMessage = textMessage;
                    }
                    else if (mDictionary["Content"] == "音乐")
                    {
                        //收到文本消息时,自动回复歌曲
                        MusicMessage musicMessage = new MusicMessage();
                        musicMessage.ToUserName = mDictionary["ToUserName"];
                        musicMessage.FromUserName = mDictionary["FromUserName"];
                        musicMessage.MsgType = BaseMessage.MessageType_Music;
                        musicMessage.Title = "歌曲";
                        musicMessage.Description = "不说";
                        musicMessage.MusicURL = localhostUrl + "Music/戴荃 - 悟空.mp3";
                        musicMessage.HQMusicUrl = localhostUrl + "Music/戴荃 - 悟空.mp3";
                        //musicMessage.ThumbMediaId = "vrSZh08LBUCG3UDl4NZoksQxHPPmT4cuojxQiDfSF4U";

                        bMessage = musicMessage;
                    }
                    else if (mDictionary["Content"] == "图文")
                    {
                        NewsMessage newsMessage = new NewsMessage();
                        newsMessage.ToUserName = mDictionary["ToUserName"];
                        newsMessage.FromUserName = mDictionary["FromUserName"];
                        for (int i = 0; i < 3; i++)
                        {
                            ArticlesMessage articlesMessage = new ArticlesMessage();
                            articlesMessage.Titile = "测试" + i;
                            articlesMessage.Description = "描述" + i;
                            articlesMessage.PicUrl = localhostUrl + "Pic/1.jpg";
                            articlesMessage.Url = "http://www.baidu.com";
                            newsMessage.addArticleMessage(articlesMessage);
                        }

                        bMessage = newsMessage;
                    }
                    break;
                case BaseMessage.MessageType_Image:
                    ImageMessage imageMessage = new ImageMessage();
                    imageMessage.FromUserName = mDictionary["FromUserName"];
                    imageMessage.ToUserName = mDictionary["ToUserName"];
                    imageMessage.MediaId = mDictionary["MediaId"];
                    bMessage = imageMessage;
                    break;
                case BaseMessage.MessageType_Link:
                    break;
                case BaseMessage.MessageType_Location:
                    break;
                case BaseMessage.MessageType_Voice:
                    VoiceMessage voiceMessage = new VoiceMessage();
                    voiceMessage.FromUserName = mDictionary["FromUserName"];
                    voiceMessage.ToUserName = mDictionary["ToUserName"];
                    voiceMessage.MediaId = mDictionary["MediaId"];
                    bMessage = voiceMessage;
                    break;
                case BaseMessage.MessageType_ShortVideo:
                case BaseMessage.MessageType_Video:
                    VideoMessage videoMessage = new VideoMessage();
                    videoMessage.ToUserName = mDictionary["ToUserName"];
                    videoMessage.FromUserName = mDictionary["FromUserName"];
                    videoMessage.MsgType = BaseMessage.MessageType_Video;
                    videoMessage.MediaId = mDictionary["MediaId"];
                    videoMessage.Title = "标题";
                    videoMessage.Description = "说明";
                    bMessage = videoMessage;
                    break;
                default:
                    return "";
            }

            return bMessage.Message2Xml();
        }
    }
}
