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
        public MaitreHotel MaitreHotel { get; set; }

        public Restaurant()
        {
            FileAttente = new List<GroupeClient>();
            CarresList = new List<Carre>();
        }

        public void Tick()
        {
            MaitreHotel.Tick();
            foreach (var carre in CarresList)
            {
                carre.CDR.Tick();
            }
        }

        public void TickFor(int x)
        {
            for (int i = 0; i < x; i++)
                Tick();
        }

        public void GroupeClientArrive(GroupeClient groupeClient)
        {
            this.FileAttente.Add(groupeClient);

        }

    }
}
