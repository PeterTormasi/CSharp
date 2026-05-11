namespace Asd
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string mappaUtvonal = @"C:\premo\harom\";
            string fajlNev = "jatekos.txt";
            string filepath = Path.Combine(mappaUtvonal, fajlNev);

            List<string> jatekosok = new List<string> {};

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"A {i}. jatekos adatai: ");
                Console.WriteLine($"Név: "); string nev = Console.ReadLine();
                Console.WriteLine($"Születési év: "); string szulev = Console.ReadLine();
                Console.WriteLine($"Magasság: "); string magas = Console.ReadLine();
                Console.WriteLine($"Bajnokságban dobot pontok: "); string pontok = Console.ReadLine();
                jatekosok.Add($"{nev} {szulev} {magas} {pontok}");
            }

            Directory.CreateDirectory(mappaUtvonal);
            File.WriteAllLines(filepath, jatekosok);
            Console.WriteLine("--- Mentés sikeres ---");

            Console.WriteLine("A fájl tartalma:");
            foreach (string sor in File.ReadAllLines(filepath))
            {
                Console.WriteLine(sor);
            }
        }
    }
}