namespace konyves
{
    public class Konyv
    {
        public string szerzo { get; set; }
        public string cim { get; set; }
        public int evszam { get; set; }
        public bool van { get; set; }

        public Konyv(string szerzo, string cim, int evszam, bool van)
        {
            this.szerzo = szerzo;
            this.cim = cim;
            this.evszam = evszam;
            this.van = van;
        }

        public override string ToString()
        {
            return $"{cim} - {szerzo} ({evszam}) - {(van ? "Van" : "Nincs")}";
        }
    }

    internal class ProgramKonyvek
    {
        static string ReadLineWithPrompt(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            string filename = "konyvek.txt";

            while (true)
            {
                int input = int.Parse(ReadLineWithPrompt("1. Konyv felvetele\n2. Konyvek listazasa\n3. Kilepes\n"));

                if (input == 1)
                {
                    string szerzo = ReadLineWithPrompt("Konyv szerzoje: ");
                    string cim = ReadLineWithPrompt("Konyv cime: ");
                    int evszam = int.Parse(ReadLineWithPrompt("Konyv evszama: "));
                    bool van = bool.Parse(ReadLineWithPrompt("Van a konyv? (true/false): "));

                    Konyv ujKonyv = new Konyv(szerzo, cim, evszam, van);
                    using (StreamWriter sw = new StreamWriter(filename, true))
                    {
                        sw.WriteLine($"{szerzo};{cim};{evszam};{van}");
                    }
                    Console.WriteLine("Uj konyv felveve: " + ujKonyv.ToString());

                }
                else if (input == 2)
                {
                    Console.WriteLine("Konyvek listazasa...");
                    List<Konyv> konyvek = new List<Konyv>();

                    using (StreamReader sr = new StreamReader(filename))
                    {
                        string sor;
                        while ((sor = sr.ReadLine()) != null)
                        {
                            string[] adatok = sor.Split(';');
                            if (adatok.Length == 4)
                            {
                                Konyv konyv = new Konyv(adatok[0], adatok[1], int.Parse(adatok[2]), bool.Parse(adatok[3]));
                                konyvek.Add(konyv);
                            }
                        }
                    }
                    foreach (Konyv konyv in konyvek)
                    {
                        Console.WriteLine(konyv.ToString());
                    }
                }
                else if (input == 3)
                {
                    Console.WriteLine("Kilepes...");
                    break;
                }
                else
                {
                        Console.WriteLine("Ervenytelen valasztas. Probald ujra.");
                }
            }
        }
    }
}
