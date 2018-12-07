using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class ChefDeRang : Personnel
    {
        public Carre Carre { get; set; }
        Table meilleureTable;
        GroupeClient groupeAccompagne;
        int nbTickPourPlacer = 3;
        int nbTickRestantPourPlacer = 3;

        public ChefDeRang(string nom) : base(nom)
        {

        }
        public ChefDeRang() : base("Chef de rang")
        {

        }

        public bool PeutPlacer(GroupeClient groupeClient)
        {
            if (groupeAccompagne != null)
                return false;//Je bosse je ne peut pas les enmener a une table
            foreach(var rang in Carre.RangList)
            {
                foreach(var table in rang.Tables)
                {
                    if (table.NbPlaces < groupeClient.ClientList.Count)
                        continue;
                    if (table.GC != null)
                        continue;

                    if (meilleureTable == null)
                        meilleureTable = table;

                    if (table.NbPlaces < meilleureTable.NbPlaces)
                        meilleureTable = table;
                }
            }
            return meilleureTable != null;
        }

        public void Place(GroupeClient groupeClient)
        {
            groupeAccompagne = groupeClient;
        }

        public override void Tick()
        {
            if(groupeAccompagne != null)
            {
                nbTickRestantPourPlacer--;
                Log("J'enmene les " + groupeAccompagne.ClientList.Count+" a leur table ("+nbTickRestantPourPlacer+")");
                if(nbTickRestantPourPlacer == 0)
                {
                    Log("Je les place sur la table "+meilleureTable.nom+" !");
                    groupeAccompagne.Table = meilleureTable;
                    meilleureTable.GC = groupeAccompagne;
                    meilleureTable = null;
                    nbTickRestantPourPlacer = nbTickPourPlacer;
                    groupeAccompagne = null;
                }
            }
        }
        //Carre Carre = new Carre();
    }
}
