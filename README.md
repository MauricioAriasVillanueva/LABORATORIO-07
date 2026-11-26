# Laboratorio 07 — Recursividad

Sistema de análisis de entregas digitales para un curso universitario.

**Autor:** Mauricio Arias Villanueva  
**Curso:** Fundamentos de Programación  
**Universidad:** Universidad Privada del Norte (UPN)  
**Lenguaje:** C# · .NET 10

## Estado

Código implementado. Compilación y pruebas manuales pendientes de realizar por el estudiante en Visual Studio Code.

## Funcionalidades

| Opción | Operación |
|---|---|
| 1 | Mostrar las ocho entregas simuladas con código, archivo, intentos, puntaje y observaciones. |
| 2 | Sumar los puntajes mediante recursividad. |
| 3 | Buscar un código mediante recursividad y mostrar la entrega encontrada. |
| 4 | Contar los archivos cuyo nombre contiene una palabra clave. |
| 5 | Calcular un factorial recursivo. |
| 6 | Comparar suma, búsqueda y conteo en sus versiones recursiva e iterativa. |
| 7 | Calcular una potencia recursiva. |
| 0 | Salir. |

La búsqueda y el conteo no distinguen mayúsculas de minúsculas. El conteo suma un archivo por coincidencia, aunque la palabra aparezca varias veces en su nombre.

## Estructura

| Archivo | Responsabilidad |
|---|---|
| `Program.cs` | Menú, datos simulados, validaciones y métodos recursivos e iterativos. |
| `Laboratorio07.csproj` | Configuración del proyecto de consola en .NET 10. |
| `.gitignore` | Exclusión de `bin/`, `obj/` y `.vs/`. |
| `README.md` | Descripción, ejecución y casos sugeridos para la verificación manual. |

Los cinco arreglos son paralelos: una misma posición representa una entrega completa. Tienen ocho elementos cada uno y los códigos son únicos.

## Descargar y ejecutar

Requisito: SDK de .NET 10. Visual Studio Code es el editor recomendado.

```bash
git clone https://github.com/MauricioAriasVillanueva/LABORATORIO-07.git
cd LABORATORIO-07
dotnet run --project Laboratorio07.csproj
```

Si ya tienes una copia del repositorio y no hay cambios locales pendientes:

```bash
git pull --ff-only origin main
dotnet run --project Laboratorio07.csproj
```

Para compilar sin ejecutar:

```bash
dotnet build Laboratorio07.csproj
```

Estos comandos son instrucciones para el estudiante; no representan verificaciones ya realizadas.

## Organización del código

- `MostrarMenu()` presenta las opciones; `Main()` controla el ciclo y las llamadas.
- `MostrarEntregas()` recorre los datos con un `for`; `MostrarEntrega()` muestra un registro.
- Los métodos `Consultar...` reciben y validan las entradas antes de llamar a los cálculos.
- `CompararSoluciones()` calcula las tres operaciones con las mismas entradas y muestra ambos resultados.
- Los métodos de cálculo reciben los arreglos como parámetros y devuelven resultados con `return`.

## Funciones recursivas

| Función | Caso base | Avance | Resultado |
|---|---|---|---|
| `SumarPuntajes` | Índice mayor o igual a la longitud: 0. | Índice + 1. | Puntaje actual más la suma restante. |
| `BuscarCodigo` | Fin del arreglo: -1; coincidencia: índice actual. | Índice + 1. | Primer índice encontrado o -1. |
| `ContarArchivos` | Fin del arreglo: 0. | Índice + 1. | Coincidencia actual más el conteo restante. |
| `Factorial` | Número igual a 0: 1. | Número - 1. | Número multiplicado por el factorial anterior. |
| `Potencia` | Exponente igual a 0: 1. | Exponente - 1. | Base multiplicada por la potencia anterior. |

Los recorridos comienzan en el índice 0. El caso base se comprueba antes de acceder al arreglo, por lo que los métodos de suma, búsqueda y conteo admiten arreglos vacíos.

## Validaciones y límites

- El menú acepta enteros de 0 a 7. Una entrada vacía, texto u opción fuera de rango muestra un mensaje.
- El código y la palabra clave no pueden quedar vacíos después de quitar espacios de los extremos.
- Factorial: enteros de 0 a 12. Se limita para mantener el resultado dentro del tipo `int`.
- Potencia: base entera entre -10 y 10 y exponente entero entre 0 y 9. Estos límites controlan el resultado y la profundidad de las llamadas.
- Para este ejercicio, toda potencia con exponente 0 devuelve 1, incluido `0^0`.
- Una entrada inválida vuelve al menú; no inicia el cálculo.
- Si se cierra la entrada estándar, el menú finaliza.

Los métodos recursivos de factorial y potencia suponen que sus argumentos ya fueron validados por los métodos de consulta. No deben llamarse directamente con argumentos fuera de sus contratos.

## Recursividad e iteración

| Operación | Versión recursiva | Versión iterativa |
|---|---|---|
| Sumatoria | `SumarPuntajes` | `SumarPuntajesIterativo` |
| Búsqueda | `BuscarCodigo` | `BuscarCodigoIterativo` |
| Conteo | `ContarArchivos` | `ContarArchivosIterativo` |

Ambas estrategias recorren hasta n elementos. La recursividad permite expresar el caso base y el avance de forma directa, pero puede mantener hasta n + 1 llamadas activas en estos recorridos. Los bucles usan memoria auxiliar constante y son preferibles para colecciones grandes.

Riesgos que deben revisarse al modificar el código: omitir el caso base, no avanzar hacia él, acceder al arreglo antes de comprobar su límite y permitir demasiadas llamadas. Los datos actuales son ocho entregas fijas; no se aceptan colecciones grandes desde el menú.

## Casos sugeridos para pruebas manuales

Los resultados esperados se deducen de los datos y las reglas. La columna de resultado obtenido queda pendiente hasta ejecutar cada caso en VS Code.

| Caso | Entrada o acción | Resultado esperado | Resultado obtenido |
|---|---|---|---|
| Listado | Opción 1. | Ocho entregas con sus cinco campos. | Pendiente |
| Sumatoria | Opción 2. | 122. | Pendiente |
| Código existente | Opción 3: `n00003`. | `ejercicio_01.cs`, puntaje 12. | Pendiente |
| Código inexistente | Opción 3: `N99999`. | Estudiante no encontrado. | Pendiente |
| Búsqueda vacía | Opción 3: solo espacios. | Mensaje de código vacío. | Pendiente |
| Conteo | Opción 4: `FINAL`. | 3 archivos. | Pendiente |
| Conteo | Opción 4: `v2`. | 2 archivos. | Pendiente |
| Palabra inexistente | Opción 4: `foto`. | 0 archivos. | Pendiente |
| Palabra vacía | Opción 4: solo espacios. | Mensaje de palabra clave vacía. | Pendiente |
| Caso base factorial | Opción 5: 0. | 1. | Pendiente |
| Caso recursivo factorial | Opción 5: 4. | 24. | Pendiente |
| Límite factorial | Opción 5: 12. | 479001600. | Pendiente |
| Factorial inválido | Opción 5: -1, 13 o texto, en ejecuciones separadas. | Rechazo antes de calcular. | Pendiente |
| Comparación | Opción 6: `N00003` y `final`. | Suma 122, índice 2 y conteo 3 en ambas versiones. | Pendiente |
| Comparación sin coincidencias | Opción 6: `N99999` y `foto`. | Suma 122, índice -1 y conteo 0 en ambas versiones. | Pendiente |
| Caso base potencia | Opción 7: base 3, exponente 0. | 1. | Pendiente |
| Caso recursivo potencia | Opción 7: base 2, exponente 5. | 32. | Pendiente |
| Potencia inválida | Base 11 o, con base válida, exponente -1 o 10. | Rechazo antes de calcular. | Pendiente |
| Menú inválido | Texto, entrada vacía o número 8. | Mensaje de opción no válida; continúa el menú. | Pendiente |
| Salida | Opción 0. | Mensaje de salida y fin del programa. | Pendiente |

Para verificar una colección vacía, en una copia local temporal cambia los cinco arreglos por arreglos vacíos del mismo tipo. Las opciones 1 y 2 deben mostrar total 0 y suma 0; la búsqueda debe indicar que no encuentra el código y el conteo debe devolver 0. No hace falta añadir una opción de borrado al sistema. Conserva los ocho registros en la versión de entrega.

## Alcance

Los datos son simulados y se mantienen en memoria. No se incluye registro interactivo, persistencia, interfaz gráfica ni bibliotecas externas. El informe, las capturas, las conclusiones y los resultados obtenidos de las pruebas se elaboran por separado.
