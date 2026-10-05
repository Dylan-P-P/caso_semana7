using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso_semana7
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas= new double[max];
        static int contador = 0;
        static public void Titulo()
        {
            Console.WriteLine("*************************************************");
            Console.WriteLine("Sistema de Notas");
            Console.WriteLine("*************************************************");
        }

        static public void Registrar_estudiante()
        {
            Console.WriteLine("Registro de estudiante nuevo: ");
            if (contador >= max)
            {
                Console.WriteLine("Llegamos a la capacidad máxima");
                return;
            }
            Console.WriteLine("Ingresar nombres: ");
            string nombre = Console.ReadLine();
            double nota;
            while (true)
            {
                Console.WriteLine("Ingresar nota: ");
                nota = double.Parse(Console.ReadLine());
                if (nota >= 0 && nota <= 20)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: La nota debe ser [0 - 20]");
                }
            }
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
        }

        static public void mostrar()
        {
            Console.WriteLine("*****Listado de Estudiantes*****");
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostrar");
                return;
            }
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"{i + 1}.- {nombres[i]} - Nota: {notas[i]}");
            }
            
        }

        static public void buscar_estudiante()
        {
            Console.WriteLine("*****Buscar Estudiante*****");
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostrar");
                return;
            }
            Console.WriteLine("Ingresar nombre a buscar: ");
            string nombre = Console.ReadLine();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Estudiante encontrado: {nombres[i]} - Nota: {notas[i]}");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Estudiante no encontrado");
            }
        }

        static public void modificar_nota()
        {
            Console.WriteLine("*****Modificar Nota*****");
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostrar");
                return;
            }
            Console.WriteLine("Ingresar nombre a buscar: ");
            string nombre = Console.ReadLine();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Estudiante encontrado: {nombres[i]} - Nota: {notas[i]}");
                    double nuevaNota;
                    while (true)
                    {
                        Console.WriteLine("Ingresar nueva nota: ");
                        nuevaNota = double.Parse(Console.ReadLine());
                        if (nuevaNota >= 0 && nuevaNota <= 20)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error: La nota debe ser [0 - 20]");
                        }
                    }
                    notas[i] = nuevaNota;
                    Console.WriteLine($"Nota modificada: {nombres[i]} - Nueva Nota: {notas[i]}");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Estudiante no encontrado");
            }
        }

        static public void burbuja()
        {
            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - i - 1; j++)
                {
                    if (notas[j] < notas[j + 1])
                    {
                        // Intercambiar notas
                        double tempNota = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = tempNota;
                        // Intercambiar nombres correspondientes
                        string tempNombre = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = tempNombre;
                    }
                }
            }
        }

        static public void mostrar_ordenado()
        {
            Console.WriteLine("*****Listado de Estudiantes Ordenado*****");
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostrar");
                return;
            }
            // Crear una lista de tuplas para ordenar por nota
            var estudiantes = new List<(string nombre, double nota)>();
            for (int i = 0; i < contador; i++)
            {
                estudiantes.Add((nombres[i], notas[i]));
            }
            // Ordenar la lista por nota descendente
            var estudiantesOrdenados = estudiantes.OrderByDescending(e => e.nota).ToList();
            for (int i = 0; i < estudiantesOrdenados.Count; i++)
            {
                Console.WriteLine($"{i + 1}.- {estudiantesOrdenados[i].nombre} - Nota: {estudiantesOrdenados[i].nota}");
            }
        }
        static void Main(string[] args)
        {
            Titulo();
            int opc = 0;
            while (opc != 6)
            {
                Console.WriteLine("******MENU PRINCIPAL******");
                Console.WriteLine("[1] Registrar Estudiante");
                Console.WriteLine("[2] Buscar Estudiante");
                Console.WriteLine("[3] Modificar Nota");
                Console.WriteLine("[4] Mostrar Lista sin Ordenar");
                Console.WriteLine("[5] Mostrar reporte Ordenado");
                Console.WriteLine("[6] Salir");
                Console.Write("Ingresar opción: ");
                opc = int.Parse(Console.ReadLine());
                if (opc < 1 || opc > 6)
                {
                    Console.WriteLine("Error: opción fuera de rango [1-6]");
                    continue;
                }
                switch (opc)
                {
                    case 1:
                        Registrar_estudiante(); break;
                    case 2:
                        buscar_estudiante();
                        break;
                    case 3:
                        modificar_nota();
                        break;
                    case 4:
                        mostrar(); break;
                    case 5:
                        mostrar_ordenado();
                        break;
                    case 6:
                        Console.WriteLine("Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("Opción Incorrecta");
                        break;

                }
            }
        }
    }
}
