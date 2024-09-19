#define FRASE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce la primera frase:\n");
            string f1 = Console.ReadLine();
            Console.WriteLine("\nIntroduce la segunda frase:\n");
            string f2 = Console.ReadLine();
            muestra(f1,f2);
        }

        public static void muestra(string f1, string f2)
        {
#if FRASE
            Console.WriteLine("\"{0}\" \\{1}\\",f1,f2);
#else
            Console.WriteLine("\n{0}\t{1}\n{0}\n{1}",f1,f2);
#endif
        }
    }
}
