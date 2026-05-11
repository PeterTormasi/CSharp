using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace file_negy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<dynamic> lst = new List<dynamic>();

            foreach (string sor in File.ReadLines("eloadasok.txt", Encoding.UTF8))
            {

                string[] reszek = sor.Trim().Split("\t");

                var adatsor = new object[] {
                    reszek[0],
                    int.Parse(reszek[1]),
                    int.Parse(reszek[2]),
                    int.Parse(reszek[3]),
                    int.Parse(reszek[4]),
                    reszek[5],
                    reszek[6]
                };

                lst.Add(adatsor);
            }

            //Rendezés
            foreach (var sor in lst)
            {
                Console.WriteLine(string.Join(" ", (object[])sor));
            }
            lst = lst.OrderBy(x => ((object[])x)[2])
                .ThenBy(x => ((object[])x)[3])
                .ToList();
            Console.WriteLine(" ********************");
            Console.WriteLine(" ********************");
            foreach (var sor in lst)
            {
                Console.WriteLine(string.Join(" ", (object[])sor));
            }

            //2 feladat
            int minnap = (int)((object[])lst[0])[2];

            foreach (var i in lst)
            {
                var sor = (object[])i;
                if (minnap > (int)sor[2])
                {

                    minnap = (int)sor[2];
                }
            }
            Console.WriteLine(minnap);

            int maxnap = (int)((object[])lst[0])[2];

            foreach (var i in lst)
            {
                var sor = (object[])i;
                if (maxnap < (int)sor[2])
                {
                    maxnap = (int)sor[2];
                }
            }
            Console.WriteLine(maxnap);

            for (int i = minnap; i <= maxnap; i++)
            {
                Console.WriteLine($" november {i}.:");
                int sorszam = 1;

                foreach (var j in lst)
                {
                    var sor = (object[])j;

                    if ((int)sor[2] == i)

                    {
                        Console.WriteLine($"{sorszam}. {sor[0]} : {sor[5]}");
                        sorszam++;
                    }
                }
            }
            //3 feladat

            int hossz = 0;
            int nap_szamlalo = 1;

            for (int i = minnap; i <= maxnap; i++)
            {
                Console.Write($"{nap_szamlalo}.nap:");

                foreach (var j in lst)
                {

                    var sor = (object[])j;

                    if ((int)sor[2] == i)
                    {
                        hossz += (int)sor[4];
                    }
                }

                Console.WriteLine($"{hossz / 60}:{hossz % 60:D2}");
                hossz = 0;
                nap_szamlalo++;
            }

            //4 feladat

            int maxhossz = (int)((object[])lst[0])[4];

            foreach (var i in lst)
            {
                var sor = (object[])i;
                if ((int)sor[2] == 6 && (int)sor[4] > maxhossz)
                {
                    maxhossz = (int)sor[4];
                }
            }

            foreach (var i in lst)
            {
                var sor = (object[])i;
                if ((int)sor[2] == 6 && (int)sor[4] == maxhossz)
                {
                    Console.WriteLine($"{sor[0]} {sor[4]}");
                }
            }

        }
    }
}