using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.State
{
    class DecisionMaker
    {
        public ListState State { get; set; }
        public DecisionMaker(ListState state)
        {
            this.State = state;
        }
        public Prototype.IFileOrFolder CopyRequest(string name, string PathFrom, string PathTo)
        {
            Prototype.IFileOrFolder element = this.State.Copy(this, name, PathFrom, PathTo);
            return element;
        }
        public Prototype.IFileOrFolder MoveRequest(string name, string PathFrom, string PathTo)
        {
            Prototype.IFileOrFolder element = this.State.Move(this, name, PathFrom, PathTo);
            return element;
        }
        public void DeleteRequest(string name, string PathFrom)
        {
            this.State.Delete(this, name, PathFrom);
        }
    }
}
