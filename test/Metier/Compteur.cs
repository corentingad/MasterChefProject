using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Compteur
    {
        public int nbTickMax;
        public int nbTickMin;
        public int nbTickRestant;
        Random r = new Random();

        public Compteur(int nbTickMin, int nbTickMax)
        {
            this.nbTickMax = nbTickMax;
            this.nbTickMin = nbTickMin;
            this.nbTickRestant = r.Next(nbTickMin,nbTickMax);
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
            nbTickRestant = r.Next(nbTickMin, nbTickMax);
        }
        public int tempsRestant()
        {
            return nbTickRestant;
        }
    }
}
