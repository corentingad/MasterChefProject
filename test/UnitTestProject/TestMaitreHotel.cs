using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Metier;
//test
namespace UnitTestProject
{
    [TestClass]
    public class TestMaitreHotel
    {
        [TestMethod]
        public void TestDispatchClient()
        {
            var r = new Restaurant();
            var mh = new MaitreHotel("Maître d'Hôtel");
            mh.Resto = r;

            var c = new Carre(new ChefDeRang());
            //c.CDR = cdr;
            //cdr.Carre = c;

            r.CarresList.Add(c);
            var rang = new Rang();
            c.RangList.Add(rang);
            var table = new Table();
            table.NbPlaces = 3;
            rang.Tables.Add(table);


            GroupeClient gc = new GroupeClient();

            var c1 = new Client("Rudy");
            var c2 = new Client("Corentin");
            var c3 = new Client("Cyril");
            gc.ClientList.Add(c1);
            gc.ClientList.Add(c2);
            gc.ClientList.Add(c3);


            r.MaitreHotel = mh;

            r.GroupeClientArrive(gc);
            r.TickFor(3);

            Assert.IsNotNull(gc.Table);
            Assert.AreEqual(0, r.FileAttente.Count);
        }
        [TestMethod]
        public void TestDispatchClient2emeCarre()
        {
            var r = new Restaurant();
            var mh = new MaitreHotel("Maître d'Hôtel");
            mh.Resto = r;

            var c = new Carre(new ChefDeRang("CDR1"));
            var c2 = new Carre(new ChefDeRang("CDR2"));
            //c.CDR = cdr;
            //cdr.Carre = c;

            r.CarresList.Add(c);
            var rang = new Rang();
            c.RangList.Add(rang);
            var table = new Table();
            table.nom = "1ere table";
            table.NbPlaces = 3;
            table.GC = new GroupeClient();
            rang.Tables.Add(table);

            r.CarresList.Add(c2);
            var rang2 = new Rang();
            c2.RangList.Add(rang2);
            var table2 = new Table();
            table2.nom = "2eme table";
            table2.NbPlaces = 4;
            rang2.Tables.Add(table2);


            GroupeClient gc = new GroupeClient();

            var c1 = new Client("Rudy");
            var cl2 = new Client("Corentin");
            var c3 = new Client("Cyril");
            gc.ClientList.Add(c1);
            gc.ClientList.Add(cl2);
            gc.ClientList.Add(c3);


            r.MaitreHotel = mh;

            r.GroupeClientArrive(gc);
            r.TickFor(3);

            Assert.IsNotNull(gc.Table);
            Assert.AreEqual(0, r.FileAttente.Count);
            Assert.AreEqual("2eme table", gc.Table.nom);
        }
        [TestMethod]
        public void TestDispatchClient1erCDRPasDispo()
        {
            //var r = new Restaurant();
            //var mh = new MaitreHotel("Maître d'Hôtel");
            //mh.Resto = r;

            //var c = new Carre(new ChefDeRang("CDR1"));
            //var c2 = new Carre(new ChefDeRang("CDR2"));
            ////c.CDR = cdr;
            ////cdr.Carre = c;

            //r.CarresList.Add(c);
            //var rang = new Rang();
            //c.RangList.Add(rang);
            //var table = new Table();
            //table.nom = "1ere table";
            //table.NbPlaces = 3;
            ////table.GC = new GroupeClient();
            //rang.Tables.Add(table);

            //r.CarresList.Add(c2);
            //var rang2 = new Rang();
            //c2.RangList.Add(rang2);
            //var table2 = new Table();
            //table2.nom = "2eme table";
            //table2.NbPlaces = 4;
            //rang2.Tables.Add(table2);


            GroupeClient gc = new GroupeClient();

            var c1 = new Client("Rudy");
            var cl2 = new Client("Corentin");
            var c3 = new Client("Cyril");
            gc.ClientList.Add(c1);
            gc.ClientList.Add(cl2);
            gc.ClientList.Add(c3);

            GroupeClient gc2 = new GroupeClient();

            var c12 = new Client("Rudy");
            var cl22 = new Client("Corentin");
            gc2.ClientList.Add(c12);
            gc2.ClientList.Add(cl22);


            //r.MaitreHotel = mh;

            RestoBuilder rb = new RestoBuilder();
            Restaurant r = rb.AddCarre("cdr1").AddRangInCarre().AddTableInRangDePlace(3, "1ere table").AddCarre("cdr2").AddRangInCarre().AddTableInRangDePlace(4,"2eme table").GetRestaurant();

            r.GroupeClientArrive(gc);
            r.GroupeClientArrive(gc2);
            r.TickFor(3);

            Assert.IsNotNull(gc.Table);
            Assert.AreEqual(0, r.FileAttente.Count);
            Assert.AreEqual("1ere table", gc.Table.nom);
            Assert.AreEqual("2eme table", gc2.Table.nom);
        }
    }
}
