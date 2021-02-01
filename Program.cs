using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Nobel
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 2. feladat
            StreamReader Olvas = new StreamReader("nobel.csv", Encoding.Default);
            List<Dijazott> Nobel = new List<Dijazott>();
            string Fejlec = Olvas.ReadLine();
            while (!Olvas.EndOfStream)
            {
                Nobel.Add(new Dijazott(Olvas.ReadLine()));
            }
            Olvas.Close();
            #endregion

            #region 3. feladat
            for (int i = 0; i < Nobel.Count; i++)
            {
                if (Nobel[i].VezNev == "McDonald" && Nobel[i].KerNev == "Arthur B.")
                {
                    Console.WriteLine("3. feladat: " + Nobel[i].Tipus);
                }
            }
            #endregion

            #region 4. feladat
            for (int i = 0; i < Nobel.Count; i++)
            {
                if (Nobel[i].Ev == 2017 && Nobel[i].Tipus == "irodalmi")
                {
                    Console.WriteLine($"4. feladat: {Nobel[i].KerNev} {Nobel[i].VezNev}");
                }
            }
            #endregion

            #region 5. feladat
            Console.WriteLine("5. feladat:");
            for (int i = 0; i < Nobel.Count; i++)
            {
                if (Nobel[i].Tipus == "béke" && Nobel[i].VezNev == "" && Nobel[i].Ev >= 1990)
                {
                    Console.WriteLine($"\t{Nobel[i].Ev}: {Nobel[i].KerNev}");
                }
            }
            #endregion

            #region 6. feladat
            Console.WriteLine("6. feladat:");
            for (int i = 0; i < Nobel.Count; i++)
            {
                if (Nobel[i].VezNev.Contains("Curie"))
                {
                    Console.WriteLine($"\t{Nobel[i].Ev}: {Nobel[i].KerNev} {Nobel[i].VezNev} ({Nobel[i].Tipus})");
                }
            }
            #endregion

            #region 7. feladat
            Console.WriteLine("7. feladat:");
            List<string> TipusLista = new List<string>();
            for (int i = 0; i < Nobel.Count; i++)
            {
                bool SzerepelE = false;
                for (int j = 0; j < TipusLista.Count; j++)
                {
                    if (Nobel[i].Tipus == TipusLista[j])
                    {
                        SzerepelE = true;
                    }
                }
                if (SzerepelE == false)
                {
                    TipusLista.Add(Nobel[i].Tipus);
                }
            }
            int[] TipusListaSeged = new int[TipusLista.Count];
            for (int i = 0; i < Nobel.Count; i++)
            {
                for (int j = 0; j < TipusLista.Count; j++)
                {
                    if (Nobel[i].Tipus == TipusLista[j])
                    {
                        TipusListaSeged[j]++;
                    }
                }
            }
            for (int i = 0; i < TipusListaSeged.Length; i++)
            {
                Console.WriteLine($"\t{TipusLista[i]} {TipusListaSeged[i]} db");
            }
            #endregion

            #region 8. feladat
            Console.WriteLine("8. feladat: orvosi.txt");
            StreamWriter Iro = new StreamWriter("orvosi.txt", false, Encoding.UTF8);
            for (int i = Nobel.Count -1; i >= 0; i--)
            {
                if (Nobel[i].Tipus == "orvosi")
                {
                    Iro.WriteLine($"{Nobel[i].Ev}:{Nobel[i].KerNev} {Nobel[i].VezNev}");
                }
            }Iro.Close();
            #endregion
            Console.ReadKey();
        }
    }
    class Dijazott
    {
        public int Ev;
        public string Tipus;
        public string KerNev;
        public string VezNev;

        public Dijazott(string AdatSor)
        {
            string[] AdatSorElemek = AdatSor.Split(';');
            this.Ev = int.Parse(AdatSorElemek[0]);
            this.Tipus = AdatSorElemek[1];
            this.KerNev = AdatSorElemek[2];
            this.VezNev = AdatSorElemek[3];
        }
    }
}
