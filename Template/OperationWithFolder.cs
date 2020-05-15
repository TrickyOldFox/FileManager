using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.Template
{
    abstract class OperationWithFolder
    {
        public virtual void Iterate(string pathfrom, string pathto)
        {
            DirectoryInfo dir = new DirectoryInfo(pathfrom);

            DirectoryInfo[] dirs = dir.GetDirectories();

            foreach (DirectoryInfo curDir in dirs)
            {
                string SourceFolder = System.IO.Path.Combine(pathfrom, curDir.ToString());
                string DestFolder = System.IO.Path.Combine(pathto, curDir.ToString());
                this.Operation(SourceFolder, DestFolder);
                this.Iterate(SourceFolder, DestFolder);
            }

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo curFile in files)
            {
                string SourceFile = System.IO.Path.Combine(pathfrom, curFile.ToString());
                string DestFile = System.IO.Path.Combine(pathto, curFile.ToString());
                this.Operation(SourceFile, DestFile);
            }
        }
        public abstract void Operation(string SourceFile, string DestFile);
    }
}
