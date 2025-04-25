using System.Text.Json;

namespace UtilitiesLib.Serialization
{
    public static class QuickJsonSerializer<T>
    {
        /// <summary>
        /// Serializes object list to .Json files
        /// </summary>
        public static void SaveData(string filePath, List<T> saveObjectsList)
        {
            //Create file path if it doesnt exist
            FileInfo fileInfo = new FileInfo(filePath);
            fileInfo.Directory.Create();

            using StreamWriter writer = new(filePath);
            foreach (T obj in saveObjectsList)
            {
                writer.WriteLine(JsonSerializer.Serialize(obj));
            }
        }

        /// <summary>
        /// Loads serialized data from .Json files
        /// </summary>
        public static List<T> LoadData(string filePath)
        {
            using StreamReader reader = new(filePath);
            string? line = reader.ReadLine();
            List<T> loadObjectList = [];
            while (line != null)
            {
                loadObjectList.Add(JsonSerializer.Deserialize<T>(line));
                line = reader.ReadLine();
            }
            return loadObjectList;
        }
    }
}
