using System;
using Microsoft.VisualBasic;

namespace HelloWorld
{
    public class Stats
    {
        public static int Hp = 10;
        public static int Szint = 1;
        public static string name = "";
        public static int dmg = 1;
    }
    class Program
    {
        static int Osszeadas(List<int> list)
        {
            return list.Sum();
        }

        static void Kiiratas(string nev, int kor)
        {
            Console.WriteLine(nev + ", " + kor + " eves");
        }

        static void Kiiratas2(string iskola = "premo")
        {
            Console.WriteLine(iskola);
        }

        static void NegyzetSzamolas2()
        {
            Console.WriteLine("Kerem a negyzet oldalat: ");
            int szam = int.Parse(Console.ReadLine());
            Console.WriteLine($"A negyzet kerülete: {szam * 4}, a terulete pedig: {szam * szam}");
        }

        static void TeglalapSzamolas2()
        {
            Console.WriteLine("Kerem a teglalap a oldalat: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Kerem a teglalap b oldalat: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"A negyzet kerülete: {(a + b) * 2}, a terulete pedig: {a * b}");
        }

        static String[] NegyzetSzamolas(double a)
        {
            return new String[] { $"Kerület: {a * 4}", $"Terület: {a * a}" };
        }

        static String[] TeglalapSzamolas(double a, double b)
        {
            return new String[] { $"Kerület: {(a + b) * 2}", $"Terület: {a * b}" };
        }

        static void KiiratasTobbszor(int ciklusok, string iratni = "iratni valo")
        {
            for (int i = 0; i < ciklusok; i++)
            {
                Console.WriteLine($"{i}. {iratni}");
            }
        }

        static string Input(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            /*
            List<int> Szamok = new List<int> {1, 2, 3, 6, 4, 10, 14};
            int max = Szamok[0];
            for (int i = 0; i < Szamok.Count(); i++)
            {
                if (max < Szamok[i])
                {
                    max = Szamok[i];
                }
            }
            Console.WriteLine(max);

            Console.WriteLine("Kérem a háromszög a oldalat:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Kérem a háromszög b oldalat:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Kérem a háromszög c oldalat:");
            double c = double.Parse(Console.ReadLine());

            double s = (a + b + c) / 2;
            Console.WriteLine($"a haromszög területe: {a + b + c}, területe: {Math.Sqrt(s * (s - a) * (s - b) * (s - c))}");


            Console.WriteLine("Kérem a kör sugarát: ");
            double r = double.Parse(Console.ReadLine());

            Console.WriteLine($"A kör kerülete: {2 * r * Math.PI}, területe: {r * r * Math.PI}");


            Console.WriteLine("Kérem a teglalap a oldalat:");
            double aa = double.Parse(Console.ReadLine());

            Console.WriteLine("Kérem a teglalap b oldalat:");
            double bb = double.Parse(Console.ReadLine());

            Console.WriteLine($"A téglalap kerülete: {(aa + bb) * 2}, területe: {aa * bb}");

            Console.WriteLine(Osszeadas(new List<int> { 1, 3, 15, 6, 41, 10 }));
            
            do
            {
                Console.WriteLine("Adja meg a téglalap két oldalat a példa szerint: (a;b)");
                string input = Console.ReadLine();

                try
                {
                    string[] Szamok = input.Split(";");

                    Dictionary<int, int> Oldalak = new Dictionary<int, int> { };

                    int i = 0;

                    foreach (string szam in Szamok)
                    {
                        i++;
                        Oldalak[i] = int.Parse(szam);
                    }

                    Console.WriteLine($"A téglalap kerülete: {(Oldalak[1] + Oldalak[2])*2}, területe: {Oldalak[1] * Oldalak[2]}.");

                    break;
                }
                catch (Exception error)
                {
                    Console.WriteLine("A bemenet nem helyes!!");
                }
            } while (true);
            

            List<int> Szamok2 = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            foreach (int szam in Szamok2)
            {
                if (szam % 2 == 0)
                {
                    Console.WriteLine($"A szam paros, a szam: {szam}");    
                }
                else
                {
                    Szamok2.Remove(szam);
                }
                
            }
            Console.WriteLine(String.Join(", ", Szamok2));

            Console.WriteLine("Adj meg egy szamot (1-7): ");
            int nap = int.Parse(Console.ReadLine());
            switch (nap)
            {
                case 1:
                Console.WriteLine("Hetfo");
                break;
                case 2:
                Console.WriteLine("Kedd");
                break;
                case 3:
                Console.WriteLine("Szerda");
                break;
                case 4:
                Console.WriteLine("Csutortok");
                break;
                case 5:
                Console.WriteLine("Pentek");
                break;
                case 6:
                Console.WriteLine("Szombat");
                break;
                case 7:
                Console.WriteLine("Vasarnap");
                break;
            }
            

            Console.WriteLine("Adja meg a bementet: ");
            var input = Console.ReadLine();

            Dictionary<char, int> Ertekek = new Dictionary<char, int> {{'U', 1}, {'G', 1}, {'F', 2}, {'K', 10}};

            int ossz = 0;

            bool voltU = false, voltG = false, voltF = false, voltK = false;

            foreach (char betu in input)
            {
                ossz += Ertekek[betu];
                switch (betu)
                {
                    case 'U':
                    voltU = true;
                    break;
                    case 'G':
                    voltG = true;
                    break;
                    case 'F':
                    voltF = true;
                    break;
                    case 'K':
                    voltK = true;
                    break;
                }
            }

            Console.WriteLine(ossz);

            int jutalom = 0;

            if (voltU && voltG && voltF && voltK)
            {
                jutalom = 10;
                Console.WriteLine("hell yeah");
            }
            else
            {
                Console.WriteLine("hell nah");
            }

            Console.WriteLine($"vege = {jutalom+ossz}");

            if (jutalom+ossz > 39)
            {
                Console.WriteLine("Hell yeah GG");
            }
            else
            {
                Console.WriteLine("hell nah L");
            }

            
            List<int> Szamok2 = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            Console.WriteLine(Osszeadas(Szamok2));

            Kiiratas("Béni", 21);
            Kiiratas2("AA");
            Kiiratas2();

            Random Rand = new Random();

            try
            {
                int[] myNumbers = { 1, 2, 3 };
                Console.WriteLine(myNumbers[10]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            int b;
            int c = 0;
            int a = 10;
            try
            {
                int[] myNumbers = { 1, 2, 3 };
                b = a / c;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            NegyzetSzamolas2();

            TeglalapSzamolas2();

            KiiratasTobbszor(10, "Hajra ZETE");

            do
            {
                double ategla;
                double btegla;
                if (double.TryParse(Input("Kerem a teglalap a oldalat: "), out ategla) && double.TryParse(Input("Kerem a teglalap b oldalat: "), out btegla))
                {
                    Console.WriteLine(string.Join(", ", TeglalapSzamolas(ategla, btegla)));
                    break;
                }
                else Console.WriteLine("Nem szam");
            } while (true);

            do
            {
                Console.WriteLine("Kerem a negyzet oldalat: ");
                double szam;
                if (double.TryParse(Console.ReadLine(), out szam))
                {
                    Console.WriteLine(string.Join(", ", NegyzetSzamolas(szam)));
                    break;
                }
                else Console.WriteLine("Nem szam");
            } while (true);

            do
            {
                try
                {
                    int[] myNumbers = { 1, 2, 3 };
                    Console.WriteLine($"A lista hanyadik elemet keri? A lista: ({string.Join(", ", myNumbers)})");
                    int aa = int.Parse(Console.ReadLine());
                    Console.WriteLine($"A lista {aa}. eleme: {myNumbers[aa - 1]}");
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Valami baki van a rendszerben, error: " + e.Message);
                }
            } while (true);

            Console.Write("Mi legyen a karaktere neve: ");
            Stats.name = Console.ReadLine();
            Console.WriteLine($"A neve: {Stats.name}");

            do
            {
                int Ehp = Stats.Hp + Rand.Next(1, 10);
                int Edmg = Stats.dmg - Rand.Next(1, 5);
                Console.WriteLine("Megjelent egy ellenseg!");
                break;
            } while (true);

            List<List<object>> automata = new List<List<object>>();
            string file1 = @"C:\Users\info\Documents\CShárp\csoki.txt";

            foreach (string sor in File.ReadLines(file1))
            {
                string[] darabok = sor.Trim().Split(" ");

                List<object> adatsor = new List<object>();

                adatsor.Add(int.Parse(darabok[0]));
                adatsor.Add(int.Parse(darabok[1]));
                adatsor.Add(int.Parse(darabok[2]));
                adatsor.Add(int.Parse(darabok[3]));
                adatsor.Add(darabok[4]);

                automata.Add(adatsor);
            }

            Console.WriteLine($"Az automatában {automata.Count} féle termék van!");

            for (int i = 0; i < automata.Count; i++)
            {
                Console.WriteLine(automata[i][4]);
            }

            int db = 0;

            for (int i1 = 0; i1 < automata.Count; i1++)
            {
                db = db + (int)automata[i1][0];
            }

            Console.WriteLine(db);

            int min1 = (int)automata[0][0];

            for (int i11 = 0; i11 < automata.Count; i11++)
            {
                if (min1 > (int)automata[i11][0])
                {
                    min1 = (int)automata[i11][0];
                }
            }

            Console.WriteLine(min1);

            int max1 = 0;

            for (int i11 = 0; i11 < automata.Count; i11++)
            {
                if (max1 < (int)automata[i11][0])
                {
                    max1 = (int)automata[i11][0];
                }
            }

            Console.WriteLine(max1);

            Console.WriteLine("Melyik termék információit keresi: ");
            string keresett = Console.ReadLine();

            foreach (var termékadat in automata)
            {
                if (termékadat[4].ToString() == keresett)
                {
                    Console.WriteLine("A keresett termeék adatai: ");
                    foreach (var adat in termékadat)
                    {
                        Console.Write(adat + " ");
                    }
                    keresett = "done";
                }
            }
            
            if (keresett != "done")
            {
                Console.WriteLine("A keresett termék adatai nem elérhetőek!");
            }
            

            string filepath = @"csoki.txt";

            foreach (string sor in File.ReadAllLines(filepath))
            {
                Console.WriteLine(sor);
            }

            string mappaUtvonal = @"C:\Users\info\Documents\CShárp";
            string fajlNev = "elso.txt";
            string teljesUtvonal = Path.Combine(mappaUtvonal, fajlNev);

            Directory.CreateDirectory(mappaUtvonal);

            Console.WriteLine("Írj be sorokat (vége: vege)");
            using (StreamWriter sw = new StreamWriter(teljesUtvonal))
            {
                string sor;
                while ((sor = Console.ReadLine()) != "vege")
                {
                    sw.WriteLine(sor);
                }
            }

            Console.WriteLine("-------------");

            foreach (string sor in File.ReadAllLines(teljesUtvonal))
            {
                Console.WriteLine(sor);
            }
            */

            string mappaUtvonal = @"C:\premo\ketto\";
            string fajlNev = "autok.txt";
            string teljesUtvonal = Path.Combine(mappaUtvonal, fajlNev);
            List<string> autok = new List<string>();

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{i}. autó adatai: ");
                Console.Write("Név: "); string nev = Console.ReadLine();
                Console.Write("Ajtók: "); string ajtok = Console.ReadLine();
                Console.Write("LE: "); string loero = Console.ReadLine();
                autok.Add($"{nev} {ajtok} {loero}");
            }
            try
            {
                Directory.CreateDirectory(mappaUtvonal);
                File.WriteAllLines(teljesUtvonal, autok);
                Console.WriteLine("--- Mentés sikeres ---");

                Console.WriteLine("A fájl tartalma:");
                string[] beolvasottSorok = File.ReadAllLines(teljesUtvonal);
                foreach (string sor in beolvasottSorok)
                {
                    Console.WriteLine(sor);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hiba: " + e.Message);
            }
        }
    }
}