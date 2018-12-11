using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Cuisine : Personnel
    {

        public Cuisine(string nom) : base(nom)
        {

            Nom = nom;

        }

        public Restaurant Resto { get; set; }

        public override void Tick()
        {
            
        }

        internal void NouvelleCommande(Commande c)
        {
            throw new NotImplementedException();
        }
    }
}

