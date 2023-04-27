using SOAPSender.Utils;

using Xunit;

namespace WS1.Tests.Tests
{
    /// <summary>
    /// Tests for utils classes
    /// </summary>
    public class UtilsTests
    {
        string AssetsPath = "..\\TestAssets\\TextFile1.txt";
        [Fact]
        public void FileManagerTest()
        {
            string test = FileManager.SelectFile(AssetsPath);
            Assert.Equal("EMINEM", test);
        }
    }
}
