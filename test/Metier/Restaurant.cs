using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Metier
{
    public class Restaurant
    {


        public List<Carre> CarresList { get; set; }
        //List<Carre> CarresList = new List<Carre>();
        public List<GroupeClient> FileAttente { get; set; }
        public List<GroupeClient> GroupesPresentsDansLeResto { get; set; } = new List<GroupeClient>();
        public MaitreHotel MaitreHotel { get; set; }
        public Cuisine Cuisine { get; set; }

        public Restaurant()
        {
            FileAttente = new List<GroupeClient>();
            CarresList = new List<Carre>();
        }

        public void Tick()
        {
            MaitreHotel.Tick();
            Cuisine.Tick();
            foreach (var carre in CarresList)
            {
                carre.CDR.Tick();
                carre.Serveur1.Tick();
                carre.Serveur2.Tick();
                foreach (var groupe in GroupesPresentsDansLeResto)
                {
                    groupe.Tick();
                }
            }
        }

        public void TickFor(int x)
        {
            for (int i = 0; i < x; i++)
            {
                Console.WriteLine("## " + i + " ##");
                Tick();
            }
        }

        public void GroupeClientArrive(GroupeClient groupeClient)
        {
            this.FileAttente.Add(groupeClient);

        }

    }
}
//test