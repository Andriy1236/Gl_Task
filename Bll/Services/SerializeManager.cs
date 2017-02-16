using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Bl.Classes;

namespace Bl.Services
{
   public class SerializeManager
   {
            public Folder GetFolder(string path)
            {
                return new Folder()
                {
                    Name = new DirectoryInfo(path).Name,
                    Files = GetFiles(path).ToArray(),
                    SubFolders = GetFolders(path).ToArray()
                }; 
            }

            private IEnumerable<Folder> GetFolders(string root)
            {
                return from folder in Directory.GetDirectories(root) let dirInfo = new DirectoryInfo(folder) select new Folder
                {
                    Name = dirInfo.Name,
                    Files = GetFiles(folder).ToArray(),
                    SubFolders = GetFolders(folder).ToArray()
                };
            }

            private IEnumerable<FolderFile> GetFiles(string dir)
            {
                return from file in Directory.GetFiles(dir) let fileInfo = new FileInfo(file) select new FolderFile
                {
                    Data =File.ReadAllBytes(file),
                    Name = fileInfo.Name
                };
            }

            public void SerializeFolder(Folder folder,string to)
            {
                using (var serializeStream = new FileStream(Path.Combine(to, "sFolder.dat"), FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(serializeStream, folder);
                    serializeStream.Flush();
                }
            }
    }
    
}
