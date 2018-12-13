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