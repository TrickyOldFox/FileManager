using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shell_v1._02.State
{
    class FolderChosen : ListState
    {
        public override Prototype.IFileOrFolder Copy(DecisionMaker context, string name, string PathFrom, string PathTo)
        {
            Prototype.IFileOrFolder element = new Prototype.FolderItem(PathFrom, name);
            Prototype.IFileOrFolder copiedelement = element.Clone();
            copiedelement.SetPath(PathTo);
            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(PathTo, name));
                element.Copy(copiedelement.GetPath());
                context.State = new NotReady();
            }
            catch
            {
                MessageBox.Show("An error ocured during coping process", "Error", MessageBoxButtons.OK);
                System.IO.Directory.Delete(System.IO.Path.Combine(PathTo, name));
            }
            return copiedelement;
        }
        public override Prototype.IFileOrFolder Move(DecisionMaker context, string name, string PathFrom, string PathTo)
        {
            Prototype.IFileOrFolder element = new Prototype.FolderItem(PathFrom, name);
            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(PathTo, name));
                element.Copy(PathTo);
                this.Delete(context, name, PathFrom);
                context.State = new NotReady();
            }
            catch
            {
                MessageBox.Show("An error ocured during moving process", "Error", MessageBoxButtons.OK);
                System.IO.Directory.Delete(System.IO.Path.Combine(PathTo, name));
            }
            element.SetPath(PathTo);
            return element;
        }
        public override void Delete(DecisionMaker context, string name, string PathFrom)
        {
            string SourceFolder = System.IO.Path.Combine(PathFrom, name);
            try
            {
                System.IO.Directory.Delete(SourceFolder, true);
                context.State = new NotReady();
            }
            catch
            {
                MessageBox.Show("An error ocured during deleting process", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
