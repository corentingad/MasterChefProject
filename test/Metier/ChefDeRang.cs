﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class ChefDeRang : Personnel
    {
        public Carre Carre { get; set; }
        public GroupeClient GroupeEnTrainDePrendreLaCommande { get; set; }


        Table meilleureTable;
        GroupeClient groupeAccompagne;
        int nbTickPourPlacer = 3;
        int nbTickRestantPourPlacer = 3;
        Compteur cPrendreUneCommande = new Compteur(5);
        

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

            foreach (var rang in Carre.RangList)
            {
                foreach (var table in rang.Tables)
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

            if (groupeAccompagne != null)
            {

                this.accompagneGroupe();

            }
            else if (GroupeEnTrainDePrendreLaCommande != null)
            {
                this.PrendreUneCommande();
            }
            else 
            {

                this.vérifieCommandeAPrendre();
              
            }
        }

        private void PrendreUneCommande()
        {
            Log("Le chef de rang prend la commande");
            cPrendreUneCommande.tick();
            if (cPrendreUneCommande.estTermine())
            {
                Log("La commande est prise");
                Commande c = new Commande();
                c.Table = GroupeEnTrainDePrendreLaCommande.Table;
                foreach (var client in GroupeEnTrainDePrendreLaCommande.ClientList)
                {

                    c.Plats.Add(new Plat());
                    
                }


                Carre.restaurant.Cuisine.NouvelleCommande(c);

                GroupeEnTrainDePrendreLaCommande.CommandePrise = true;
                GroupeEnTrainDePrendreLaCommande = null;
                cPrendreUneCommande.reset();

                
            }
        }

        private void accompagneGroupe()
        {
            nbTickRestantPourPlacer--;
            Log("J'enmene les " + groupeAccompagne.ClientList.Count + " a leur table (" + nbTickRestantPourPlacer + ")");

            if (nbTickRestantPourPlacer == 0)
            {
                
                Log("Je les place sur la table " + meilleureTable.nom + " !");
                groupeAccompagne.Table = meilleureTable;
                meilleureTable.GC = groupeAccompagne;
                meilleureTable = null;
                nbTickRestantPourPlacer = nbTickPourPlacer;
                groupeAccompagne = null;
            }
        }

        private void vérifieCommandeAPrendre()
        {
            
            foreach (var rang in Carre.RangList)
            {
                foreach (var table in rang.Tables)
                {
                    if(table.GC == null)
                        continue;

                    if (table.GC.CommandePrise)
                        continue;
                    Log("Les clients sont en train de réfléchir à leur commande  (" + table.GC.nbTickRestantCommande + ")");
                    table.GC.nbTickRestantCommande--;
                    if(table.GC.nbTickRestantCommande == 0)
                    {
                        GroupeEnTrainDePrendreLaCommande = table.GC;
                        break;
                    }

                }    
            }

        }
        //Carre Carre = new Carre();
    }
}
