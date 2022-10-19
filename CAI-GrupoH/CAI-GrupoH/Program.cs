
/*
Prototipo:

Cliente: 123456789
Contraseña: 123456789
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
            //Ingreso de Cliente + Contraseña
            string numeroCliente = Validaciones.ValidarCliente("Bienvenido! \n Ingrese su número de cliente: ");
            string contraseñaCliente = Validaciones.ValidarContraseñaCliente("Ingrese contraseña: ");
            string dniAutorizado = Validaciones.ValidarDNI("Ingrese DNI: ");


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
                        //var realizarConsultaEnvio = OrdenDeServicio.MostrarOrden();
                        //Console.ReadLine();
                        break;
                    }
                case 4:
                    {
                        //var realizarEstadoDeCuenta = EstadoDeCuenta.ConsultarEstado(numeroCliente);
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
