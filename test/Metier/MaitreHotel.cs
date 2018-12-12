using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class MaitreHotel : Personnel
    {
        public Restaurant Resto { get; set; }
        //Restaurant Resto = new Restaurant();

        public MaitreHotel(string nom)
            : base(nom)
        {
            Nom = nom;
        }

        public override void Tick()
        {
            if (Resto.FileAttente.Count != 0)
            {
                Log("J'ai " + Resto.FileAttente.Count + " groupes de clients en attente");
            }

            List<GroupeClient> aSuppr = new List<GroupeClient>();
            foreach (var groupeClient in Resto.FileAttente)
            {
                foreach (var carre in Resto.CarresList)
                {
                    if (carre.CDR.PeutPlacer(groupeClient))
                    {
                        carre.CDR.Place(groupeClient);
                        aSuppr.Add(groupeClient);
                        break;
                    }
                }
            }
            foreach (var gc in aSuppr)
            {
                Resto.FileAttente.Remove(gc);
            }
        }

    }
}
//test