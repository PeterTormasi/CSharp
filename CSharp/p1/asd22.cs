using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace file_negy
{
    // 1. Létrehozunk egy osztályt az adatoknak
    public class Eloadas
    {
        public string Cim { get; set; }
        public int Honap { get; set; }
        public int Nap { get; set; }
        public int KezdesPerc { get; set; }
        public int Idotartam { get; set; }
        public string Szinhaz { get; set; }
        public string Varos { get; set; }
        public Eloadas(string[] sor)
        {
            Cim = sor[0];
            Honap = int.Parse(sor[1]);
            Nap = int.Parse(sor[2]);
            KezdesPerc = int.Parse(sor[3]);
            Idotartam = int.Parse(sor[4]);
            Szinhaz = sor[5];
            Varos = sor[6];
        }
        public override string ToString()
        {
            return $" {Cim} {Honap} {Nap} {KezdesPerc} {Idotartam} {Szinhaz} {Varos}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Eloadas> eloadasok = new List<Eloadas>();
            // Adatbeolvasás
            string utvonal = "eloadasok.txt";
            if (File.Exists(utvonal))
            {
                foreach (string sor in File.ReadLines(utvonal, Encoding.UTF8))
                {
                    eloadasok.Add(new Eloadas(sor.Trim().Split('\t')));
                }
            }
            // Rendezés nap és kezdési idő szerint
            var rendezettLista = eloadasok.OrderBy(e => e.Nap).ThenBy(e => e.KezdesPerc).ToList();
            // 2. feladat: Naponkénti csoportosítás
            int minNap = rendezettLista.Min(e => e.Nap);
            int maxNap = rendezettLista.Max(e => e.Nap);
            for (int i = minNap; i <= maxNap; i++)
            {
                Console.WriteLine($"\nnovember {i}.: ");
                var napiEloadasok = rendezettLista.Where(e => e.Nap == i).ToList();
                for (int j = 0; j < napiEloadasok.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {napiEloadasok[j].Cim} : {napiEloadasok[j].Szinhaz}");
                }
            }
            // 3. feladat: Napi összegzett hossz
            Console.WriteLine("\nNapi összesített hossz: ");
            for (int i = minNap; i <= maxNap; i++)
            {
                int osszPerc = rendezettLista.Where(e => e.Nap == i).Sum(e => e.Idotartam);
                Console.WriteLine($"{i - minNap + 1}. nap: {osszPerc / 60}:{osszPerc % 60:D2}");
            }
            // 4. feladat: Leghosszabb előadás november 6-án
            Console.WriteLine("\nLeghosszabb előadás nov. 6-án:");
            var hatodikaiak = rendezettLista.Where(e => e.Nap == 6).ToList();
            if (hatodikaiak.Any())
            {
                int maxHossz = hatodikaiak.Max(e => e.Idotartam);
                var leghosszabbak = hatodikaiak.Where(e => e.Idotartam == maxHossz);
                foreach (var e in leghosszabbak)
                {
                    Console.WriteLine($"{ e.Cim } {e.Idotartam} perc");
                }
            }
            Console.ReadKey();
        }
    }
}

