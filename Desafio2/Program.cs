using System;

class Ahorcado
{
    // Banco de 10 palabras almacenado en un vector unidimensional
    static string[] bancoPalabras = {
        "computadora", "algoritmo", "programacion", "variable",
        "funcion", "lenguaje", "compilador", "estructura",
        "iteracion", "condicional"
    };

    // Dibujos del ahorcado segun los intentos fallidos (0 a 6)
    static string[] dibujosAhorcado = {
        "  +---+\n  |   |\n      |\n      |\n      |\n      |\n=========",
        "  +---+\n  |   |\n  O   |\n      |\n      |\n      |\n=========",
        "  +---+\n  |   |\n  O   |\n  |   |\n      |\n      |\n=========",
        "  +---+\n  |   |\n  O   |\n /|   |\n      |\n      |\n=========",
        "  +---+\n  |   |\n  O   |\n /|\\  |\n      |\n      |\n=========",
        "  +---+\n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n=========",
        "  +---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n========="
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
                case "1": JugarAhorcado(); break;
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

    static void JugarAhorcado()
    {
        // Seleccion aleatoria de una palabra del vector
        Random random = new Random();
        string palabraSecreta = bancoPalabras[random.Next(0, bancoPalabras.Length)];

        char[] letrasUsadas = new char[26];
        int totalLetrasUsadas = 0;

        // Vector que guarda el estado actual de la palabra (guiones bajos o letras)
        char[] letrasAdivinadas = new char[palabraSecreta.Length];
        for (int i = 0; i < letrasAdivinadas.Length; i++)
            letrasAdivinadas[i] = '_';

        int intentosFallidos = 0;
        int maxIntentos = 6;
        bool gano = false;

        while (intentosFallidos < maxIntentos && !gano)
        {
            Console.Clear();
            MostrarEstadoJuego(intentosFallidos, letrasAdivinadas, letrasUsadas, totalLetrasUsadas, maxIntentos);

            Console.Write("\nIngrese una letra: ");
            string entrada = Console.ReadLine().ToLower().Trim();

            // Validar que sea un solo caracter y una letra valida
            if (entrada.Length != 1 || !char.IsLetter(entrada[0]))
            {
                Console.WriteLine("Solo se acepta una letra valida.");
                Console.ReadLine();
                continue;
            }

            char letra = entrada[0];

            // Validar que la letra no haya sido usada antes
            if (LetraYaUsada(letrasUsadas, totalLetrasUsadas, letra))
            {
                Console.WriteLine("Esa letra ya fue ingresada.");
                Console.ReadLine();
                continue;
            }

            letrasUsadas[totalLetrasUsadas] = letra;
            totalLetrasUsadas++;

            // Verificar si la letra esta en la palabra y actualizar vector
            bool letraCorrecta = false;
            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                if (palabraSecreta[i] == letra)
                {
                    letrasAdivinadas[i] = letra;
                    letraCorrecta = true;
                }
            }

            if (!letraCorrecta)
            {
                intentosFallidos++;
                Console.WriteLine($"La letra '{letra}' no esta en la palabra. Intentos fallidos: {intentosFallidos}/{maxIntentos}");
                Console.ReadLine();
            }

            gano = PalabraCompleta(letrasAdivinadas);
        }

        Console.Clear();
        MostrarResultadoFinal(gano, intentosFallidos, maxIntentos, letrasAdivinadas, palabraSecreta);

        Console.Write("\nDesea jugar de nuevo? (s/n): ");
        if (Console.ReadLine().ToLower().Trim() == "s")
            JugarAhorcado();
    }

    static void MostrarEstadoJuego(int intentosFallidos, char[] letrasAdivinadas,
                                    char[] letrasUsadas, int totalUsadas, int maxIntentos)
    {
        Console.WriteLine("=============================");
        Console.WriteLine("      JUEGO DEL AHORCADO     ");
        Console.WriteLine("=============================");
        Console.WriteLine(dibujosAhorcado[intentosFallidos].Replace("\\n", "\n"));
        Console.WriteLine();

        Console.Write("Palabra: ");
        for (int i = 0; i < letrasAdivinadas.Length; i++)
            Console.Write(letrasAdivinadas[i] + " ");

        Console.WriteLine($"\n\nIntentos fallidos: {intentosFallidos}/{maxIntentos}");

        Console.Write("Letras usadas: ");
        for (int i = 0; i < totalUsadas; i++)
            Console.Write(letrasUsadas[i] + " ");

        Console.WriteLine("\n=============================");
    }

    static void MostrarResultadoFinal(bool gano, int intentosFallidos, int maxIntentos,
                                       char[] letrasAdivinadas, string palabraSecreta)
    {
        Console.WriteLine("=============================");
        if (gano)
        {
            Console.WriteLine("   *** FELICIDADES, GANASTE! ***");
            Console.Write("Palabra: ");
            for (int i = 0; i < letrasAdivinadas.Length; i++)
                Console.Write(letrasAdivinadas[i] + " ");
        }
        else
        {
            Console.WriteLine("   *** PERDISTE! ***");
            Console.WriteLine(dibujosAhorcado[maxIntentos].Replace("\\n", "\n"));
            Console.WriteLine("La palabra era: " + palabraSecreta);
        }
        Console.WriteLine("\n=============================");
    }

    // Recorre el vector de letras usadas para verificar si ya fue ingresada
    static bool LetraYaUsada(char[] letrasUsadas, int totalUsadas, char letra)
    {
        for (int i = 0; i < totalUsadas; i++)
            if (letrasUsadas[i] == letra) return true;
        return false;
    }

    // Verifica si ya no quedan guiones bajos en el vector de letras adivinadas
    static bool PalabraCompleta(char[] letrasAdivinadas)
    {
        for (int i = 0; i < letrasAdivinadas.Length; i++)
            if (letrasAdivinadas[i] == '_') return false;
        return true;
    }
}