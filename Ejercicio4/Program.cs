using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    internal class Program
    {
        static Random gen = new Random();
        static int resp;

        static void Main(string[] args)//TODO repetir cADA JUEGO, nºs y alineacion en quini,
        {
            do
            {
                Console.WriteLine("1- Tirar dado\n2- Adivina un número\n3- Quiniela\n4- Jugar todo\n5-Salir");
                resp = 1;
                bool isok = true;
                while (isok)
                {
                    try
                    {
                        resp = Convert.ToInt32(Console.ReadLine());
                        if (resp > 0 && resp <= 5)
                        {
                            isok = false;
                        }
                        else
                        {
                            Console.WriteLine("Ha de estar dentro del rango(1-5)");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"Ha habido un error: {e.Message}");
                        Console.WriteLine("Vuelve a introducir el dato: ");
                    }

                }

                char rep;
                switch (resp)
                {
                    case 1:
                        do
                        {
                            Op1();

                            Console.WriteLine("Desea repetir?(s/n) ");
                            rep = Convert.ToChar(Console.ReadLine().ToLower());
                        } while (rep == 's');
                        if (resp == 4)
                        {
                            goto case 2;
                        }
                        break;
                    case 2:
                        do
                        {
                            Op2();
                            rep = Convert.ToChar(Console.ReadLine());
                        } while (rep == 's');
                        if (resp == 4)
                        {
                            goto case 3;
                        }
                        break;
                    case 3:
                        do
                        {
                            Op3();
                            rep = Convert.ToChar(Console.ReadLine());
                        } while (rep == 's');
                        break;
                    case 4:
                        goto case 1;
                    case 5:
                        break;
                }
            } while (resp != 5);

        }

        public static void Op1()
        {
            bool ok = true;
            int num = 1;
            int caras = 1;
            do
            {
                try
                {


                    System.Console.WriteLine("Cuántas caras quieres que tenga el dado? ");
                    caras = Convert.ToInt32(Console.ReadLine());
                    if (caras <= 0)
                    {
                        while (caras <= 0)
                        {
                            Console.WriteLine("ERROR: El numero no debe ser menor a 0");
                            System.Console.WriteLine("Cuántas caras quieres que tenga el dado?");
                            caras = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    System.Console.WriteLine("Qué número quieres acertar? ");
                    num = Convert.ToInt32(Console.ReadLine());
                    while (num > caras || num <= 0)
                    {
                        Console.WriteLine("ERROR: El numero no debe ser mayor al numero de caras o inferior a 0");
                        System.Console.WriteLine("Qué número quieres acertar? ");
                        num = Convert.ToInt32(Console.ReadLine());
                    }
                    ok = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("ERROR de formato");
                }
            } while (ok);
            int aciertos = 0;
            for (int i = 0; i < 10; i++)
            {
                int random = Aleat(caras);
                if (random == num)
                {
                    aciertos++;
                }
                Console.WriteLine("Tirada {0}: {1}", i + 1, random);
            }
            Console.WriteLine("Has acertado {0} numeros", aciertos);

        }
        public static int Aleat(int max)
        {
            return gen.Next(1, max + 1);
        }
        public static void Op2()
        {
            int aleat = Aleat(100);
            bool acertado = false;
            Console.WriteLine(aleat.ToString());
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Intentos: {0}\n\n", i);
                Console.WriteLine("Introduce un numero entre 1 y 100:");
                int num = 0;
                bool inval = true;
                while (inval)
                {
                    try
                    {
                        num = Convert.ToInt32(Console.ReadLine());
                        inval = false;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("No es un caracter válido!");
                    }
                }

                if (num < 1 || num > 100)
                {
                    Console.WriteLine("El número está fuera del rango");
                    if (i >= 0)
                    {
                        i--;
                    }
                }
                else
                {
                    if (num > aleat) Console.WriteLine("El número es menor");
                    if (num < aleat) Console.WriteLine("El número es mayor");
                    if (num == aleat)
                    {
                        i = 5;
                        acertado = true;
                        Console.WriteLine("Has acertado!", i);
                    }
                }
            }
            if (!acertado) Console.WriteLine("\nHas perdido! :(\nEl número era {0}", aleat);

        }
        public static void Op3()
        {
            for (int i = 0; i < 14; i++)
            {
                Console.WriteLine("Resultado {0,2}: {1}", i, Pond());
            }
        }

        public static char Pond()
        {
            int random = Aleat(100);
            switch (random)
            {
                case int x when x < 15:
                    return '2';
                case int x when x > 15 && x < 40:
                    return 'X';
                default:
                    return '1';
            }
        }

    }
}
