using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.State
{
    abstract class ListState
    {
        public abstract Prototype.IFileOrFolder Copy(DecisionMaker context, string name, string PathFrom, string PathTo);
        public abstract Prototype.IFileOrFolder Move(DecisionMaker context, string name, string PathFrom, string PathTo);
        public abstract void Delete(DecisionMaker context, string name, string PathFrom);

    }
}
