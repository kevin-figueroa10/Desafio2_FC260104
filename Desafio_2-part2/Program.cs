using System;

class SistemaNotas
{
    static void Main(string[] args)
    {
        Console.WriteLine("SISTEMA DE NOTAS");

        int n = SolicitarCantidadEstudiantes();

        string[] nombres = new string[n];
        double[] notas = new double[n];

        IngresarDatos(nombres, notas, n);

        double promedio = Promedio(notas, n);
        double max = Maximo(notas, n);
        double min = Minimo(notas, n);

        Console.WriteLine($"Promedio: {promedio}");
        Console.WriteLine($"Maximo: {max}");
        Console.WriteLine($"Minimo: {min}");
    }

    static int SolicitarCantidadEstudiantes()
    {
        int n;
        while (true)
        {
            Console.Write("Cantidad de estudiantes: ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                return n;

            Console.WriteLine("Dato invalido.");
        }
    }

    static void IngresarDatos(string[] nombres, double[] notas, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write("Nombre: ");
            nombres[i] = Console.ReadLine();

            while (true)
            {
                Console.Write("Nota: ");
                if (double.TryParse(Console.ReadLine(), out notas[i]) &&
                    notas[i] >= 0 && notas[i] <= 10)
                    break;

                Console.WriteLine("Nota invalida.");
            }
        }
    }

    static double Promedio(double[] notas, int n)
    {
        double suma = 0;
        for (int i = 0; i < n; i++)
            suma += notas[i];
        return suma / n;
    }

    static double Maximo(double[] notas, int n)
    {
        double max = notas[0];
        for (int i = 1; i < n; i++)
            if (notas[i] > max) max = notas[i];
        return max;
    }

    static double Minimo(double[] notas, int n)
    {
        double min = notas[0];
        for (int i = 1; i < n; i++)
            if (notas[i] < min) min = notas[i];
        return min;
    }
}