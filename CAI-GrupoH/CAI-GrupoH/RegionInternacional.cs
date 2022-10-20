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
                    Console.WriteLine("No implementado.\n");
                    Console.WriteLine("Ingrese cualquier tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();

                    continue;
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
                    do
                    {
                        var region = Validaciones.ValidarStringIngresado("Ingrese la region donde se retira el paquete: ", "");

                    // Hardcodeado
                    
                        if (region != "CABA")
                        {
                            // No implementado.
                            Console.WriteLine("No implementado.\n");
                            Console.WriteLine("Ingrese cualquier tecla para continuar");
                            Console.ReadKey();
                            Console.Clear();

                            continue;
                        }
                        tipoRecepcionInternacional.RetiroRegionInternacional = region;
                        break;
                    } while (true);
                    

                    // Provincia de retiro
                    Console.Clear();
                    do
                    {
                        var provincia = Validaciones.ValidarStringIngresado("Ingrese la provincia donde se retira el paquete:", "");

                    // Hardcodeado
                    
                        if (provincia != "Buenos Aires")
                        {
                            // No implementado.
                            Console.WriteLine("No implementado.\n");
                            Console.WriteLine("Ingrese cualquier tecla para continuar");
                            Console.ReadKey();
                            Console.Clear();

                            continue;
                        }
                        tipoRecepcionInternacional.RetiroProvinciaInternacional = provincia;
                        break;
                    } while (true);
                    

                    // Localidad de retiro
                    Console.Clear();
                    

                    // Hardcodeado
                    do
                    {
                        var localidad = Validaciones.ValidarStringIngresado("Ingrese la localidad donde se retira el paquete:", "");
                        if (localidad != "Belgrano")
                        {
                            // No implementado.
                            Console.WriteLine("No implementado.\n");
                            Console.WriteLine("Ingrese cualquier tecla para continuar");
                            Console.ReadKey();
                            Console.Clear();

                            continue;
                        }
                        tipoRecepcionInternacional.RetiroLocalidadInternacional = localidad;
                        break;
                    } while (true);
                    

                    // Sucursal de retiro
                     Console.Clear();
                    

                    // Hardcodeado
                    do
                    {
                        var nombreSucursal = Validaciones.ValidarStringIngresado("Ingrese la sucursal donde se realizara el retiro del paquete:", "");
                        if (nombreSucursal != "Belgrano")
                        {
                            // No implementado.
                            Console.WriteLine("No implementado.\n");
                            Console.WriteLine("Ingrese cualquier tecla para continuar");
                            Console.ReadKey();
                            Console.Clear();

                            continue;
                        }
                        tipoRecepcionInternacional.RetiroSucursalInternacional = nombreSucursal;
                        break;
                    } while (true);
                    
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
                    

                    // Harcodeado
                    do
                    {
                        var region = Validaciones.ValidarStringIngresado("Ingrese la region donde se entrega el paquete: ", "");
                        if (region != "Europa")
                        {
                            // No implementado.
                            Console.WriteLine("No implementado.\n");
                            Console.WriteLine("Ingrese cualquier tecla para continuar");
                            Console.ReadKey();
                            Console.Clear();

                            continue;
                        }
                        tipoEntregaInternacional.EntregaRegionInternacional = region;
                        break;
                    } while (true);
                    

                    // Pais de entrega
                    Console.Clear();
                    

                    // Hardcodeado
                    do
                    {
                        var nombrePais = Validaciones.ValidarStringIngresado("Ingrese la sucursal donde se realizara el retiro del paqete:", "");
                        if (nombrePais != "España")
                        {
                            // No implementado.
                            Console.WriteLine("No implementado.\n");
                            Console.WriteLine("Ingrese cualquier tecla para continuar");
                            Console.ReadKey();
                            Console.Clear();

                            continue;
                        }
                        tipoEntregaInternacional.EntregaPaisInternacional = nombrePais;
                        break;
                    } while (true);
                    
                }
                break;
            }
            return tipoEntregaInternacional;
        }
    }
}