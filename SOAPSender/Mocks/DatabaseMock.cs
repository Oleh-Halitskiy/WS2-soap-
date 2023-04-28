using SOAPSender.ModelClasses;
using System.Reflection.Metadata.Ecma335;
using System.Linq;

namespace SOAPSender.Mocks
{
    public class DatabaseMock
    {
        public static List<MilitaryBase> MilitaryBases { get; set; }
        public static MilitaryBase GetBaseByID(int id)
        {
            MockDB();
            IEnumerable<MilitaryBase> query = MilitaryBases.Where(mbase => mbase.ID == id);
            return query.First();
        }
        public static MilitaryBase GetBaseByCPTName(string name)
        {
            MockDB();
            IEnumerable<MilitaryBase> query = MilitaryBases.Where(mbase => mbase.Captain.Name == name);
            return query.First();
        }
        private static void MockDB()
        {
            Solider sol1 = new Solider(1, "Oleh", "Halytskyi", Enums.Rank.Major);
            sol1.Id = 0;
            Solider sol2 = new Solider(1, "Ihor", "Triplek", Enums.Rank.Captain);
            sol2.Id = 1;
            Solider sol3 = new Solider(1, "Jake", "Meofv", Enums.Rank.Private);
            sol3.Id = 2;
            Solider sol4 = new Solider(1, "Jacks B.", "Be", Enums.Rank.Sergeant);
            sol4.Id = 3;
            Solider sol5 = new Solider(1, "SSee", "Shard", Enums.Rank.Major);
            sol5.Id = 4;

            Vehicle vehicle1 = new Vehicle(1, "Leopard 2 A7", 228, sol1);
            vehicle1.Id = 0;
            Vehicle vehicle2 = new Vehicle(1, "Leopard 1 A6", 2222, sol2);
            vehicle2.Id = 1;
            Vehicle vehicle3 = new Vehicle(1, "Leopard 3 A5", 345, sol3);
            vehicle3.Id = 2;
            Vehicle vehicle4 = new Vehicle(1, "Leopard 87 A4", 244, sol4);
            vehicle4.Id = 3;
            Vehicle vehicle5 = new Vehicle(1, "Leopard 6 A4", 26, sol5);
            vehicle5.Id = 4;

            List<Solider> baseSols = new List<Solider>();
            List<Vehicle> baseVeh = new List<Vehicle>();

            baseSols.Add(sol1);
            baseSols.Add(sol2);
            baseSols.Add(sol3);
            baseSols.Add(sol4);
            baseSols.Add(sol5);

            baseVeh.Add(vehicle1);
            baseVeh.Add(vehicle2);
            baseVeh.Add(vehicle3);
            baseVeh.Add(vehicle4);
            baseVeh.Add(vehicle5);

            MilitaryBase mb1 = new MilitaryBase("MAIN UKRAINE BASE", "KIEV, UA", sol1, baseSols, baseVeh);
            MilitaryBase mb2 = new MilitaryBase("SECONDARY UKRAINE BASE", "KHARKIV, UA", sol2, baseSols, baseVeh);
            MilitaryBase mb3 = new MilitaryBase("WEST UKRAINE BASE", "LVIV, UA", sol3, baseSols, baseVeh);
            mb1.ID = 1;
            mb2.ID = 2;
            mb3.ID = 3;

            MilitaryBases = new List<MilitaryBase>();
            MilitaryBases.Add(mb1);
            MilitaryBases.Add(mb2);
            MilitaryBases.Add(mb3);
        }
    }
}
