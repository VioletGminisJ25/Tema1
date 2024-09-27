#define Switch
using System;

namespace Ejercicio6
{
    internal class Program
    {
        static Random gen = new Random();

        static void Main(string[] args)
        {
#if Switch
            int fact = 4;
            if (Factorial(ref fact)) Console.WriteLine($"Factorial: {fact}");
#else
            Asterisk(25);
#endif
        }
        public static bool Factorial(ref int n1)
        {
            if (n1 < 0 || n1 > 10)
            {
                return false;
            }
            else
            {
                for (int i = n1 - 1; i >= 1; i--)
                {
                    n1 = n1 * i;
                }
                return true;
            }
        }
        public static void Asterisk(int asteriscos = 10)
        {
            for (int i = 0; i < asteriscos; i++)
            {
                Console.SetCursorPosition(Rand(20), Rand(10));
                Console.WriteLine("*");
            }
            Console.SetCursorPosition(0, 11);

        }

        public static int Rand(int max)
        {
            return gen.Next( max )+1;
        }
    }
}
