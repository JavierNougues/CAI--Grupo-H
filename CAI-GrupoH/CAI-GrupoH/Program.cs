
/*
Prototipo:

Cliente: 1234
Contraseña: 1234
DNI: 40506070


Posible camino de Envio Nacional:
    - Tipo de paquete: correspondencia.
    - Tipo de envio: normal.
    - Origen del paquete: 
        - Region: CABA
        - Provincia: Buenos Aires
        - Localidad: Belgrano
        - Sucursal: Belgrano

    - Origen del paquete: 
        - Region: NOA
        - Provincia: Catamarca
        - Localidad: San Fernando del Valle de Catamarca
        - Sucursal: San Fernando del Valle de Catamarca


Posible camino de Envio internacional:
    - Tipo de paquete: correspondencia.
    - Origen del paquete: 
        - Region: CABA
        - Provincia: Buenos Aires
        - Localidad: Belgrano
        - Sucursal: Belgrano
    - Destino del paquete: 
        - Region: Europa
        - Pais: España
*/

namespace CAIGrupoH
{
    class Program
    {
        static void Main(string[] strings)
        {
            // Ingreso de Cliente + Contraseña
            int numeroCliente = Validaciones.ValidarIntIngresado("Bienvenido! \nIngrese su número de cliente: ", 0, 12345);
            Validaciones.ValidarCliente(numeroCliente);

            Console.WriteLine("Ingrese contraseña: ");
            string contraseñaCliente = Console.ReadLine();
            Validaciones.ValidarContraseñaCliente(contraseñaCliente);

            // Ingreso DNI empleado
            int dniAutorizado = Validaciones.ValidarIntIngresado("Ingrese DNI: ", 0, 60606060);
            Validaciones.ValidarDNI(dniAutorizado);

            // Menu Princiapl: Opciones
            int menuPrincipal = Validaciones.ValidarMenuPrincipal("Seleccione la acción a realizar: ", "1. Envío Nacional \n2. Envío Internacional \n3. Consultar Estado de su Envío \n4. Consultar Estado de su Cuenta Corriente \n0. Salir", 0, 4);
            switch (menuPrincipal)
            {
                case 1:
                    {
                        var realizarEnvioNacional = EnvioNacional.Ingresar();
                        break;
                    }
                case 2:
                    {
                        var realizarEnvioInternacional = EnvioInternacional.Ingresar();
                        break;
                    }
                case 3:
                    {
                        int numeroOrden = Validaciones.ValidarIntIngresado("Ingrese el Número de Orden de Servicio:", 1, 500);
                        Validaciones.ValidarOrdenServicio(numeroOrden);
                        break;
                    }
                case 4:
                    {
                        Validaciones.ValidarEstadoCuenta(numeroCliente);
                        break;
                    }
                case 0:
                    {
                        Console.WriteLine("Ha salido exitosamente del sistema.");
                        System.Environment.Exit(0);
                        break;

                    }
            }
        }

    }
}
