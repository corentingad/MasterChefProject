using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Serveur : Personnel
    {
        public Carre Carre { get; set; }

        public Commande CommandeAServir { get; set; }

        public Serveur(string nom) :base(nom)
        {
        }

        public bool EstDisponible()
        {
            if (CommandeAServir != null)
            {
                return false;
            }
            return true;
        }

        public void ServirCommande(Commande commande)
        {
            CommandeAServir = commande;
            Log("Je sers la commande de la " + CommandeAServir.Table.nom);
            CommandeAServir.Table.GC.EstServi = true;

            CommandeAServir = null;
            
        }

        public override void Tick()
        {
            if (EstDisponible())
            {
                //ServirCommande();
            }
        }
    }
}
