using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.Template
{
    class MoveFolder : OperationWithFolder
    {
        public override void Operation(string pathfrom, string pathto)
        {
            if (System.IO.Path.GetExtension(pathfrom) == "") System.IO.File.Copy(pathfrom, pathto, true);
            else System.IO.Directory.CreateDirectory(pathto);
        }

        public void Delete(string pathfrom)
        {
            System.IO.Directory.Delete(pathfrom, true);
        }
    }
}
