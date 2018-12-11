using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Commande
    {

        public List<Plat> Plats { get; set; }
        public Table Table { get; set; }
        

        public Commande()
        {
            Plats = new List<Plat>();
        }

    }
}
