using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using Library;

namespace WXWeb
{
    /// <summary>
    /// Wx_Service 的摘要说明
    /// </summary>
    public class Wx_Service : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string postString = string.Empty;
            if (context.Request.HttpMethod == "GET")
            {
                // 微信加密签名
                string signature = context.Request.QueryString["signature"];
                // 时间戳
                string timestamp = context.Request.QueryString["timestamp"];
                // 随机数
                string nonce = context.Request.QueryString["nonce"];
                // 随机字符串
                string echostr = context.Request.QueryString["echostr"];

                if (!string.IsNullOrEmpty(echostr))
                {
                    HttpContext.Current.Response.Write(echostr);
                    HttpContext.Current.Response.End();//23
                }
            }
            else
            {
                //处理post请求 微信会推送 时间 消息  统一接受处理
                if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
                {
                    using (Stream stream = HttpContext.Current.Request.InputStream)
                    {
                        Byte[] postBytes = new Byte[stream.Length];
                        stream.Read(postBytes, 0, (Int32)stream.Length);
                        postString = Encoding.UTF8.GetString(postBytes);
                        Handle(postString);
                    }
                }
            }
        }

        /// <summary>
        /// 处理信息并应答
        /// </summary>
        private void Handle(string postStr)
        {
            //处理完成消息 回执给微信
            string responseContent = MessageHelp.getInstance().HandleMessage(Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(postStr)));

            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.Write(responseContent);
            HttpContext.Current.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}