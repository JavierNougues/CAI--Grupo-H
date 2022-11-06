
/*
Prototipo:

Prototipo:
Cliente: 1234
Contraseña: 1234
DNI: 40506070

Opciones de Envio:
    - Tipo de paquete: 
	- Correspondencia.
	- Encomienda.
    - Tipo de envio: 
	- Normal.
	- Urgente.

Posible camino de Envio Nacional:
    - Origen del paquete(Presentacion en Sucursal): 
        - Provincia: Buenos Aires
        - Localidad: Del Viso
        - Sucursal: Sucursal A
    - Origen del paquete(En puerta): 
        - Provincia: Buenos Aires
        - Localidad: Del Viso


    - Entrega del paquete(En Sucursal): 
        - Provincia: Catamarca
        - Localidad: San Fernando del Valle de Catamarca
        - Sucursal: Sucursal A
    - Entrega del paquete(En Puerta):
        - Provincia: Catamarca
        - Localidad: San Fernando del Valle de Catamarca

   
Posible camino de Envio internacional:
    - Origen del paquete(Presentacion en Sucursal): 
        - Provincia: Buenos Aires
        - Localidad: Del Viso
        - Sucursal: Sucursal A
    - Origen del paquete(En puerta): 
        - Provincia: Buenos Aires
        - Localidad: Del Viso

    - Destino del paquete: 
        - Region: Europa
	- Pais: España


Trackeo de Envio Naciona: N100
Trackeo de Envio Internacional: I100
*/

using CAI_GrupoH;

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
                            Console.WriteLine("Ingrese el Número de Orden de Servicio:");
                            string numeroOrden = Console.ReadLine();
                            Validaciones.ValidarOrdenServicio(numeroOrden);
                            break;
                        }
                    case 4:
                        {
                            EstadoCuenta.EstadodeCuenta();
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
