using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class GroupeClient
    {
        public Table Table { get; set; }
        //public Table Table = new Table();
        public List<Client> ClientList { get; set; }

        public GroupeClient()
        {
            ClientList = new List<Client>();
        }
    }
}
