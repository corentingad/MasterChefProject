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
        public Compteur CompteurService { get; set; } = new Compteur(5, 5);


        public Serveur(string nom) : base(nom)
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

        public void DonneCommande(Commande commande)
        {
            CommandeAServir = commande;
        }

        public void ServirCommande()
        {
            CompteurService.tick();
            Log("Le serveur se déplace vers la table (" + CompteurService.tempsRestant() + ")");
            if (CompteurService.estTermine()) 
            {
                Log("Je sers la commande de la " + CommandeAServir.Table.nom);
                CommandeAServir.Table.GC.EstServi = true;

                CommandeAServir = null;
                CompteurService.reset();
            }
        }

        public override void Tick()
        {
            if (CommandeAServir != null)
            {
                ServirCommande();
            }
            else
            {
                //Log("Le serveur n'a rien à faire");
            }

        }
    }
}
