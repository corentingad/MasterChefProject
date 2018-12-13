using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Cuisine : Personnel
    {

        public List<Commande> CommandesEnAttente { get; set; } = new List<Commande>();
        public List<Commande> CommandesPretes { get; set; } = new List<Commande>();
        public Plat PlatEnCours { get; set; }

        public Restaurant Resto { get; set; }
        Compteur TempsDePreparation = new Compteur(5, 10);

        public Cuisine(string nom) : base(nom)
        {

            Nom = nom;

        }

        public override void Tick()
        {
            if (CommandesEnAttente.Count != 0)
            {

                this.PreparationCommande(CommandesEnAttente[0]);

            }
            else if (CommandesPretes.Count != 0)
            {
                var temp = CommandesPretes[0];

                if (CommandesPretes[0].Table.Carre.Serveur1.EstDisponible())
                {
                    Log("serveur 1 dispo");

                    CommandesPretes[0].Table.Carre.Serveur1.ServirCommande(CommandesPretes[0]);
                    CommandesPretes.RemoveAt(0);
                }
                else if (CommandesPretes[0].Table.Carre.Serveur2.EstDisponible())
                {
                    Log("serveur 2 dispo");

                    CommandesPretes[0].Table.Carre.Serveur2.ServirCommande(CommandesPretes[0]);
                    CommandesPretes.RemoveAt(0);
                }
                else
                {
                    Log("Aucun serveur dispo");
                }
            }
            else
            {
                //Log("Nous n'avons rien a faire");
            }


        }

        internal void NouvelleCommande(Commande c)
        {
            if (c != null)
                CommandesEnAttente.Add(c);

        }

        public void PreparationCommande(Commande c)
        {

            if (PlatEnCours == null)
            {
                foreach (var p in c.Plats)
                {
                    if (p.PlatPret == false)
                    {
                        PlatEnCours = p;
                        break;
                    }
                }
            }
            else
            {

                Log("Plat en préparation (" + TempsDePreparation.tempsRestant() + ")");
                TempsDePreparation.tick();

                if (TempsDePreparation.estTermine())
                {
                    PlatEnCours.PlatPret = true;
                    PlatEnCours = null;
                    Log("Un plat est pret");
                    TempsDePreparation.reset();
                }
            }

            if (c.Plats.Last().PlatPret)
            {
                CommandesEnAttente.Remove(c);
                CommandesPretes.Add(c);
                Log("Ca degage");
            }
        }


    }
}

