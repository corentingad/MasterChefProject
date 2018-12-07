using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Carre
    {
        public List<Rang> RangList { get; set; }
        //List<Rang> RangList = new List<Rang>();

        public ChefDeRang CDR { get; set; }
        //ChefDeRang CDR = new ChefDeRang();

        public Carre(ChefDeRang cdr)
        {
            RangList = new List<Rang>();
            this.CDR = cdr;
            cdr.Carre = this;
        }

    }
}
//test