namespace WS1.ModelClasses
{
    /// <summary>
    /// Class representing EntranceLog model
    /// </summary>
    [Serializable]
    public class EntranceLog
    {
        private int id;
        private DateTime date;
        private string log;

        /// <summary>
        /// Returns the ID of log
        /// </summary>
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// Returns date of log
        /// </summary>
        public DateTime Date { get => date; set => date = value; }
        /// <summary>
        /// Returns string description of log
        /// </summary>
        public string Log { get => log; set => log = value; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public EntranceLog()
        {

        }
        /// <summary>
        /// Parametrimized constructor for EntranceLog class
        /// </summary>
        /// <param name="date">Date of log</param>
        /// <param name="log">String description of log</param>
        public EntranceLog(DateTime date, string log)
        {
            Date = date;
            Log = log;
        }
    }
}
