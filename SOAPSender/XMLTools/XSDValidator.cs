using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace WS1.XMLTools
{
    /// <summary>
    /// Represents the class that does XSD validation
    /// </summary>
    public class XSDValidator
    {
        /// <summary>
        /// Function that validates XML file against XSD schema
        /// </summary>
        /// <param name="XSDfile">Path to the XSD schema file</param>
        /// <param name="XMLfile">Path to the XML file</param>
        /// <returns>True if verification is successful</returns>
        public bool ValidateXML(string XSDfile, string XMLfile)
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", XSDfile);
            XDocument doc = XDocument.Load(XMLfile);
            bool valError = false;
            doc.Validate(schema, (s, e) =>
            {
                Console.WriteLine(e.Message);
                valError = true;
            });
            if (valError)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
