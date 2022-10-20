using System;

namespace CAIGrupoH
{
    internal class Validaciones
    {
        static public int ValidarCliente(int cliente)
        {
            do
            {
                if (cliente != 1234)
                {
                    Console.WriteLine("Cliente invalido. Intente nuevamente: ");
                    cliente = int.Parse(Console.ReadLine());
                    continue;
                }
                Console.Clear();
                break;
            } while (true);
            return cliente;
        }

        static public string ValidarContraseñaCliente(string contraseña)
        {
            do
            {
                // Cliente hardcodeado.
                if (contraseña != "1234")
                {
                    Console.WriteLine("Contraseña invalida. Intente nuevamente:");
                    contraseña = Console.ReadLine();
                    continue;
                }
                Console.Clear();
                break;
            } while (true);
            return contraseña;
        }

        static public int ValidarDNI(int dni)
        {
            do
            {
                // DNI hardcodeado.
                if (dni != 40506070)
                {
                    Console.WriteLine("DNI invalido. Intente nuevamente: ");
                    dni = int.Parse(Console.ReadLine());
                    continue;
                }
                Console.Clear();
                break;
            } while (true);
            return dni;
        }

        public static string ValidarOrdenServicio(string numeroOrden)
        {
            do
            {
                if (numeroOrden != "N100" && numeroOrden != "I100")
                {
                    Console.WriteLine("Orden de Servicio inválida. Intente nuevamente: ");
                    numeroOrden = Console.ReadLine();
                    continue;
                }
                else
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("El estado de su Orden de Servicio es: 'Iniciado'. ");
                    Console.WriteLine("Gracias por su consulta!.\n");
                    Console.WriteLine("Ingrese cualquier tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
                break;
            } while (true);
            return numeroOrden;
        }

        public static string ValidarEstadoCuenta(int numeroCliente)
        {
            Console.Clear();
            Console.WriteLine("Actualmente posee un saldo negativo: adeuda $1000.\n");
            Console.WriteLine("Ingrese cualquier tecla para continuar");
            Console.ReadKey();
            Console.Clear();
            return numeroCliente.ToString();
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



        static public int ValidarIntIngresado(string mensaje, int min, int max)
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