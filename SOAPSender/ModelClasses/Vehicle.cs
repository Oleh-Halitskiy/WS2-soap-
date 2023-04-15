namespace WS1.ModelClasses
{
    /// <summary>
    /// Class representing Vehicle model
    /// </summary>
    [Serializable]
    public class Vehicle
    {
        int id;
        int baseID;
        string name;
        float weight;
        Solider captain;

        /// <summary>
        /// Returns the ID of the vehicle
        /// </summary>
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// Returns the name of the vehicle
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Returns the weight of the vehicle
        /// </summary>
        public float Weight { get => weight; set => weight = value; }
        /// <summary>
        /// Returns the captain of the vehicle
        /// </summary>
        public Solider Captain { get => captain; set => captain = value; }
        /// <summary>
        /// Returns the ID of the base that vehicle belongs to
        /// </summary>
        public int BaseID { get => baseID; set => baseID = value; }

        /// <summary>
        /// Empty ctor for Vehicle class
        /// </summary>
        public Vehicle()
        {

        }
        /// <summary>
        /// Constructor with parameters for Vehicle class 
        /// </summary>
        /// <param name="baseid">ID of the base vehicle belongs to</param>
        /// <param name="name">The name of the Vehicle</param>
        /// <param name="weight">The weight of the vehicle</param>
        /// <param name="captain">The captain of the vehicle</param>
        public Vehicle(int baseid, string name, float weight, Solider captain)
        {
            BaseID = baseid;
            Name = name;
            Weight = weight;
            Captain = captain;
        }
    }
}