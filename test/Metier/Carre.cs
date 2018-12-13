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
        public Serveur Serveur1 { get; set; }
        public Serveur Serveur2 { get; set; } 
        public Restaurant restaurant { get; set; }

        public Carre(ChefDeRang cdr, Serveur serveur1, Serveur serveur2)
        {
            RangList = new List<Rang>();
            CDR = cdr;
            cdr.Carre = this;

            Serveur1 = serveur1;
            Serveur2 = serveur2;
            serveur1.Carre = this;
            serveur2.Carre = this;
        }

    }
}
//test