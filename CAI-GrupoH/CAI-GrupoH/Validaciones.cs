using System;

namespace CAIGrupoH
{
    internal class Validaciones
    {
        static public string ValidarCliente(string mensaje)
        {
            Console.WriteLine(mensaje);
            string numeroCliente;
            do
            {
                // Cliente hardcodeado.
                numeroCliente = Console.ReadLine();
                if (numeroCliente != "123456789")
                {
                    Console.WriteLine("Cliente invalido.");
                    continue;
                }

            } while (true);
            return numeroCliente;
        }

        static public string ValidarContraseñaCliente(string mensaje)
        {
            Console.WriteLine(mensaje);
            string contraseñaCliente = "";
            do
            {
                // Cliente hardcodeado.
                contraseñaCliente = Console.ReadLine();
                if (contraseñaCliente != "123456789")
                {
                    Console.WriteLine("Contraseña invalida.");
                    continue;
                }
            } while (true);
            return contraseñaCliente;
        }

        static public string ValidarDNI(string mensaje)
        {
            Console.WriteLine(mensaje);
            string numeroDNI;
            do
            {
                // DNI hardcodeado.
                numeroDNI = Console.ReadLine();
                if (numeroDNI != "40506070")
                {
                    Console.WriteLine("DNI invalido.");
                    continue;
                }
            } while (true);
            return numeroDNI;
        }

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
                    Console.WriteLine("La opción seleccionada es inválida, seleccione nuevamente: ");
                    continue;
                }
                if (opcion < min)
                {
                    Console.WriteLine($"La opción seleccionada es inválida. No debe ser menor a: {min}");
                    continue;
                }
                if (opcion > max)
                {
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

        static public string ValidarIntIngresado(string mensaje, int min, int max)
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
            return intEntero.ToString();
        }
    }
}