using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace ControlWork
{
    public class DataWorker
    {
        static string _nameFile = "data.xml";

        static bool CheckFile()
        {
            return File.Exists(_nameFile);
        }

        static void FileCreator()
        {
            var xmlDocument = new XmlDocument();
            var rootElement = xmlDocument.CreateElement("users");

            xmlDocument.AppendChild(rootElement);

            xmlDocument.Save(_nameFile);

        }

        public static void DataWriter(User user)
        {
            if (!CheckFile())
            {
                FileCreator();
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(_nameFile);

            var rootElement = xmlDocument.DocumentElement;
            var element = xmlDocument.CreateElement("user");

            var elenentCity = xmlDocument.CreateElement("city");
            elenentCity.InnerText = user.GetCity();

            var elenentPassword = xmlDocument.CreateElement("password");
            elenentPassword.InnerText = user.GetPassword();

            var elenentEmail = xmlDocument.CreateElement("email");
            elenentEmail.InnerText = user.GetEmail();

            var elenentPhoneNumber = xmlDocument.CreateElement("phoneNumber");
            elenentPhoneNumber.InnerText = user.GetPhoneNumber();

            var elenentAge = xmlDocument.CreateElement("age");
            elenentAge.InnerText = user.GetAge().ToString();

            element.AppendChild(elenentEmail);
            element.AppendChild(elenentPassword);
            element.AppendChild(elenentPhoneNumber);
            element.AppendChild(elenentCity);
            element.AppendChild(elenentAge);

            rootElement.AppendChild(element);

            xmlDocument.ReplaceChild(xmlDocument.DocumentElement, rootElement);
            xmlDocument.Save(_nameFile);
        }
    }
}
