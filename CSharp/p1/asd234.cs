namespace asd
{
    public class Termek
    {
        public string Tipus { get; set; }
        public string Nev { get; set; }
        public int Tomeg { get; set; }
        public int Kaloria { get; set; }
        public double Feherje { get; set; }
        public double Szenhidrat { get; set; }
        public double Zsir { get; set; }
        public int Ar { get; set; }
        public Termek(string[] sor)
        {
            Tipus = sor[0];
            Nev = sor[1];
            Tomeg = int.Parse(sor[2]);
            Kaloria = int.Parse(sor[3]);
            Feherje = double.Parse(sor[4]);
            Szenhidrat = double.Parse(sor[5]);
            Zsir = double.Parse(sor[6]);
            Ar = int.Parse(sor[7]);
        }

        public override string ToString()
        {
            return $"{Tipus} - {Nev}: {Tomeg}g, {Kaloria}kcal, {Feherje}g fehérje, {Szenhidrat}g szénhidrát, {Zsir}g zsír, {Ar} Ft";
        }
    }
    internal class ProgramTermekek
    {
        static void Main(string[] args)
        {
            string filename = "termekek.txt";

            List<Termek> termekek = new List<Termek>();

            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 8)
                    {
                        Termek termek = new Termek(parts);
                        termekek.Add(termek);
                        Console.WriteLine(termek.ToString());
                    }
                }
            }

            Console.WriteLine($"1. Összes termék száma: {termekek.Count}");

            Console.WriteLine("2. Termékek típus szerint:");
            var tipusok = termekek.GroupBy(t => t.Tipus);
            foreach (var tipus in tipusok)
            {
                Console.WriteLine($"   {tipus.Key}: {tipus.Count()} db");
            }

            Console.WriteLine("3. Legdrágább termék:");
            var legdragabb = termekek.OrderByDescending(t => t.Ar).FirstOrDefault();
            if (legdragabb != null)
            {
                Console.WriteLine(legdragabb.ToString());
            }

            Console.WriteLine("4. Legolcsóbb termék:");
            var legolcsobb = termekek.OrderBy(t => t.Ar).FirstOrDefault();
            if (legolcsobb != null)
            {
                Console.WriteLine(legolcsobb.ToString());
            }

            Console.WriteLine("5. Átlagos ár:");
            var atlagosAr = termekek.Average(t => t.Ar);
            Console.WriteLine($"   {atlagosAr:F2} Ft");

            Console.WriteLine("6. 500kcal felett vagy 10g fehérje:");
            var keresettTermek = termekek.Where(t => t.Kaloria > 500 || t.Feherje > 10);
            foreach (var termek in keresettTermek)
            {
                Console.WriteLine(termek.ToString());
            }

            Console.WriteLine("7. Legmagasabb fehérjetartalmú termék:");
            var legfeherjedusabb = termekek.OrderByDescending(t => t.Feherje).FirstOrDefault();
            if (legfeherjedusabb != null)
            {
                Console.WriteLine(legfeherjedusabb.ToString());
            }

            Console.WriteLine("8. Összes csoki:");
            var Csokik = termekek.Where(t => t.Tipus == "CSOKI");
            foreach (var csoki in Csokik)
            {
                Console.WriteLine(csoki.ToString());
            }

            termekek.OrderBy(t => t.Ar).ThenByDescending(t => t.Kaloria);

            Console.WriteLine("9. Keresés:");
            string nevKer = Console.ReadLine();
            var keresettNev = termekek.Where(t => t.Nev == nevKer);
            if (!keresettNev.Any())
            {
                Console.WriteLine("Nincs ilyen nevű termék.");
            }
            else
            {
                foreach (var termek in keresettNev)
                {
                    Console.WriteLine(termek.ToString());
                }
            }


            var legjobbarany = termekek.OrderByDescending(t => t.Feherje / t.Ar).FirstOrDefault();
            if (legjobbarany != null)
            {
                Console.WriteLine("10. Legjobb fehérje/ár arány:");
                Console.WriteLine(legjobbarany.ToString());
            }

            var OsszesKaloria = termekek.Sum(t => t.Kaloria);
            var OsszesFeherje = termekek.Sum(t => t.Feherje);
            var OsszesZsir = termekek.Sum(t => t.Zsir);
            Console.WriteLine("11. Összes kalória, fehérje és zsír:");
            Console.WriteLine($"   Kalória: {OsszesKaloria} kcal");
            Console.WriteLine($"   Fehérje: {OsszesFeherje} g");
            Console.WriteLine($"   Zsír: {OsszesZsir} g");
        }
    }
}
