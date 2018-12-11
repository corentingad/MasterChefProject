using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class RestoBuilder
    {
        private Restaurant Restaurant { get; set; } = new Restaurant();
        private Carre LastCarre { get; set; }
        private Rang LastRang { get; set; }
        //private ChefDeRang cdr { get; set; }
        //Crée Restaurant + Maitre d'hotel
        //test
        public RestoBuilder()
        {
            this.Restaurant.MaitreHotel = new MaitreHotel("MH");
            this.Restaurant.MaitreHotel.Resto = this.Restaurant;
            this.Restaurant.Cuisine = new Cuisine("cuisine");
            this.Restaurant.Cuisine.Resto = this.Restaurant;
        }

        //Ajoute un carre
        public RestoBuilder AddCarre(string nom)
        {
            ChefDeRang cdr = new ChefDeRang(nom);
            Carre newCarre = new Carre(cdr);
            newCarre.restaurant = this.Restaurant;
            //newCarre.CDR = cdr;
            this.Restaurant.CarresList.Add(newCarre);
            this.LastCarre = newCarre;

            return this;
        }

        //Ajoute un rang dans le carre spécifier 
        public RestoBuilder AddRangInCarreDonnee(int carre)
        {
            Rang newRang = new Rang();
            this.Restaurant.CarresList[carre].RangList.Add(newRang);
            this.LastRang = newRang;
            return this;
        }

        //Ajoute un rang dans le dernier carre ajouter
        public RestoBuilder AddRangInCarre()
        {
            Rang newRang = new Rang();
            this.LastCarre.RangList.Add(newRang);
            this.LastRang = newRang;
            return this;
        }

        //Ajoute une table de "place" places dans le rang du carre spécifier
        public RestoBuilder AddTableInRangInCarreDonneDePlace(int rang, int carre, int place)
        {
            this.Restaurant.CarresList[carre].RangList[rang].Tables.Add(new Table());
            return this;
        }

        //Ajoute une table de "place" places dans le dernier rang ajouter
        public RestoBuilder AddTableInRangDePlace(int place, string nom)
        {
            Table table = new Table();
            table.NbPlaces = place;
            table.nom = nom;
            this.LastRang.Tables.Add(table);
            return this;
        }

        //Récupère le restaurant final
        public Restaurant GetRestaurant()
        {
            return this.Restaurant;
        }
    }
}