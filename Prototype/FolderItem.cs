using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.Prototype
{
    class FolderItem : IFileOrFolder
    {
        string Path;
        string Name;
        public FolderItem(string path, string name)
        {
            Path = path;
            Name = name;
        }
        public IFileOrFolder Clone()
        {
            return new FolderItem(this.Path, this.Name);
        }
        public void SetPath(string path)
        {
            Path = path;
        }
        public string GetPath()
        {
            return Path;
        }
        public string GetName()
        {
            return Name;
        }
        public void Create()
        {
            string FullPath = System.IO.Path.Combine(Path, Name);
            System.IO.Directory.CreateDirectory(FullPath);
        }
        public void Copy(string PathTo)
        {
            string SourceFolder = System.IO.Path.Combine(Path, Name);
            string DestFolder = System.IO.Path.Combine(PathTo, Name);
            Template.CopyFolder Copy = new Template.CopyFolder();
            Copy.Iterate(SourceFolder, DestFolder);
        }
        public void Move(string PathTo)
        {
            string SourceFolder = System.IO.Path.Combine(Path, Name);
            string DestFolder = System.IO.Path.Combine(PathTo, Name);
            Template.MoveFolder Move = new Template.MoveFolder();
            Move.Iterate(SourceFolder, DestFolder);
            Move.Delete(SourceFolder);
        }
    }
}
