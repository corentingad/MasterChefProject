using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class GroupeClient : Personnel
    {
        Random r = new Random();

        public int nbTickRestantCommande { get; set; }
        public Table Table { get; set; }
        public List<Client> ClientList { get; set; }

        public Commande Commande { get; set; }
        public Compteur CompteurManger { get; set; } = new Compteur(25, 30);
        public Compteur CompteurPayer { get; set; } = new Compteur(5, 8);

        public bool CommandePrise { get; set; }
        public bool EstServi { get; set; }
        public bool RepasFini { get; set; }

        public GroupeClient() : base("Groupe")
        {
            ClientList = new List<Client>();

            nbTickRestantCommande = r.Next(15, 30);

        }

        public override void Tick()
        {
            if (EstServi == true && RepasFini == false)
            {
                Manger();
            }
            else if (RepasFini == true)
            {
                EstServi = false;
                Paiement(Commande);

            }
        }

        private void Paiement(Commande commande)
        {

            CompteurPayer.tick();
            Log("Nous allons payer (" + CompteurPayer.tempsRestant() + ")");
            if (CompteurPayer.estTermine())
            {
                Log(String.Format("Les clients de la {0} ont payé pour leur repas et s'en vont gaiement.", Table.nom));

                Table.GC = null;
                this.Table.Carre.restaurant.GroupesASupprDuResto.Add(this);
                this.Table = null;


            }

        }

        private void Manger()
        {
            CompteurManger.tick();
            Log(String.Format("Les {0} clients de la {1} sont en train de manger.", ClientList.Count, Table.nom));
            if (CompteurManger.estTermine())
            {
                Log("Les clients ont fini de manger");
                RepasFini = true;

                CompteurManger.reset();
            }
        }
    }
}
//test