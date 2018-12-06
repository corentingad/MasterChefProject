using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Rang
    {
        public List<Table> Tables { get; set; }

        public Rang()
        {
            Tables = new List<Table>();
        }
    }
}
