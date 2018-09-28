using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BejegyzesProjekt
{
    class Bejegyzes
    {
        /// <summary>
        /// Szerző neve
        /// </summary>
        private string szerzo;
        /// <summary>
        /// Tartalom
        /// </summary>
        private string tartalom;
        /// <summary>
        /// Lájkok száma
        /// </summary>
        private int likeok = 0;
        /// <summary>
        /// Létrehozás dátuma
        /// </summary>
        private DateTime letrejott = DateTime.Now;
        /// <summary>
        /// Legutóbbi szerkesztés dátuma
        /// </summary>
        private DateTime szerkesztve = DateTime.Now;

        public Bejegyzes()
        {
            szerzo = "Nincs";
            tartalom = "-";
            likeok = 0;
            letrejott = DateTime.Now;
            szerkesztve = DateTime.Now;
        }

        /// <summary>
        /// Új bejegyzés
        /// </summary>
        /// <param name="szerzo">A szerző neve</param>
        /// <param name="tartalom">Tartalom</param>
        public Bejegyzes(string szerzo, string tartalom)
        {
            this.szerzo = szerzo;
            this.tartalom = tartalom;
            this.likeok = 0;
            this.letrejott = DateTime.Now;
            this.szerkesztve = this.letrejott;
        }

       
        /// <summary>
        /// A bejegyzés minden adatát kiírja
        /// </summary>
        public void Kiir()
        {
            Console.WriteLine("Szerző: {0} - Lájkok: {1} - Létrejött: {2}", this.szerzo, this.likeok, this.letrejott);
            if (this.letrejott != szerkesztve)
            {
                Console.WriteLine("Szerkesztve: {0}", this.szerkesztve);
            }
            Console.WriteLine(this.tartalom+"\n");

        }

        /*
        public override string ToString()
        {
            return base.ToString();
        }*/

        public string GetSzerzo()
        {
            return this.szerzo;
        }

        public string GetTartalom()
        {
            return this.tartalom;
        }

        public void SetTartalom(string tartalom)
        {
            this.tartalom = tartalom;
            this.szerkesztve = DateTime.Now;
        }

        public int GetLikeok()
        {
            return likeok;
        }

        public DateTime GetLetrejott()
        {
            return this.letrejott;
        }

        public DateTime GetSzerkesztve()
        {
            return this.szerkesztve;
        }

        public void Like()
        {
            this.likeok++;
        }

    }
}
