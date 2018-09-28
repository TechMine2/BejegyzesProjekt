using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BejegyzesProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            //2a
            List<Bejegyzes> lista = new List<Bejegyzes>();
            //2b
            Console.Write("Kérem adjon megy egy darabszámot: ");
            int db = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < db; i++)
            {
                Console.Write("Kérem adjon meg egy bejegyzést\nSzerző: ");
                string szerzo = Console.ReadLine();
                Console.Write("Tartalom: ");
                string tartalom = Console.ReadLine();
                lista.Add(new Bejegyzes(szerzo, tartalom));
            }
            //2b+
            StreamReader beolvas = new StreamReader("bejegyzesek.txt");
            while (!beolvas.EndOfStream)
            {
                string sor = beolvas.ReadLine();
                string[] adatok = sor.Split(';');

                lista.Add(new Bejegyzes(adatok[0], adatok[1]));
            }
            beolvas.Close();

            //2c
            int bejegyzes20 = lista.Count() * 20;

            Random rnd = new Random();

            for (int i = 0; i < bejegyzes20; i++)
            {
                int random = rnd.Next(0, lista.Count());
                lista[random].Like();
                //Console.WriteLine("A {0}. kapott 1 lájkot", random);
            }

            //2d
            Console.Write("Kérem módosítja a 2. bejegyzést!\nTartalom: ");
            lista[1].SetTartalom(Console.ReadLine());

            //2e
            //megnézni a listat
            for (int i = 0; i < lista.Count(); i++)
            {
                lista[i].Kiir();
            }

            //3a
            int legnepszerubbID = 0;
            for (int i = 0; i < lista.Count(); i++)
            {
                if (legnepszerubbID < lista[i].GetLikeok())
                {
                    legnepszerubbID = i;
                }
            }
            Console.WriteLine("Legtöbb lájk: {0}", lista[legnepszerubbID].GetLikeok());

            //3b
            int seged = 0;
            bool vanEOlyanBejegyzesAmi35NelTobb = false;
            while (vanEOlyanBejegyzesAmi35NelTobb == false && seged < lista.Count())
            {
                if (lista[seged].GetLikeok() > 35)
                {
                    vanEOlyanBejegyzesAmi35NelTobb = true;
                }
                seged++;
            }
            if (vanEOlyanBejegyzesAmi35NelTobb)
            {
                Console.WriteLine("Van 35 lájknál több");
            }

            //3c
            int hanyOlyanBejegyzesAmi15LajknalKevesebb = 0;
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].GetLikeok() < 15)
                {
                    hanyOlyanBejegyzesAmi15LajknalKevesebb++;
                }
            }
            Console.WriteLine("{0}db bejegyzés van aminek 15-nél kevesebb lájkja van.", hanyOlyanBejegyzesAmi15LajknalKevesebb);


            Console.ReadKey();
            //3d
            for (int ID = lista.Count() - 1; ID > 0; ID--)
            {
                int maxID = ID;
                for (int ID_2 = 0; ID_2 <= ID; ID_2++)
                {
                    if (lista[ID_2].GetLikeok() > lista[maxID].GetLikeok())
                    {
                        maxID = ID_2;
                        Bejegyzes csere = lista[ID];
                        lista[ID] = lista[maxID];
                        lista[maxID] = csere;
                    }
                }
            }
            //megnézni a listat
            for (int i = 0; i < lista.Count(); i++)
            {
                lista[i].Kiir();
            }





        }
    }
}
