using SOAPSender.XMLTools;
using SOAPSender.Enums;
using SOAPSender.ModelClasses;
using Xunit;

namespace WS1.Tests.Tests
{
    /// <summary>
    /// Tests for model classes
    /// </summary>
    public class ModelTests
    {
        [Fact]
        public void EntranceLogTest()
        {
            EntranceLog log = new EntranceLog(DateTime.Today, "Req");
            Assert.Equal("Req", log.Log);
        }
        [Fact]
        public void RequestTest()
        {
            Request req = new Request("Item", "Reason", DateTime.Today);
            Assert.Equal("Item", req.ReqItem);
            Assert.Equal("Reason", req.Reason);
        }
        [Fact]
        public void SoliderTest()
        {
            Solider sol = new Solider(1, "Oleh", "Halytskyi", Rank.Major);
            Assert.Equal("Oleh", sol.Name);
            Assert.Equal("Halytskyi", sol.Surname);
            Assert.Equal(Rank.Major.ToString(), sol.Rank.ToString());
        }
        [Fact]
        public void MilitaryBaseTest()
        {
            MilitaryBase militaryBase = new MilitaryBase("AFB", "UA", new Solider(), new List<Solider>(), new List<Vehicle>());
            Assert.Equal("AFB", militaryBase.Name);
            Assert.Equal("UA", militaryBase.Location);
            Assert.True(militaryBase.Captain != null);
            Assert.True(militaryBase.Vehicles != null);
            Assert.True(militaryBase.Soliders != null);
        }
        [Fact]
        public void VehicleTest()
        {
            Vehicle vehicle = new Vehicle(1, "Tank", 99, new Solider());
            Assert.Equal(1, vehicle.BaseID);
            Assert.Equal("Tank", vehicle.Name);
            Assert.Equal(99, vehicle.Weight);
            Assert.True(vehicle.Captain != null);

        }
    }
}
