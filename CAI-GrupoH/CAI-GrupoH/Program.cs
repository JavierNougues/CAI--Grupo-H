
/*
Prototipo:

Cliente: 1234
Contraseña: 1234
DNI: 40506070

/********************************************************************

Posible camino de Envio Nacional:
    - Tipo de paquete: 
        - Correspondencia.
        - Encomienda.
    - Tipo de envio: 
        - Normal.
        - Urgente.
    - Origen del paquete(Presentacion en Sucursal): 
        - Region: CABA
        - Provincia: Buenos Aires
        - Localidad: Belgrano
        - Sucursal: Belgrano

    - Origen del paquete(Retiro en Puerta):
        - Region: CABA
        - Provincia: Buenos Aires
        - Localidad: Belgrano

    - Entrega del paquete (Entrega en Sucursal):
        - Region: NOA
        - Provincia: Catamarca
        - Localidad: San Fernando del Valle de Catamarca
        - Sucursal: San Fernando del Valle de Catamarca

    - Entrega del paquete (Entrega en Puerta):
        - Region: NOA
        - Provincia: Catamarca
        - Localidad: San Fernando del Valle de Catamarca
   
/********************************************************************

Posible camino de Envio internacional:
    - Tipo de paquete: 
        - Correspondencia.
        - Encomienda.
    - Origen del paquete(Presentacion en Sucursal): 
        - Region: CABA
        - Provincia: Buenos Aires
        - Localidad: Belgrano
        - Sucursal: Belgrano

    - Origen del paquete(Retiro en Puerta):
        - Region: CABA
        - Provincia: Buenos Aires
        - Localidad: Belgrano

    - Destino del paquete: 
        - Region: Europa
        - Pais: España

/********************************************************************

Estado de Envio Nacional: N100

Estado de Envio Internacional: I100
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

            Console.Clear();

            // Menu Princiapl: Opciones
            while (true) { 
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
                            Console.Clear();
                            var numeroOrden = OrdenDeServicio.MostrarOrden();
                            //Console.WriteLine("Ingrese el Número de Orden de Servicio:");
                            //string numeroOrden = Console.ReadLine().ToLower();
                            //Validaciones.ValidarOrdenServicio(numeroOrden);
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
}
