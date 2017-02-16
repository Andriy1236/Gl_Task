using System;

namespace Bl.Classes
{
    [Serializable]
   public class Folder
    {
        public Folder[] SubFolders { get; set; }
        public FolderFile[] Files { get; set; }
        public string Name { get; set; }
    }
}
