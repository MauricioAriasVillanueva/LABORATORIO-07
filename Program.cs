using System;

class Program
{
    static void Main()
    {
        int opcion;

        do
        {
            MostrarMenu();
            Console.Write("Seleccione una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = -1;
            }

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Mostrar entregas registradas: operacion pendiente.");
                    break;
                case 2:
                    Console.WriteLine("Calcular sumatoria de puntajes: operacion pendiente.");
                    break;
                case 3:
                    Console.WriteLine("Buscar estudiante: operacion pendiente.");
                    break;
                case 4:
                    Console.WriteLine("Contar archivos por palabra clave: operacion pendiente.");
                    break;
                case 5:
                    Console.WriteLine("Calcular factorial: operacion pendiente.");
                    break;
                case 6:
                    Console.WriteLine("Comparar recursividad e iteracion: operacion pendiente.");
                    break;
                case 0:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opcion no valida. Ingrese un numero del 0 al 6.");
                    break;
            }
        } while (opcion != 0);
    }

    static void MostrarMenu()
    {
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("    SISTEMA DE ENTREGAS DIGITALES");
        Console.WriteLine("         LABORATORIO NRO. 7");
        Console.WriteLine("========================================");
        Console.WriteLine("1. Mostrar entregas registradas");
        Console.WriteLine("2. Calcular sumatoria de puntajes");
        Console.WriteLine("3. Buscar estudiante");
        Console.WriteLine("4. Contar archivos por palabra clave");
        Console.WriteLine("5. Calcular factorial");
        Console.WriteLine("6. Comparar recursividad e iteracion");
        Console.WriteLine("0. Salir");
        Console.WriteLine("========================================");
    }
}
