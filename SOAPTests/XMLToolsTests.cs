using SOAPSender.Enums;
using SOAPSender.ModelClasses;
using SOAPSender.Utils;
using SOAPSender.XMLTools;
using Xunit;

namespace WS1.Tests.Tests
{
    /// <summary>
    /// Tests for xml serializer
    /// </summary>
    public class XMLToolsTests
    {
        string AssetsPath = "..\\TestAssets\\";
        [Fact]
        public void TestSerialization()
        {
            XMLTools.XMLSerializer serializer = new XMLTools.XMLSerializer();
            Solider sol = new Solider(1, "Oleh", "Halytskyi", Rank.Captain);
            serializer.SerializeObject(sol, AssetsPath + "Test.xml");
            string test = FileManager.SelectFile(AssetsPath + "Test.xml");
            Assert.Contains("Halytskyi", test);
            Assert.Contains("Oleh", test);
            Assert.Contains("Captain", test);
        }
        [Fact]
        public void TestDeserilization()
        {
            XMLTools.XMLSerializer serializer = new XMLTools.XMLSerializer();
            Solider sol = serializer.DeserializeObject<Solider>(AssetsPath + "Test.xml");
            Assert.Equal("Halytskyi", sol.Surname);
            Assert.Equal("Oleh", sol.Name);
            Assert.Equal(Rank.Captain, sol.Rank);
        }
        [Fact]
        public void TestHTMLTransformation()
        {
            string test = XMLtoHTMLConverter.TransformXMLToHTML(AssetsPath + "mb.xml", AssetsPath + "mbToHTML.xsl");
            Assert.Contains("Military Base Information", test);
            Assert.Contains("228 tons", test);
            Assert.Contains("MAIN UKRAINE BASE", test);
        }
    }
}
