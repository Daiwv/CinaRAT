using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using xServer.Core.Helper;

namespace xServer.Core.Data
{
    public class Language
    {
        private readonly string _languagePath;

        public string Hosts
        {
            get
            {
                return ReadValueSafe("Connected");
            }
            set
            {
                WriteValue("Connected", value);
            }
        }

        public Language(string language)
        {
            if (string.IsNullOrEmpty(language)) throw new ArgumentException("Invalid Language Path");
            _languagePath = Path.Combine(Application.StartupPath, "Languages\\" + language + ".xml");
        }

        private string ReadValue(string pstrValueToRead)
        {
            try
            {
                XPathDocument doc = new XPathDocument(_languagePath);
                XPathNavigator nav = doc.CreateNavigator();
                XPathExpression expr = nav.Compile(@"/settings/" + pstrValueToRead);
                XPathNodeIterator iterator = nav.Select(expr);
                while (iterator.MoveNext())
                {
                    return iterator.Current.Value;
                }

                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private string ReadValueSafe(string pstrValueToRead, string defaultValue = "")
        {
            string value = ReadValue(pstrValueToRead);
            return (!string.IsNullOrEmpty(value)) ? value : defaultValue;
        }

        private void WriteValue(string pstrValueToRead, string pstrValueToWrite)
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                if (File.Exists(_languagePath))
                {
                    using (var reader = new XmlTextReader(_languagePath))
                    {
                        doc.Load(reader);
                    }
                }
                else
                {
                    var dir = Path.GetDirectoryName(_languagePath);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    doc.AppendChild(doc.CreateElement("settings"));
                }

                XmlElement root = doc.DocumentElement;
                XmlNode oldNode = root.SelectSingleNode(@"/settings/" + pstrValueToRead);
                if (oldNode == null) // create if not exist
                {
                    oldNode = doc.SelectSingleNode("settings");
                    oldNode.AppendChild(doc.CreateElement(pstrValueToRead)).InnerText = pstrValueToWrite;
                    doc.Save(_languagePath);
                    return;
                }
                oldNode.InnerText = pstrValueToWrite;
                doc.Save(_languagePath);
            }
            catch
            {
            }
        }
    }
}