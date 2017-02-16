using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Bl.Classes;

namespace Bl.Services
{
  public class DeSerializeManager
  {
      private BinaryFormatter formatter;
        public Folder DeSerialize(Stream stream)
        {
            using (stream)
            {
                formatter = new BinaryFormatter();
                Folder deserilizeFolder = (Folder) formatter.Deserialize(stream);
                return deserilizeFolder;
            }
        }
        public void SaveSerializedFolder(Folder directory, string path)
        {
            var folderPath = Path.Combine(path, directory.Name);
            Directory.CreateDirectory(folderPath);
            foreach (var directoryFile in directory.Files)
            {
                var filePath = Path.Combine(folderPath, directoryFile.Name);
                File.Create(filePath).Close();
                File.WriteAllBytes(filePath, directoryFile.Data);
            }
            foreach (var directorySubfolder in directory.SubFolders)
            {
                SaveSerializedFolder(directorySubfolder, folderPath);
            }
        }
  }
}
