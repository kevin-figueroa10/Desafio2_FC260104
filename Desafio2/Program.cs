using System;
class Ahorcado
{
    static string[] bancoPalabras = {
        "computadora", "algoritmo", "programacion", "variable",
        "funcion", "lenguaje", "compilador", "estructura",
        "iteracion", "condicional"
    };

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            MostrarMenuPrincipal();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Juego en construccion...");
                    Console.ReadLine();
                    break;
                case "2": MostrarInstrucciones(); break;
                case "3":
                    salir = true;
                    Console.WriteLine("\nHasta luego!");
                    break;
                default:
                    Console.WriteLine("\nOpcion no valida. Presione Enter...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void MostrarMenuPrincipal()
    {
        Console.WriteLine("=============================");
        Console.WriteLine("      JUEGO DEL AHORCADO     ");
        Console.WriteLine("=============================");
        Console.WriteLine("1. Jugar");
        Console.WriteLine("2. Ver instrucciones");
        Console.WriteLine("3. Salir");
        Console.WriteLine("=============================");
        Console.Write("Seleccione una opcion: ");
    }

    static void MostrarInstrucciones()
    {
        Console.Clear();
        Console.WriteLine("=============================");
        Console.WriteLine("        INSTRUCCIONES        ");
        Console.WriteLine("=============================");
        Console.WriteLine("1. Se selecciona una palabra aleatoria.");
        Console.WriteLine("2. Adivina la palabra letra por letra.");
        Console.WriteLine("3. Maximo 6 intentos fallidos.");
        Console.WriteLine("4. Si adivinas todas las letras, ganas.");
        Console.WriteLine("=============================");
        Console.WriteLine("\nPresione Enter para regresar...");
        Console.ReadLine();
    }
}