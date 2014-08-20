using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace CloudExperienceWeb.Controllers
{

    /// <summary>
    /// Generically serializes/deserializes message to/from string/objects.
    /// </summary>
    public static class MessageSerializer
    {
        public static T DeserializeMessage<T>(string messageContent)
        {
            var xmlSer = new XmlSerializer(typeof(T));
            return (T)xmlSer.Deserialize(new StringReader(
                messageContent));
        }

        public static string Serialize(object message)
        {
            var xmlSerializer = new XmlSerializer(message.GetType());
            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, message);
                return stringWriter.ToString();
            }
        }
    }
}