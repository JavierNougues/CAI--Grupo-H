
/*
Prototipo:
Posible camino de Envio Nacional:
    - Tipo de paquete: correspondencia.
    - Tipo de envio: normal.
    - Origen del paquete: en la sucursal.
    - Destino del paquete: en la sucursal.
*/

namespace CAIGrupoH
    {
    class Program
    {
        static void Main(string[] strings)
        {
            //Ingreso de Cliente + Contraseña
            string numeroCliente = Validaciones.ValidarCliente("Bienvenido! \n Ingrese su número de cliente: ");
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
                        //var realizarEnvioInternacional = EnvioInternacional.Ingresar();
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
                        Console.WriteLine("Ha salido del programa");
                        System.Environment.Exit(0);
                        break;

                    }
            }
        }

    }
}
