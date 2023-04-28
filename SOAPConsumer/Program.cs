using SOAPSender;
using System.Xml.Xsl;
using System.Xml;
// using TestRef1;
using SOAPReference;
using SOAPSender.Utils;
using System.Diagnostics;

namespace SOAPConsumer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string dataDir = @"C:\jsonTest\Assets\";
            string receivedString = "";
            var client = new ServiceClient(ServiceClient.EndpointConfiguration.WSHttpBinding_IService, "https://localhost:5001/Service/WSHttps");
            Console.WriteLine("Select military base by ID or by captain name?\n1.By ID\n2.By captain name\n");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.Write("Please enter base ID to get report: ");
                input = Console.ReadLine();
                receivedString = await client.GetBaseByIDAsync(Convert.ToInt32(input));
            }
            else if (input == "2")
            {
                Console.Write("Please enter base captain name to get report: ");
                input = Console.ReadLine();
                receivedString = await client.GetBaseByCPTNameAsync(input);
            }
            Console.WriteLine(receivedString);
            FileManager.SaveFile(dataDir + "final.xml", receivedString);
            ///
            /// PDF DEMO
            ///
            //Create pdf document
            Aspose.Pdf.Document pdf = new Aspose.Pdf.Document();
            //Bind XML and XSLT files to the document
            try
            {
                pdf.BindXml(dataDir + "\\final.xml", dataDir + "\\mbToPDF.xslt");
            }
            catch (System.Exception)
            {

                throw;
            }

            // Save the document
            pdf.Save(dataDir + "final.pdf");


            ///
            /// HTML demo
            ///

            FileManager.SaveFile(dataDir + "final.html", SOAPSender.XMLTools.XMLtoHTMLConverter.TransformXMLToHTML(@"C:\jsonTest\Assets\final.xml",@"C:\jsonTest\Assets\mbToHTML.xsl"));
            Console.ReadKey();
            new Process
            {
                StartInfo = new ProcessStartInfo(dataDir + "final.html")
                {
                    UseShellExecute = true
                }
            }.Start();
            new Process
            {
                StartInfo = new ProcessStartInfo(dataDir + "final.pdf")
                {
                    UseShellExecute = true
                }
            }.Start();
        }
    }
}