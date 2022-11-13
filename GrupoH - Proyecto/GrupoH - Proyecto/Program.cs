using GrupoH___Proyecto;

/*
 * CLIENTE:     123456 
 * CONTRASEÑA:  ******
 * DNI:         40506070
*/

namespace CAIGrupoH
{
    class Program
    {
        static void Main(string[] strings)
        {
            ClienteCorporativo cliente = new ClienteCorporativo();
            string nroCliente;
            string dni;

            do
            {
                // Ingreso de Cliente + Contraseña + DNI Autorizado
                int numeroCliente = Validaciones.ValidarIntCliente("¡Bienvenido! \nIngrese su 'Número de Cliente' para continuar:");
                Console.Clear();
                string contraCliente = Validaciones.ValidarContraseñaIngresada("Ingrese su contraseña:");
                Console.Clear();
                int dniCliente = Validaciones.ValidarDNICliente("Ingrese el 'DNI del Personal Autorizado':");


                nroCliente = numeroCliente.ToString();
                dni = dniCliente.ToString();

                //Valido datos de inicio de sesión
                if (ClienteCorporativo.LeerMaestroCliente(nroCliente, contraCliente, dni))
                {
                    
                    break;
                }
                Console.Clear();
            } while (true);



            //Muestro datos de cliente
            Console.Clear();
            cliente.VisualizarCliente();


            // Menu Princiapl: Opciones
            while (true)
            {
                Console.Clear();
                int menuPrincipal = Validaciones.ValidarMenuPrincipal("Seleccione la acción a realizar: ", "1. Realizar Envío \n2. Consultar Estado de su Envío \n3. Consultar Estado de su Cuenta Corriente \n0. Salir", 0, 3);
                switch (menuPrincipal)
                {
                    case 1:
                        {
                            var realizarEnvioNacional = Envio.Ingresar();
                            break;
                        }
                    case 2:
                        {
                            var conultarEstadoEnvio = OrdenDeServicio.ConsultarEstadoOrden();
                            break;
                        }
                    case 3:
                        {
                            var consultarEstadoCuentaCorriente = CuentaCorriente.ConsultarCuentaCorriente(nroCliente);
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