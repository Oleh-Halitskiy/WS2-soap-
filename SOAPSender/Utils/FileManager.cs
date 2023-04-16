namespace Utils
{
    /// <summary>
    /// File manager class for selecting and saving files
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// Function for selecting file
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <returns>Returns the string representaion of the file</returns>
        public static string SelectFile(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
        /// <summary>
        /// Function for saving the file
        /// </summary>
        /// <param name="path">Path to where file will be saved</param>
        /// <param name="message">Message that will be saved in the file</param>
        public static void SaveFile(string path, string message)
        {
            using(StreamWriter sr = new StreamWriter(path))
            {
                sr.Write(message);
            }
        }
    }
}
