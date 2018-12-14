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
        public Compteur CompteurDebarasser { get; set; } = new Compteur(4, 8);
        public bool JeDebarasse { get; set; }

        public Serveur(string nom) : base(nom)
        {
        }

        public bool EstDisponible()
        {
            if (CommandeAServir != null || JeDebarasse)
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
                foreach (var rang in Carre.RangList)
                {
                    foreach (var table in rang.Tables)
                    {
                        if (table.GC == null)
                        {
                            if((table.Debarasseur == null || table.Debarasseur == this) && table.Debarassee == false)
                            {
                                table.Debarasseur = this;
                                JeDebarasse = true;
                                Debarasser(table);
                            }
                        }
                    }
                }
            }

        }

        private void Debarasser(Table table)
        {

            CompteurDebarasser.tick();
            Log("Je débarasse la " + table.nom + " (" + CompteurDebarasser.tempsRestant() + ")");
            if (CompteurDebarasser.estTermine())
            {
                Log("La " + table.nom + " est débarassée et prête à recevoir de nouveaux clients.");
                CompteurDebarasser.reset();

                table.Debarasseur = null;
                table.Debarassee = true;
                JeDebarasse = false;
            }
        }
    }
}
