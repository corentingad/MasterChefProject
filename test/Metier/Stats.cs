using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Stats : Personnel
    {
        static int x = 200;

        public int[] MH_Activity { get; set; } = new int[x];
        public int[] CDR_Activity { get; set; } = new int[x];
        public int[] Serveur1_Activity { get; set; } = new int[x];
        public int[] Serveur2_Activity { get; set; } = new int[x];
        public int[] Cuisine_Activity { get; set; } = new int[x];
        public int[] All_Activity{ get; set; } = new int[x];

        

        public Stats() : base("Statistiques")
        {
            
        }

        public override void Tick()
        {

        }
    }
}
