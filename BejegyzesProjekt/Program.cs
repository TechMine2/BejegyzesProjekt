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
            List<Bejegyzes> lista2 = new List<Bejegyzes>();
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
            for (int i = 0; i < lista.Count(); i++)
            {

            }

        }
    }
}
