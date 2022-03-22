using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        //Función para calcular la suma de 2 números enteros
        static int Suma(int a, int b)
        {
            return a + b;
        }
        static int Resta(int a, int b)
        {
            return a - b;
        }
        static int Multiplicacion(int a, int b)
        {
            return a * b;
        }
        static int Division(int a, int b)
        {
            return a / b;
        }
        static void numerosPrimos()
        {
            Console.WriteLine("Los primeros diez números primos son: ");
            int cont = 0;
            for (int i = 2; i <= 30; i++)
            {  
                for (int j = 1; j <= i; j++)
                {  
                    if (i % j == 0)
                    {
                        cont = cont + 1;
                    }
                }
                if (cont <= 2)
                { 
                    Console.WriteLine(i);
                }  
                cont = 0;             
            }      
            
        }
        static double convertirTemperatura(int valor, string tipo)
        {
            if (tipo.Equals("ctof"))
            {
                return (valor * 9) / 5 + 32;
            }
            else
            {
                return 5 * (valor - 32) / 9;
            }
        }
        //Procedimiento que imprime la raíz cuadrada de los 10 primeros números
        static void Raiz()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("La raíz cuadrada de {0} es: {1}", i, Math.Sqrt(i));
            }
        }
        static void Main(string[] args)
        {
            Console.Title = "Procedimientos y funciones";
            string opcion;
            int a, b;
            do
            {
                Console.Clear();
                Console.WriteLine("[1] Suma de dos números");
                Console.WriteLine("[2] Resta de dos números");
                Console.WriteLine("[3] Multiplicación de dos números");
                Console.WriteLine("[4] División de dos números");
                Console.WriteLine("[5] Convertir de Celsius a Farenheit");
                Console.WriteLine("[6] Convertir de Frenheit a Celsius");
                Console.WriteLine("[7] Imprimir los diez primeros números primos");
                Console.WriteLine("[8] Imprimir la raíz cuadrada de los 10 primeros números enteros");
                Console.WriteLine("[0] Salir");
                Console.WriteLine("Ingrese una opción y presione ENTER");
                opcion = Console.ReadLine();

                switch (opcion)
                {
       
                    case "1":
                        Console.WriteLine("Ingrese el primer número");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La suma de {0} y {1} es {2}", a, b, Suma(a, b));
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.WriteLine("Ingrese el primer número");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La resta de {0} y {1} es {2}", a, b, Resta(a, b));
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Ingrese el primer número");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La multiplicacion de {0} y {1} es {2}", a, b, Multiplicacion(a, b));
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Ingrese el primer número");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La division de {0} y {1} es {2}", a, b, Division(a, b));
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("Ingrese la temperatura Celsius: ");
                        int c = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La conversión de {0}C° es: {1}F", c, convertirTemperatura(c, "ctof"));
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.WriteLine("Ingrese la temperatura Farenheit:");
                        int f = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La conversión de {0}F es: {1}C°", f, convertirTemperatura(f, "ftoc"));
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.WriteLine("Calculando...");
                        numerosPrimos();
                        Console.ReadKey();
                        break;
                    case "8":
                        Console.WriteLine("Calculando...");
                        Raiz();
                        Console.ReadKey();
                        break;
                }

            } while (!opcion.Equals("0"));

        }

    }
}
