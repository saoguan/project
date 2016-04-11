using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Library.Tool
{
    class XmlHelp
    {
        /// <summary>
        /// Xml解析方法 将Xml 拆分成键值对
        /// </summary>
        /// <param name="strXml"></param>
        /// <returns></returns>
        public static IDictionary<string, string> Xml2IDictionary(string strXml)
        {
            IDictionary<string, string> mDictionary = new Dictionary<string, string>();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(new System.IO.MemoryStream(System.Text.Encoding.GetEncoding("UTF-8").GetBytes(strXml)));
            XmlNodeList nodes = xmldoc.ChildNodes;
            foreach (XmlNode node in nodes)
            {
                if (node.HasChildNodes)
                {
                    foreach (XmlNode item in node.ChildNodes)
                    {
                        mDictionary.Add(item.Name, item.InnerText);
                    }
                }
            }

            return mDictionary;
        }

        public static string IDictionary2Xml(IDictionary<string, string> mDictionary)
        {
            string xml = "<xml>";
            foreach (var item in mDictionary)
            {
                xml += "<" + item.Key + ">" + item.Value + "</" + item.Key + ">";
            }
            xml += "</xml>";
            return xml;
        }
    }
}
