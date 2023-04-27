using SOAPSender;
using System.Xml.Xsl;
using System.Xml;
using TestRef1;

namespace SOAPConsumer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //var client = new ServiceClient(ServiceClient.EndpointConfiguration.WSHttpBinding_IService, "https://localhost:5001/Service/WSHttps");
            //string test = await client.GetBaseByIDAsync(1);
            //Console.WriteLine(test);

            ///
            /// PDF DEMO
            ///
            //string dataDir = @"C:\jsonTest\testing\";
            ////Create pdf document
            //Aspose.Pdf.Document pdf = new Aspose.Pdf.Document();
            ////Bind XML and XSLT files to the document
            //try
            //{
            //    pdf.BindXml(dataDir + "\\mb.xml", dataDir + "\\mb1.xslt");
            //}
            //catch (System.Exception)
            //{

            //    throw;
            //}

            ////Save the document
            //pdf.Save(dataDir + "result.pdf");


            ///
            /// HTML demo
            ///

            Console.WriteLine(SOAPSender.XMLTools.XMLtoHTMLConverter.TransformXMLToHTML(@"C:\jsonTest\Assets\mb.xml",@"C:\jsonTest\Assets\mbToHTML.xsl"));
            Console.ReadKey();
        }
    }
}