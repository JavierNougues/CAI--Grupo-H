namespace CAIGrupoH
{
    internal class RegionInternacional
    {
        //Propiedades Recepcion
        public string? TipoRecepcionInternacional { get; set; }
        public string? RetiroRegionInternacional { get; set; }
        public string? RetiroProvinciaInternacional { get; set; }
        public string? RetiroLocalidadInternacional { get; set; }
        public string? RetiroDireccionInternacional { get; set; }
        public string? RetiroDireccionNumeroInternacional { get; set; }
        public string? RetiroSucursalInternacional { get; set; }

        //Propiedades Entrega
        public string? TipoEntregaInternacional { get; set; }
        public string? EntregaRegionInternacional { get; set; }
        public string? EntregaPaisInternacional { get; set; }

        public static RegionInternacional RetiroPaqueteInternacional()
        {
            var tipoRecepcionInternacional = new RegionInternacional();
            while (true)
            {
                Console.Clear();
                int menuPrincipal = Validaciones.ValidarMenuPrincipal("Seleccione la opción que mas le convenga: ", "1. Retiro del paquete en puerta.\n2. Presentación en sucursal.", 1, 2);
                if (menuPrincipal == 1)
                {
                    // No implementado.
                    Console.WriteLine("No implementado.");
                    System.Environment.Exit(0);
                    /*
                    tipoRecepcion.TipoRecepcion = "Retiro en puerta";

                    // Region de retiro
                    var region = Validaciones.ValidarStringIngresado("Ingrese la region donde se retira el paquete: ", "");
                    tipoRecepcion.RetiroRegion = region;

                    // Provincia de retiro
                    var provincia = Validaciones.ValidarStringIngresado("Ingrese la provincia donde se retira el paquete: ", "");
                    tipoRecepcion.RetiroProvincia = provincia;

                    // Localidad de retiro
                    var localidad = Validaciones.ValidarStringIngresado("Ingrese la localidad donde se retira el paquete:", "");
                    tipoRecepcion.RetiroLocalidad = localidad;

                    // Dirección exacta de retiro                   
                    var direccionCalle = Validaciones.ValidarStringIngresado("Ingrese la calle donde se realizara el retiro del paquete:", "Aclaración: solo la calle.");
                    var direccionNumero = Validaciones.ValidarIntIngresado("Ingrese la altura de la calle donde se realizara el retiro del paquete:", 0, 4);
                    tipoRecepcion.RetiroDireccion = direccionCalle;
                    tipoRecepcion.RetiroDireccionNumero = direccionNumero;
                    */
                }
                if (menuPrincipal == 2)
                {
                    tipoRecepcionInternacional.TipoRecepcionInternacional = "Retiro en sucursal";

                    // Region de retiro
                    Console.Clear();
                    var region = Validaciones.ValidarStringIngresado("Ingrese la region donde se retira el paquete: ", "");

                    // Hardcodeado
                    do
                    {
                        if (region != "CABA")
                        {
                            Console.WriteLine("No implementado. Intente nuevamente:");
                            region = Console.ReadLine();
                        }
                        break;
                    } while (true);
                    tipoRecepcionInternacional.RetiroRegionInternacional = region;

                    // Provincia de retiro
                    Console.Clear();
                    var provincia = Validaciones.ValidarStringIngresado("Ingrese la provincia donde se retira el paquete:", "");

                    // Hardcodeado
                    do
                    {
                        if (provincia != "Buenos Aires")
                        {
                            Console.WriteLine("No implementado. Intente nuevamente:");
                            provincia = Console.ReadLine();
                        }
                        break;
                    } while (true);
                    tipoRecepcionInternacional.RetiroProvinciaInternacional = provincia;

                    // Localidad de retiro
                    Console.Clear();
                    var localidad = Validaciones.ValidarStringIngresado("Ingrese la localidad donde se retira el paquete:", "");

                    // Hardcodeado
                    do
                    {
                        if (localidad != "Belgrano")
                        {
                            Console.WriteLine("No implementado. Intente nuevamente:");
                            localidad = Console.ReadLine();
                        }
                        break;
                    } while (true);
                    tipoRecepcionInternacional.RetiroLocalidadInternacional = localidad;

                    // Sucursal de retiro
                     Console.Clear();
                    var nombreSucursal = Validaciones.ValidarStringIngresado("Ingrese la sucursal donde se realizara el retiro del paqete:", "");

                    // Hardcodeado
                    do
                    {
                        if (nombreSucursal != "Belgrano")
                        {
                            Console.WriteLine("No implementado. Intente nuevamente:");
                            nombreSucursal = Console.ReadLine();
                        }
                        break;
                    } while (true);
                    tipoRecepcionInternacional.RetiroSucursalInternacional = nombreSucursal;
                }
                break;
            }
            return tipoRecepcionInternacional;
        }

        //Entrega del paquete en destino
        public static RegionInternacional EntregaPaqueteInternacional()
        {
            var tipoEntregaInternacional = new RegionInternacional();
            while (true)
            {
                Console.Clear();
                int menuPrincipal = Validaciones.ValidarMenuPrincipal("Seleccione la opción que mas le convenga: ", "1. Retiro en sucursal.", 1, 1);
                if (menuPrincipal == 1)
                {
                    tipoEntregaInternacional.TipoEntregaInternacional = "Entrega en sucursal";

                    // Region de entrega
                    Console.Clear();
                    var region = Validaciones.ValidarStringIngresado("Ingrese la region donde se entrega el paquete: ", "");

                    // Harcodeado
                    do
                    {
                        if (region != "Europa")
                        {
                            Console.WriteLine("No implementado. Intente nuevamente: ");
                            region = Console.ReadLine();
                        }
                        break;
                    } while (true);
                    tipoEntregaInternacional.EntregaRegionInternacional = region;

                    // Pais de entrega
                    Console.Clear();
                    var nombrePais = Validaciones.ValidarStringIngresado("Ingrese la sucursal donde se realizara el retiro del paqete:", "");

                    // Hardcodeado
                    do
                    {
                        if (nombrePais != "España")
                        {
                            Console.WriteLine("No implementado. Intente nuevamente: ");
                            nombrePais = Console.ReadLine();
                        }
                        break;
                    } while (true);
                    tipoEntregaInternacional.EntregaPaisInternacional = nombrePais;
                }
                break;
            }
            return tipoEntregaInternacional;
        }
    }
}