﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Table
    {
        public string nom { get; set; }
        public int NbPlaces { get; set; }
        public GroupeClient GC { get; set; }  
        public Carre Carre { get; set; }
        public Serveur Debarasseur { get; set; }
        public bool Debarassee { get; set; } = true;

        //GroupeClient GC = new GroupeClient();

        public Table()
        {
        }
        
    }
}
