using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Treeview
    {
        public string id { get; set; }
        public string text { get; set; }
        public bool icon { get; set; }

        class li_attr { }

        class a_attr { }
        class state { }
        class data { }
        public string parent { get; set; }
    }
}
