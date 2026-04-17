using System;

class SistemaNotas
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("========================================");
        Console.WriteLine("   SISTEMA DE REGISTRO DE NOTAS        ");
        Console.WriteLine("========================================");

        int n = SolicitarCantidadEstudiantes();

        // Vectores paralelos
        string[] nombres = new string[n];
        double[] notas = new double[n];

        IngresarDatosEstudiantes(nombres, notas, n);

        double promedio = CalcularPromedio(notas, n);
        double notaMaxima = CalcularMaximo(notas, n);
        double notaMinima = CalcularMinimo(notas, n);

        MostrarReporteIndividual(nombres, notas, n);
        MostrarResumenFinal(promedio, notaMaxima, notaMinima, notas, n);
    }

    static int SolicitarCantidadEstudiantes()
    {
        int n = 0;
        bool valido = false;

        while (!valido)
        {
            Console.Write("\nIngrese la cantidad de estudiantes: ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                valido = true;
            else
                Console.WriteLine("Cantidad invalida. Ingrese un numero entero mayor a 0.");
        }

        return n;
    }

    static void IngresarDatosEstudiantes(string[] nombres, double[] notas, int n)
    {
        Console.WriteLine("\n--- Ingreso de Datos ---");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEstudiante #{i + 1}:");

            Console.Write("  Nombre: ");
            nombres[i] = Console.ReadLine().Trim();

            double nota = 0;
            bool notaValida = false;

            while (!notaValida)
            {
                Console.Write("  Nota (0.0 - 10.0): ");
                if (double.TryParse(Console.ReadLine(), out nota) && nota >= 0.0 && nota <= 10.0)
                    notaValida = true;
                else
                    Console.WriteLine("  Nota invalida. Debe estar entre 0.0 y 10.0.");
            }

            notas[i] = nota;
        }
    }

    static double CalcularPromedio(double[] notas, int n)
    {
        double suma = 0;
        for (int i = 0; i < n; i++)
            suma += notas[i];
        return suma / n;
    }

    static double CalcularMaximo(double[] notas, int n)
    {
        double maximo = notas[0];
        for (int i = 1; i < n; i++)
            if (notas[i] > maximo) maximo = notas[i];
        return maximo;
    }

    static double CalcularMinimo(double[] notas, int n)
    {
        double minimo = notas[0];
        for (int i = 1; i < n; i++)
            if (notas[i] < minimo) minimo = notas[i];
        return minimo;
    }

    // Conversión de nota a letra
    static char ConvertirALetra(double nota)
    {
        if (nota >= 9.0) return 'A';
        else if (nota >= 8.0) return 'B';
        else if (nota >= 7.0) return 'C';
        else if (nota >= 6.0) return 'D';
        else return 'F';
    }

    static string ObtenerEstado(double nota)
    {
        return nota >= 6.0 ? "Aprobado" : "Reprobado";
    }

    static void MostrarReporteIndividual(string[] nombres, double[] notas, int n)
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine("         REPORTE INDIVIDUAL             ");
        Console.WriteLine("========================================");

        Console.WriteLine($"{"#",-4} {"Nombre",-20} {"Nota",-8} {"Letra",-8} {"Estado",-12}");
        Console.WriteLine(new string('-', 56));

        for (int i = 0; i < n; i++)
        {
            char letra = ConvertirALetra(notas[i]);
            string estado = ObtenerEstado(notas[i]);

            Console.WriteLine($"{i + 1,-4} {nombres[i],-20} {notas[i],-8:F1} {letra,-8} {estado,-12}");
        }

        Console.WriteLine(new string('-', 56));
    }

    static void MostrarResumenFinal(double promedio, double notaMaxima, double notaMinima,
                                    double[] notas, int n)
    {
        int totalAprobados = 0, totalReprobados = 0;

        for (int i = 0; i < n; i++)
        {
            if (notas[i] >= 6.0) totalAprobados++;
            else totalReprobados++;
        }

        Console.WriteLine("\n========================================");
        Console.WriteLine("           RESUMEN DEL GRUPO            ");
        Console.WriteLine("========================================");

        Console.WriteLine($"  Total de estudiantes : {n}");
        Console.WriteLine($"  Promedio general     : {promedio:F2}");
        Console.WriteLine($"  Nota maxima          : {notaMaxima:F1}");
        Console.WriteLine($"  Nota minima          : {notaMinima:F1}");
        Console.WriteLine($"  Total aprobados      : {totalAprobados}");
        Console.WriteLine($"  Total reprobados     : {totalReprobados}");

        Console.WriteLine("========================================");
        Console.WriteLine("\nPresione Enter para salir...");
        Console.ReadLine();
    }
}