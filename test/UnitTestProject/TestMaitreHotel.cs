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

            var c = new Carre(new ChefDeRang(), new Serveur("Serveur1"), new Serveur("Serveur2"));
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

            var c = new Carre(new ChefDeRang("CDR1"), new Serveur("Serveur1"), new Serveur("Serveur2"));
            var c2 = new Carre(new ChefDeRang("CDR2"), new Serveur("Serveur1"), new Serveur("Serveur2"));
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
            Restaurant r = rb//
                .AddCarre("cdr1")//
                .AddRangInCarre()//
                .AddTableInRangDePlace(3, "1ere table")//

                .AddCarre("cdr2")//
                .AddRangInCarre()//
                .AddTableInRangDePlace(4, "2eme table")//

                .GetRestaurant();

            r.GroupeClientArrive(gc);
            r.GroupeClientArrive(gc2);
            r.TickFor(30);

            Assert.IsNotNull(gc.Table);
            Assert.AreEqual(0, r.FileAttente.Count);
            Assert.AreEqual("1ere table", gc.Table.nom);
            Assert.AreEqual("2eme table", gc2.Table.nom);
        }

        [TestMethod]
        public void TestCommande()
        {

            GroupeClient gc = new GroupeClient();

            var c1 = new Client("Rudy");
            var cl2 = new Client("Corentin");
            var c3 = new Client("Cyril");
            gc.ClientList.Add(c1);
            gc.ClientList.Add(cl2);
            gc.ClientList.Add(c3);

            RestoBuilder rb = new RestoBuilder();
            Restaurant r = rb//

                .AddCarre("cdr1")//
                .AddRangInCarre()//
                .AddTable(3, "1ere table", 0, 0)//


                .GetRestaurant();

            r.GroupeClientArrive(gc);
            r.TickFor(100);

            Assert.IsNotNull(gc.Table);
            Assert.AreEqual(0, r.FileAttente.Count);
            Assert.AreEqual("1ere table", gc.Table.nom);
        }

        [TestMethod]
        public void TestService()
        {

            GroupeClient gc = new GroupeClient();

            var c1 = new Client("Rudy");
            var cl2 = new Client("Corentin");
            var c3 = new Client("Cyril");
            gc.ClientList.Add(c1);
            gc.ClientList.Add(cl2);
            gc.ClientList.Add(c3);

            RestoBuilder rb = new RestoBuilder();
            Restaurant r = rb//

                .AddCarre("cdr1")//
                .AddRangInCarre()//
                .AddTable(3, "1ere table", 0, 0)//


                .GetRestaurant();

            r.GroupeClientArrive(gc);
            r.TickFor(100);

            Assert.IsNotNull(gc.Table);
            Assert.AreEqual(0, r.FileAttente.Count);
            Assert.AreEqual("1ere table", gc.Table.nom);
            Assert.AreEqual(true, r.CarresList[0].RangList[0].Tables[0].GC.EstServi);
        }

        [TestMethod]
        public void TestMultiGroupe()
        {

            GroupeClient gc = new GroupeClient();
            GroupeClient gc2 = new GroupeClient();

            var c1 = new Client("Rudy");
            var c2 = new Client("Corentin");
            var c3 = new Client("Cyril");
            var c9 = new Client("Gérald");
            gc.ClientList.Add(c1);
            gc.ClientList.Add(c2);
            gc.ClientList.Add(c3);
            gc.ClientList.Add(c9);

            var c4 = new Client("Rudy");
            var c5 = new Client("Corentin");
            var c6 = new Client("Cyril");
            gc2.ClientList.Add(c4);
            gc2.ClientList.Add(c5);
            gc2.ClientList.Add(c6);

            RestoBuilder rb = new RestoBuilder();
            Restaurant r = rb//

                .AddCarre("cdr1")//
                .AddRangInCarre()//
                .AddTable(2, "1ere table", 0, 0)//
                .AddTable(3, "2eme table", 0, 0)//
                .AddTable(4, "3eme table", 0, 0)//


                .GetRestaurant();

            r.GroupeClientArrive(gc);
            r.GroupeClientArrive(gc2);
            r.TickFor(200);

            Assert.IsNull(gc.Table);
            Assert.AreEqual(0, r.FileAttente.Count);
        }

        [TestMethod]
        public void TestMultiGroupe3()
        {

            GroupeClient gc = new GroupeClient();
            GroupeClient gc2 = new GroupeClient();
            GroupeClient gc3 = new GroupeClient();

            var c1 = new Client("Rudy");
            var c2 = new Client("Corentin");
            var c3 = new Client("Cyril");
            var c9 = new Client("Gérald");
            gc.ClientList.Add(c1);
            gc.ClientList.Add(c2);
            gc.ClientList.Add(c3);
            gc.ClientList.Add(c9);

            var c4 = new Client("Rudy");
            var c5 = new Client("Corentin");
            var c6 = new Client("Cyril");
            gc2.ClientList.Add(c4);
            gc2.ClientList.Add(c5);
            gc2.ClientList.Add(c6);

            var c7 = new Client("Rudy");
            var c81 = new Client("Corentin");
            gc3.ClientList.Add(c7);
            gc3.ClientList.Add(c81);

            RestoBuilder rb = new RestoBuilder();
            Restaurant r = rb//

                .AddCarre("cdr1")//
                .AddRangInCarre()//
                .AddTable(2, "1ere table", 0, 0)//
                .AddTable(3, "2eme table", 0, 0)//
                .AddTable(4, "3eme table", 0, 0)//


                .GetRestaurant();

            r.GroupeClientArrive(gc);
            r.GroupeClientArrive(gc2);
            r.TickFor(200);

            Assert.IsNull(gc.Table);
            Assert.AreEqual(0, r.FileAttente.Count);
        }
    }
}
