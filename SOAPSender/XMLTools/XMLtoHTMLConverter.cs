using System.Xml.Xsl;
using System.Xml;

namespace SOAPSender.XMLTools
{
    /// <summary>
    /// Class that represent support for XML transformation to HTML using XSL
    /// </summary>
    public class XMLtoHTMLConverter
    {
        /// <summary>
        /// Trnasforms XML to the HTML file using XSL transformation
        /// </summary>
        /// <param name="inputXmlPath">Path to the XML file</param>
        /// <param name="xsltStringPath">Path to the XSL file</param>
        /// <returns>Returns string of whole HTML file, also </returns>
        public static string TransformXMLToHTML(string inputXmlPath, string xsltStringPath)
        {
            string inputXml;
            string xsltString;
            using (StreamReader sr = new StreamReader(inputXmlPath))
            {
                inputXml = sr.ReadToEnd();
            }
            using (StreamReader sr = new StreamReader(xsltStringPath))
            {
                xsltString = sr.ReadToEnd();
            }
            XslCompiledTransform transform = new XslCompiledTransform();
            using (XmlReader reader = XmlReader.Create(new StringReader(xsltString)))
            {
                transform.Load(reader);
            }
            StringWriter results = new StringWriter();
            using (XmlReader reader = XmlReader.Create(new StringReader(inputXml)))
            {
                transform.Transform(reader, null, results);
            }
            return results.ToString();
        }
    }
}
