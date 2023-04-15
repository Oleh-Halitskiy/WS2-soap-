namespace WS1.ModelClasses
{
    /// <summary>
    /// Class representing Request model
    /// </summary>
    [Serializable]
    public class Request
    {
        private int id;
        private string reqItem;
        private string reason;
        private DateTime reqDate;

        /// <summary>
        /// Returns string of requested item
        /// </summary>
        public string ReqItem { get => reqItem; set => reqItem = value; }
        /// <summary>
        /// Returns string of reason
        /// </summary>
        public string Reason { get => reason; set => reason = value; }
        /// <summary>
        /// Returns DateTime of date of request
        /// </summary>
        public DateTime ReqDate { get => reqDate; set => reqDate = value; }
        /// <summary>
        /// Returns ID of request
        /// </summary>
        public int ID { get => id; set => id = value; }

        /// <summary>
        /// Parametrimized constructor of Request class
        /// </summary>
        /// <param name="reqItem">String of requested item</param>
        /// <param name="reason">String of reason for request</param>
        /// <param name="reqDate">Request date</param>
        public Request(string reqItem, string reason, DateTime reqDate)
        {
            ReqItem = reqItem;
            Reason = reason;
            ReqDate = reqDate;
        }
    }
}
