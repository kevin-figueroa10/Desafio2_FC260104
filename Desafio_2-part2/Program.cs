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
}