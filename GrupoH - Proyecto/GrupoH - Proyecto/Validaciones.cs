using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CAIGrupoH
{
    internal class Validaciones
    {
        static public int ValidarMenuPrincipal(string mensaje, string mensajeDesc, int min, int max)
        {
            int opcion;
            do
            {
                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeDesc);
                var ingreso = Console.ReadLine();
                bool ingresoCorrecto = int.TryParse(ingreso, out opcion);
                if (!ingresoCorrecto)
                {
                    Console.Clear();
                    Console.WriteLine("La opción seleccionada es inválida, seleccione nuevamente: ");
                    continue;
                }
                if (opcion < min)
                {
                    Console.Clear();
                    Console.WriteLine($"La opción seleccionada es inválida. No debe ser menor a: {min}");
                    continue;
                }
                if (opcion > max)
                {
                    Console.Clear();
                    Console.WriteLine($"La opción seleccionada es inválida. No debe ser mayor a: {max}");
                    continue;
                }
                break;
            } while (true);
            return opcion;
        }

        static public string ValidarStringIngresado(string mensaje, string mensajeDesc)
        {

            string stringIngresado = "";
            do
            {
                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeDesc);
                stringIngresado = Console.ReadLine();
                bool entero;
                if (stringIngresado.Length <= 0)
                {
                    Console.WriteLine("Por favor ingrese una cadena de texto.");
                    continue;
                }
                if (entero = int.TryParse(stringIngresado, out int intEntero))
                {
                    if (entero == true)
                    {
                        Console.WriteLine("Por favor ingrese una cedena de texto.");
                        continue;
                    }
                }
                break;
            } while (true);
            return stringIngresado;
        }

        static public int ValidarIntIngresado(string mensaje, int min, long max)
        {

            int intEntero;
            do
            {
                Console.WriteLine(mensaje);
                var intIngresado = Console.ReadLine();
                bool entero = int.TryParse(intIngresado, out intEntero);
                if (entero == false)
                {
                    Console.WriteLine($"Por favor ingrese una altura válida: entre {min} y {max} dígitos.");
                    continue;
                }
                if (intEntero.ToString().Length < min)
                {
                    Console.WriteLine($"Por favor ingrese una altura válida: entre {min} y {max} dígitos.");
                    continue;
                }
                if (intEntero.ToString().Length > max)
                {
                    Console.WriteLine($"Por favor ingrese una altura válida: entre {min} y {max} dígitos.");
                    continue;
                }
                break;
            } while (true);
            return intEntero;
        }
    }
}