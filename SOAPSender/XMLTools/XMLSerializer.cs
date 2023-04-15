using System.Xml;
using System.Xml.Serialization;

namespace WS1.XMLTools
{
    /// <summary>
    /// Represents the wrapper for System.Xml.Serialization
    /// </summary>
    public class XMLSerializer
    {
        /// <summary>
        /// Serializes an object to the XML
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">Object that will be serialized</param>
        /// <param name="path">Path to file where XML file will be saved</param>
        public void SerializeObject<T>(T obj, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamWriter sw = new StreamWriter(path))
            using (var xmlWriter = XmlWriter.Create(sw, new XmlWriterSettings { Indent = true }))
            {
                serializer.Serialize(xmlWriter, obj);
            }
        }
        /// <summary>
        /// Deserializes the object from file
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="path">Path to the file where XML file is stored</param>
        /// <returns>Returns the T type variable</returns>
        public T DeserializeObject<T>(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamReader sr = new StreamReader(path))
            {
                return (T)serializer.Deserialize(sr);
            }
        }
    }
}
