using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.State
{
    class NotReady : ListState
    {
        public override Prototype.IFileOrFolder Copy(DecisionMaker context, string name, string PathFrom, string PathTo)
        {
            Prototype.IFileOrFolder element = new Prototype.FolderItem("", "");
            MessageBox.Show("Nothing to Copy", "Error", MessageBoxButtons.OK);
            return element;
        }
        public override Prototype.IFileOrFolder Move(DecisionMaker context, string name, string PathFrom, string PathTo)
        {
            Prototype.IFileOrFolder element = new Prototype.FolderItem("", "");
            MessageBox.Show("Nothing to Move", "Error", MessageBoxButtons.OK);
            return element;
        }
        public override void Delete(DecisionMaker context, string name, string PathFrom)
        {
            MessageBox.Show("Nothing to Delete", "Error", MessageBoxButtons.OK);
        }
    }
}
