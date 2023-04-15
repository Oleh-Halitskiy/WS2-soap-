using WS1.DataUtils;
using WS1.Enums;

namespace WS1.ModelClasses
{
    /// <summary>
    /// Class representing Solider model
    /// </summary>
    [Serializable]
    public class Solider
    {
        int id;
        int baseId;
        string name;
        string surname;
        Rank rank;

        /// <summary>
        /// Returns ID for the solider
        /// </summary>
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// Returns the ID of the base that solider is related to
        /// </summary>
        public int BaseId { get => baseId; set => baseId = value; }
        /// <summary>
        /// Returns the solider's name
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Returns the solider's surname
        /// </summary>
        public string Surname { get => surname; set => surname = value; }
        /// <summary>
        /// Returns the solider's rank
        /// </summary>
        public Rank Rank { get => rank; set => rank = value; }

        /// <summary>
        /// Parametrimized constructor for Solider class
        /// </summary>
        /// <param name="baseId">The military base id</param>
        /// <param name="name">The name of the Solider</param>
        /// <param name="surname">The surname of the Solider</param>
        /// <param name="rank">The rank of the Solider</param>
        public Solider(int baseId, string name, string surname, Rank rank)
        {
            this.baseId = baseId;
            this.name = name;
            this.surname = surname;
            this.rank = rank;
        }
        /// <summary>
        /// Empry constructor for Solider class
        /// </summary>
        public Solider()
        {
        }
        /// <summary>
        /// Sends the log to the database that solider is entered the base
        /// </summary>
        public void EnterBase()
        {
            DataAccess da = new DataAccess();
            var logString = $"Solider {id} entered the base {baseId}";
            da.SaveData("dbo.spELogs_Insert", new { log = logString, date = DateTime.Now});
        }
        /// <summary>
        /// Sends the log to the database that solider is left the base
        /// </summary>
        public void LeaveBase()
        {
            DataAccess da = new DataAccess();
            var logString = $"Solider {id} left the base {baseId}";
            da.SaveData("dbo.spELogs_Insert", new { log = logString, date = DateTime.Now });
        }
        /// <summary>
        /// Converts the Solider to the string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name}, {Surname},\n{id}, {baseId},\n{Rank.ToString()}\n";
        }
    }
}
