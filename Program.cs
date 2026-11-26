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
            string entrada = Console.ReadLine() ?? "0";
            if (!int.TryParse(entrada, out opcion))
            {
                opcion = -1;
            }

            switch (opcion)
            {
                case 1:
                    MostrarEntregas();
                    break;
                case 2:
                    Console.WriteLine($"Sumatoria de puntajes: {SumarPuntajes(puntajes, 0)}");
                    break;
                case 3:
                    ConsultarEstudiante();
                    break;
                case 4:
                    ConsultarArchivos();
                    break;
                case 5:
                    ConsultarFactorial();
                    break;
                case 6:
                    CompararSoluciones();
                    break;
                case 7:
                    ConsultarPotencia();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opcion no valida. Ingrese un numero del 0 al 7.");
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
        Console.WriteLine("7. Calcular potencia");
        Console.WriteLine("0. Salir");
        Console.WriteLine("========================================");
    }

    static void MostrarEntregas()
    {
        Console.WriteLine("\n========= ENTREGAS REGISTRADAS =========");
        for (int i = 0; i < codigos.Length; i++)
        {
            MostrarEntrega(i);
        }
        Console.WriteLine($"Total de entregas: {codigos.Length}");
    }

    static void MostrarEntrega(int indice)
    {
        Console.WriteLine($"Codigo del estudiante: {codigos[indice]}");
        Console.WriteLine($"Archivo: {archivos[indice]}");
        Console.WriteLine($"Intentos de envio: {intentos[indice]}");
        Console.WriteLine($"Puntaje: {puntajes[indice]}");
        Console.WriteLine($"Observaciones: {observaciones[indice]}");
        Console.WriteLine("----------------------------------------");
    }

    static void ConsultarEstudiante()
    {
        Console.Write("Ingrese el codigo del estudiante: ");
        string codigo = (Console.ReadLine() ?? "").Trim();
        if (codigo.Length == 0)
        {
            Console.WriteLine("El codigo no puede estar vacio.");
            return;
        }

        int indice = BuscarCodigo(codigos, codigo, 0);
        if (indice == -1)
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
        else
        {
            Console.WriteLine("Entrega encontrada:");
            MostrarEntrega(indice);
        }
    }

    static void ConsultarArchivos()
    {
        Console.Write("Ingrese una palabra clave del archivo: ");
        string palabra = (Console.ReadLine() ?? "").Trim();
        if (palabra.Length == 0)
        {
            Console.WriteLine("La palabra clave no puede estar vacia.");
            return;
        }
        Console.WriteLine($"Archivos encontrados: {ContarArchivos(archivos, palabra, 0)}");
    }

    static void ConsultarFactorial()
    {
        Console.Write("Ingrese un entero del 0 al 12: ");
        if (!int.TryParse(Console.ReadLine(), out int numero) || numero < 0 || numero > 12)
        {
            Console.WriteLine("Dato invalido. El factorial admite enteros del 0 al 12.");
            return;
        }
        Console.WriteLine($"{numero}! = {Factorial(numero)}");
    }

    static void ConsultarPotencia()
    {
        Console.Write("Ingrese una base entera del -10 al 10: ");
        if (!int.TryParse(Console.ReadLine(), out int numero) || numero < -10 || numero > 10)
        {
            Console.WriteLine("Base invalida. Ingrese un entero del -10 al 10.");
            return;
        }
        Console.Write("Ingrese un exponente entero del 0 al 9: ");
        if (!int.TryParse(Console.ReadLine(), out int exponente) || exponente < 0 || exponente > 9)
        {
            Console.WriteLine("Exponente invalido. Ingrese un entero del 0 al 9.");
            return;
        }
        Console.WriteLine($"{numero} elevado a {exponente} = {Potencia(numero, exponente)}");
    }

    // El indice inicial es 0 y el caso base se comprueba antes de acceder al arreglo.
    static int SumarPuntajes(int[] valores, int indice)
    {
        if (indice >= valores.Length)
        {
            return 0;
        }
        return valores[indice] + SumarPuntajes(valores, indice + 1);
    }

    static int BuscarCodigo(string[] valores, string codigo, int indice)
    {
        if (indice >= valores.Length)
        {
            return -1;
        }
        if (valores[indice].Equals(codigo, StringComparison.OrdinalIgnoreCase))
        {
            return indice;
        }
        return BuscarCodigo(valores, codigo, indice + 1);
    }

    static int ContarArchivos(string[] nombres, string palabra, int indice)
    {
        if (indice >= nombres.Length)
        {
            return 0;
        }
        int coincidencia = 0;
        if (nombres[indice].IndexOf(palabra, StringComparison.OrdinalIgnoreCase) >= 0)
        {
            coincidencia = 1;
        }
        return coincidencia + ContarArchivos(nombres, palabra, indice + 1);
    }

    // La entrada se valida antes de llamar a estas funciones.
    static int Factorial(int numero)
    {
        if (numero == 0)
        {
            return 1;
        }
        return numero * Factorial(numero - 1);
    }

    static int Potencia(int numero, int exponente)
    {
        if (exponente == 0)
        {
            return 1;
        }
        return numero * Potencia(numero, exponente - 1);
    }

    static int SumarPuntajesIterativo(int[] valores)
    {
        int suma = 0;
        for (int i = 0; i < valores.Length; i++)
        {
            suma += valores[i];
        }
        return suma;
    }

    static int BuscarCodigoIterativo(string[] valores, string codigo)
    {
        for (int i = 0; i < valores.Length; i++)
        {
            if (valores[i].Equals(codigo, StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }
        return -1;
    }

    static int ContarArchivosIterativo(string[] nombres, string palabra)
    {
        int cantidad = 0;
        for (int i = 0; i < nombres.Length; i++)
        {
            if (nombres[i].IndexOf(palabra, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                cantidad++;
            }
        }
        return cantidad;
    }

    static void CompararSoluciones()
    {
        Console.Write("Ingrese el codigo que desea comparar: ");
        string codigo = (Console.ReadLine() ?? "").Trim();
        Console.Write("Ingrese la palabra clave que desea comparar: ");
        string palabra = (Console.ReadLine() ?? "").Trim();
        if (codigo.Length == 0 || palabra.Length == 0)
        {
            Console.WriteLine("El codigo y la palabra clave no pueden estar vacios.");
            return;
        }

        int sumaRecursiva = SumarPuntajes(puntajes, 0);
        int sumaIterativa = SumarPuntajesIterativo(puntajes);
        int busquedaRecursiva = BuscarCodigo(codigos, codigo, 0);
        int busquedaIterativa = BuscarCodigoIterativo(codigos, codigo);
        int conteoRecursivo = ContarArchivos(archivos, palabra, 0);
        int conteoIterativo = ContarArchivosIterativo(archivos, palabra);

        Console.WriteLine("\nOPERACION | RECURSIVA | ITERATIVA");
        Console.WriteLine($"Sumatoria | {sumaRecursiva} | {sumaIterativa}");
        Console.WriteLine($"Busqueda (indice) | {busquedaRecursiva} | {busquedaIterativa}");
        Console.WriteLine($"Conteo de archivos | {conteoRecursivo} | {conteoIterativo}");
        Console.WriteLine("En busqueda, -1 significa no encontrado; los indices comienzan en 0.");

        if (sumaRecursiva == sumaIterativa &&
            busquedaRecursiva == busquedaIterativa &&
            conteoRecursivo == conteoIterativo)
        {
            Console.WriteLine("Los resultados de ambas versiones coinciden.");
        }
        else
        {
            Console.WriteLine("Los resultados difieren. Revise las funciones.");
        }

        Console.WriteLine("La recursion expresa el caso base y el avance en cada llamada.");
        Console.WriteLine("La iteracion evita acumular llamadas y conviene para colecciones grandes.");
    }
}
