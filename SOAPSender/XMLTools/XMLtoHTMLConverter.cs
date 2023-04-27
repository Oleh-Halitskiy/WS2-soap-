using System.Xml.Xsl;
using System.Xml;

namespace SOAPSender.XMLTools
{
    public class XMLtoHTMLConverter
    {
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
            using (StreamWriter sw = new StreamWriter(@"C:\jsonTest\Assets\final.html"))
            {
                sw.WriteLine(results.ToString());
            }
            return results.ToString();
        }
    }
}
