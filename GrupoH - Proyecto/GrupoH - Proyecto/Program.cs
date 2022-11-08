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
            while (true)
            {
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
                            //Console.Clear();
                            //Console.WriteLine("Ingrese el Número de Orden de Servicio:");
                            //string numeroOrden = Console.ReadLine();
                            //Validaciones.ValidarOrdenServicio(numeroOrden);
                            break;
                        }
                    case 3:
                        {
                            //EstadoCuenta.EstadodeCuenta();
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