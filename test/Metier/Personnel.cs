using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public abstract class Personnel
    {
        public string Nom { get; set; }


        public Personnel(string nom)
        {
            Nom = nom;
        }

        public void Log(string input)
        {
            Console.WriteLine("[" + Nom + "]" + input);
        }

        public abstract void Tick();
    }
}
