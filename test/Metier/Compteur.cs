using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    class Compteur
    {
        int nbTickMax;
        int nbTickRestant;
        public Compteur(int nbTickMax)
        {
            this.nbTickMax = nbTickMax;
            this.nbTickRestant = nbTickMax;
        }

        public bool estTermine()
        {
            return nbTickRestant == 0;
        }

        public void tick()
        {
            nbTickRestant--;
        }
        public void reset()
        {
            nbTickRestant = nbTickMax;
        }
    }
}
