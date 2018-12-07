using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Client : Personnel
    {
        public GroupeClient GC { get; set; }
        //GroupeClient GC = new GroupeClient();

        public Client(string nom)
            : base(nom)
        {
            Nom = nom;
        }

        public override void Tick()
        {
            throw new NotImplementedException();
        }
    }

}
//test