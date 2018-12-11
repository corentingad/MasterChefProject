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

        public Restaurant Resto { get; set; }
        Compteur TempsDePreparation = new Compteur(5);

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
            else
            {
                Log("Nous n'avons rien a faire");
            }


        }

        internal void NouvelleCommande(Commande c)
        {
            if(c != null)
            CommandesEnAttente.Add(c);
           
        }

        public void PreparationCommande(Commande c)
        {

            foreach (var p in c.Plats)
            {
                PreparationPlat(p);
            }

            CommandesEnAttente.Remove(c);
            CommandesPretes.Add(c);

        }

        public void PreparationPlat(Plat p)
        {

            Log("Plat en préparation (" + TempsDePreparation.tempsRestant() + ")");
            TempsDePreparation.tick();
            
            if (TempsDePreparation.estTermine())
            {
                Log("Un plat est pret");
                TempsDePreparation.reset();
            }

        }
    }
}

