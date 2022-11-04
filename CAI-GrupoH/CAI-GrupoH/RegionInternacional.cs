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
                int menuPrincipal = Validaciones.ValidarMenuPrincipal("Retiro del Paquete. \nSeleccione la opción que mas le convenga: ", "1. Retiro del paquete en puerta.\n2. Presentación en sucursal.", 1, 2);
                if (menuPrincipal == 1)
                {
                    tipoRecepcionInternacional.TipoRecepcionInternacional = "Retiro en puerta";

                    // Region de retiro
                    Console.Clear();
                    /*do
                    {
                        var menuRegion = Validaciones.ValidarMenuPrincipal("Seleccione la region donde se retira el paquete: ", "1. NOA \n2. NEA \n3. Cuyo \n4. Centro \n5. CABA \n6. Sur", 1, 6);

                        // Hardcodeado
                        if (menuRegion != 5)
                        {
                            Console.WriteLine("Region no implementada, intente nuevamente:");
                            try
                            {
                                menuRegion = int.Parse(Console.ReadLine());
                            }
                            catch { menuRegion = -1; }
                            Console.Clear();
                            continue;
                        }
                        var region = "caba";
                        tipoRecepcionInternacional.RetiroRegionInternacional = region;
                        break;
                    } while (true);
                    */

                    // Provincia de retiro
                    Console.Clear();
                    do
                    {
                        int menuProvincia = Validaciones.ValidarMenuPrincipal("Seleccione la provincia donde se retira el paquete:", "1. Buenos Aires", 1, 1);

                        // Hardcodeado

                        if (menuProvincia != 1)
                        {
                            Console.WriteLine("Provincia no implementada, intente nuevamente:");
                            try
                            {
                                menuProvincia = int.Parse(Console.ReadLine());
                            }
                            catch { menuProvincia = -1; }
                            Console.Clear();
                            continue;
                        }
                        var provincia = "buenos aires";
                        tipoRecepcionInternacional.RetiroProvinciaInternacional = provincia;
                        break;
                    } while (true);


                    // Localidad de retiro
                    Console.Clear();
                    do
                    {
                        int menuLocalidad = Validaciones.ValidarMenuPrincipal("Seleccione la localidad donde se retira el paquete:", "1. Belgrano \n2. Caballito", 1, 2);
                        if (menuLocalidad != 1)
                        {
                            Console.WriteLine("Localidad no implementada, intente nuevamente:");
                            try
                            {
                                menuLocalidad = int.Parse(Console.ReadLine());
                            }
                            catch { menuLocalidad = -1; }
                            Console.Clear();
                            continue;
                        }
                        var localidad = "belgrano";
                        tipoRecepcionInternacional.RetiroLocalidadInternacional = localidad;
                        break;
                    } while (true);


                    // Dirección exacta de retiro
                    Console.Clear();
                    var direccionCalle = Validaciones.ValidarStringIngresado("Ingrese la calle donde se realizara el retiro del paquete:", "Aclaración: solo la calle.");
                    Console.Clear();
                    var direccionNumero = Validaciones.ValidarIntIngresado("Ingrese la altura de la calle donde se realizara el retiro del paquete:", 1, 4);
                    tipoRecepcionInternacional.RetiroDireccionInternacional = direccionCalle;
                    tipoRecepcionInternacional.RetiroDireccionNumeroInternacional = direccionNumero.ToString();
                }
                if (menuPrincipal == 2)
                {
                    tipoRecepcionInternacional.TipoRecepcionInternacional = "Retiro en sucursal";

                    // Region de retiro
                    Console.Clear();
                    /*do
                    {
                        var menuRegion = Validaciones.ValidarMenuPrincipal("Seleccione la region donde se retira el paquete: ", "1. NOA \n2. NEA \n3. Cuyo \n4. Centro \n5. CABA \n6. Sur", 1, 6);

                        // Hardcodeado
                        if (menuRegion != 5)
                        {
                            Console.WriteLine("Region no implementada, intente nuevamente:");
                            try
                            {
                                menuRegion = int.Parse(Console.ReadLine());
                            }
                            catch { menuRegion = -1; }
                            Console.Clear();
                            continue;
                        }
                        var region = "caba";
                        tipoRecepcionInternacional.RetiroRegionInternacional = region;
                        break;
                    } while (true);
                    */

                    // Provincia de retiro
                    Console.Clear();
                    do
                    {
                        int menuProvincia = Validaciones.ValidarMenuPrincipal("Seleccione la provincia donde se retira el paquete:", "1. Buenos Aires", 1, 1);

                        // Hardcodeado

                        if (menuProvincia != 1)
                        {
                            Console.WriteLine("Provincia no implementada, intente nuevamente:");
                            try
                            {
                                menuProvincia = int.Parse(Console.ReadLine());
                            }
                            catch { menuProvincia = -1; }
                            Console.Clear();
                            continue;
                        }
                        var provincia = "buenos aires";
                        tipoRecepcionInternacional.RetiroProvinciaInternacional = provincia;
                        break;
                    } while (true);


                    // Localidad de retiro
                    Console.Clear();
                    do
                    {
                        int menuLocalidad = Validaciones.ValidarMenuPrincipal("Seleccione la localidad donde se retira el paquete:", "1. Belgrano \n2. Caballito", 1, 2);
                        if (menuLocalidad != 1)
                        {
                            Console.WriteLine("Localidad no implementada, intente nuevamente:");
                            try
                            {
                                menuLocalidad = int.Parse(Console.ReadLine());
                            }
                            catch { menuLocalidad = -1; }
                            Console.Clear();
                            continue;
                        }
                        var localidad = "belgrano";
                        tipoRecepcionInternacional.RetiroLocalidadInternacional = localidad;
                        break;
                    } while (true);


                    // Sucursal de retiro
                    Console.Clear();
                    do
                    {
                        int menuNombreSucursal = Validaciones.ValidarMenuPrincipal("Seleccione la sucursal donde se realizara el retiro del paquete:", "1. Belgrano", 1, 1);

                        // Hardcodeado

                        if (menuNombreSucursal != 1)
                        {
                            Console.WriteLine("Sucursal no implementada, intente nuevamente:");
                            try
                            {
                                menuNombreSucursal = int.Parse(Console.ReadLine());
                            }
                            catch { menuNombreSucursal = -1; }
                            Console.Clear();
                            continue;
                        }
                        var nombreSucursal = "belgrano";
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
          
                tipoEntregaInternacional.TipoEntregaInternacional = "Entrega en sucursal";
                Console.Clear();

                    // Region de entrega
                    Console.Clear();
                    // Harcodeado
                    do
                    {
                        int menuRegion = Validaciones.ValidarMenuPrincipal("Seleccione la region donde se entrega el paquete: ", "1. Europa \n2. Asia \n3. America del Norte \n4. Centro America", 1, 4);

                        // Hardcodeado
                        if (menuRegion != 1)
                        {
                            Console.WriteLine("Region no implementada, intente nuevamente:");
                        try
                        {
                            menuRegion = int.Parse(Console.ReadLine());
                        }
                        catch { menuRegion = -1; }
                        Console.Clear();
                            continue;
                        }
                        var region = "europa";
                        tipoEntregaInternacional.EntregaRegionInternacional = region;
                        break;
                    } while (true);


                    // Pais de entrega
                    Console.Clear();
                    // Hardcodeado
                    do
                    {
                        int menuNombrePais = Validaciones.ValidarMenuPrincipal("Seleccione el país donde se entrega el paqete:", "1. España \n2. Francia \n3. Italia", 1, 3);
                        if (menuNombrePais != 1)
                        {
                            Console.WriteLine("Region no implementada, intente nuevamente:");
                        try
                        {
                            menuNombrePais = int.Parse(Console.ReadLine());
                        }
                        catch { menuNombrePais = -1; }
                        Console.Clear();
                            continue;
                        }
                        var nombrePais = "españa";
                        tipoEntregaInternacional.EntregaPaisInternacional = nombrePais;
                        break;
                    } while (true);
            
            return tipoEntregaInternacional;
        }
    }
}
