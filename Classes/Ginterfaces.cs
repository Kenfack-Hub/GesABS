using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GesPres.Classes
{
    public class Ginterfaces
    {
        public void activercontroles(Control ctl)
        {
            foreach(Control c in ctl.Controls)
            {
                c.Enabled = true;
            }   
        }
        public void Desactivercontroles(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                c.Enabled = false;
            }
        }
    }
}
