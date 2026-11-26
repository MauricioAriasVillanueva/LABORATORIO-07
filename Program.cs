using System;

class Program
{
    // Los datos del mismo indice pertenecen a una entrega.
    static string[] codigos = { "N00001", "N00002", "N00003", "N00004", "N00005", "N00006", "N00007", "N00008" };
    static string[] archivos = { "informe_final.pdf", "laboratorio_v2.cs", "ejercicio_01.cs", "proyecto_final.zip", "resumen.docx", "practica_v2.pdf", "entrega_final.cs", "actividad_08.txt" };
    static int[] intentos = { 1, 2, 1, 3, 1, 2, 2, 1 };
    static int[] puntajes = { 18, 15, 12, 20, 14, 16, 17, 10 };
    static string[] observaciones = { "Entrega completa", "Segunda version", "Revisar validaciones", "Entrega corregida", "Falta un ejemplo", "Segunda version", "Entrega completa", "Requiere correcciones" };

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
                    MostrarEntregas();
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
    static void MostrarEntregas()
    {
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("         ENTREGAS REGISTRADAS");
        Console.WriteLine("========================================");

        for (int i = 0; i < codigos.Length; i++)
        {
            Console.WriteLine($"Entrega: {i + 1}");
            Console.WriteLine($"Codigo del estudiante: {codigos[i]}");
            Console.WriteLine($"Archivo: {archivos[i]}");
            Console.WriteLine($"Intentos de envio: {intentos[i]}");
            Console.WriteLine($"Puntaje: {puntajes[i]}");
            Console.WriteLine($"Observaciones: {observaciones[i]}");
            Console.WriteLine("----------------------------------------");
        }

        Console.WriteLine($"Total de entregas: {codigos.Length}");
    }
}
