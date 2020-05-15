﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.Prototype
{
    class FileItem : IFileOrFolder
    {
        string Path;
        string Name;
        public FileItem(string path, string name)
        {
            Path = path;
            Name = name;
        }
        public IFileOrFolder Clone()
        {
            return new FileItem(this.Path, this.Name);
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
            System.IO.FileStream fs = System.IO.File.Create(FullPath);
            fs.Close();
        }
        public void Copy(string PathTo)
        {
            string SourceFile = System.IO.Path.Combine(Path, Name);
            string DestFile = System.IO.Path.Combine(PathTo, Name);
            System.IO.File.Copy(SourceFile, DestFile, true);
        }
        public void Move(string PathTo)
        {
            string SourceFile = System.IO.Path.Combine(Path, Name);
            string DestFile = System.IO.Path.Combine(PathTo, Name);
            System.IO.File.Copy(SourceFile, DestFile, true);
            System.IO.File.Delete(SourceFile);
        }
    }
}
