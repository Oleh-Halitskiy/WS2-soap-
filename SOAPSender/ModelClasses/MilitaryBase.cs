using WS1.DataUtils;

namespace WS1.ModelClasses
{
    /// <summary>
    /// Class representing MilitaryBase model
    /// </summary>
    [Serializable]
    public class MilitaryBase
    {
        private int id;
        private string name;
        private string location;
        private Solider captain;
        private List<Solider> soliders;
        private List<Vehicle> vehicles;

        /// <summary>
        /// Returns the ID of log
        /// </summary>
        public int ID { get => id; set => id = value; }
        /// <summary>
        /// Returns name of military base
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Returns location of base
        /// </summary>
        public string Location { get => location; set => location = value; }
        /// <summary>
        /// Returns solider that is captain of this base
        /// </summary>
        public Solider Captain { get => captain; set => captain = value; }
        /// <summary>
        /// Returns list of soiders belonging to this base
        /// </summary>
        public List<Solider> Soliders { get => soliders; set => soliders = value; }
        /// <summary>
        /// Returns list of vehicles belonging to this base
        /// </summary>
        public List<Vehicle> Vehicles { get => vehicles; set => vehicles = value; }

        /// <summary>
        /// Parametrimized constructor for MilitaryBase class
        /// </summary>
        /// <param name="name">Name of base</param>
        /// <param name="location">String location of base</param>
        /// <param name="captain">Solider type variable of captain of the base</param>
        /// <param name="soliders">List of soliders belonging to this base</param>
        /// <param name="vehicles">List of vehicles belonging to this base</param>
        public MilitaryBase(string name, string location, Solider captain, List<Solider> soliders, List<Vehicle> vehicles)
        {
            Name = name;
            Location = location;
            Captain = captain;
            Soliders = soliders;
            Vehicles = vehicles;
        }
        /// <summary>
        /// Empty constructor for MilitaryBase class
        /// </summary>
        public MilitaryBase()
        {

        }
        /// <summary>
        /// Make request to the DB of needed equipment
        /// </summary>
        /// <param name="reqItem">String of needed item</param>
        /// <param name="reason">String representation of reason</param>
        public void RequestEquipement(string reqItem, string reason)
        {
            DataAccess da = new DataAccess();
            da.SaveData("dbo.spReq_Insert", new { reqItem, reason, reqDate = DateTime.Now });
        }
    }
}
