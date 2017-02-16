using System;

namespace Bl.Classes
{
    [Serializable]
    public class FolderFile
    {
        public byte[] Data { get; set; }
        public string Name { get; set; }
    }
}
