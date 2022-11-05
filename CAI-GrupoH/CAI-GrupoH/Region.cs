using System.Xml.Linq;

namespace CAIGrupoH
{
    internal class Region
    {
        //Propiedades Recepcion
        public string? TipoRecepcion { get; set; }
        public string? RetiroProvincia { get; set; }
        public string? RetiroLocalidad { get; set; }
        public string? RetiroDireccion { get; set; }
        public string? RetiroDireccionNumero { get; set; }
        public string? RetiroSucursal { get; set; }

        //Propiedades Entrega
        public string? TipoEntrega { get; set; }
        public string? EntregaProvincia { get; set; }
        public string? EntregaLocalidad { get; set; }
        public string? EntregaDireccion { get; set; }
        public string? EntregaDireccionNumero { get; set; }
        public string? EntregaSucursal { get; set; }

        // Retiro del paquete para ser enviado
        public static Region RetiroPaquete()
        {
            Console.Clear();
            var tipoRecepcion = new Region();
            while (true)
            {
                int menuOrigenPaquete = Validaciones.ValidarMenuPrincipal("Retiro del Paquete. \nSeleccione la opción que mas le convenga: ", "1. Retiro del paquete en puerta.\n2. Presentación en sucursal.", 1, 2);
                if (menuOrigenPaquete == 1)
                {
                    tipoRecepcion.TipoRecepcion = "Retiro en puerta";

                    // Region de retiro
                    Console.Clear();
                    do
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

                    // Provincia de retiro
                    Console.Clear();
                    do
                    {
                        int menuProvincia = Validaciones.ValidarMenuPrincipal("Seleccione la provincia donde se retira el paquete:", "1. Buenos Aires", 1, 1);

                        // Hardcodeado

                        if (menuProvincia != 1)
                        {
                            Console.WriteLine("Provincia no implementada, intente nuevamente:");
                            menuProvincia = int.Parse(Console.ReadLine());
                            Console.Clear();
                            continue;
                        }
                        var provincia = "buenos aires";
                        tipoRecepcion.RetiroProvincia = provincia;
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
                            try { 
                        menuLocalidad = int.Parse(Console.ReadLine());
                            }
                            catch { menuLocalidad = -1; }
                        Console.Clear();
                        continue;
                        }
                        var localidad = "belgrano";
                        tipoRecepcion.RetiroLocalidad = localidad;
                    break;
                } while (true) ;


                    // Dirección exacta de retiro
                    Console.Clear();
                    var direccionCalle = Validaciones.ValidarStringIngresado("Ingrese la calle donde se realizara el retiro del paquete:", "Aclaración: solo la calle.");
                    Console.Clear();
                    var direccionNumero = Validaciones.ValidarIntIngresado("Ingrese la altura de la calle donde se realizara el retiro del paquete:", 0, 4);
                    tipoRecepcion.RetiroDireccion = direccionCalle;
                    tipoRecepcion.RetiroDireccionNumero = direccionNumero.ToString();
                    
                }
                if (menuOrigenPaquete == 2)
                {
                    tipoRecepcion.TipoRecepcion = "Retiro en sucursal";

                    // Region de retiro
                    Console.Clear();
                    do
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
                        tipoRecepcion.RetiroProvincia = provincia;
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
                        tipoRecepcion.RetiroLocalidad = localidad;
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
                        tipoRecepcion.RetiroSucursal = nombreSucursal;
                        break;
                    } while (true);
                    
                }
                break;
            }
            return tipoRecepcion;
        }

        //Entrega del paquete en destino
        public static Region EntregaPaquete()
        {
            var tipoEntrega = new Region();
            while (true)
            {
                Console.Clear();
                int menuEntregaPaquete = Validaciones.ValidarMenuPrincipal("Entrega del Paquete. \nSeleccione la opción que mas le convenga: ", "1. Entrega del paquete en puerta. \n2. Retiro en sucursal.", 1, 2);
                if (menuEntregaPaquete == 1)
                {
                    tipoEntrega.TipoEntrega = "Entrega en puerta";


                    // Region de entrega
                    Console.Clear();
                    do
                    {
                        var menuRegion = Validaciones.ValidarMenuPrincipal("Seleccione la region donde se entrega el paquete: ", "1. NOA \n2. NEA \n3. Cuyo \n4. Centro \n5. CABA \n6. Sur", 1, 6);

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
                        var region = "noa";
                        tipoRecepcionInternacional.RetiroRegionInternacional = region;
                        break;
                    } while (true);
                    
                    // Provincia de entrega
                    Console.Clear();
                    do
                    {
                        int menuProvincia = Validaciones.ValidarMenuPrincipal("Seleccione la Provincia donde se entrega el paquete: ", "1. Catamarca \n2. Jujuy \n3. Tucumán \n4. Salta \n5. Santiago del Estero", 1, 5);

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
                        var provincia = "catamarca";
                        tipoEntrega.EntregaProvincia = provincia;
                        break;
                    } while (true);

                    // Localidad de entrega
                    Console.Clear();
                    do
                    {
                        var menuLocalidad = Validaciones.ValidarMenuPrincipal("Seleccione la localidad donde se entrega el paquete: ", "1. San Fernando del Valle de Catamarca", 1, 1);

                        // Hardcodeado
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
                        var localidad = "san fernando del valle de catamarca";
                        tipoEntrega.EntregaLocalidad = localidad;
                        break;
                    } while (true);

                    // Dirección exacta de entrega
                    Console.Clear();
                    var direccionCalle = Validaciones.ValidarStringIngresado("Seleccione la calle donde se realizara la entrega del paquete:", "Aclaración: solo la calle.");
                    Console.Clear();
                    var direccionNumero = Validaciones.ValidarIntIngresado("Seleccione la altura de la calle donde se realizara la entrega del paquete:", 0, 4);
                    tipoEntrega.EntregaDireccion = direccionCalle;
                    tipoEntrega.EntregaDireccionNumero = direccionNumero.ToString();
                }
                if (menuEntregaPaquete == 2)
                {
                    tipoEntrega.TipoEntrega = "Entrega en sucursal";

                    // Region de entrega
                    Console.Clear();
                    do
                    {
                        var menuRegion = Validaciones.ValidarMenuPrincipal("Seleccione la region donde se entrega el paquete: ", "1. NOA \n2. NEA \n3. Cuyo \n4. Centro \n5. CABA \n6. Sur", 1, 6);

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
                        var region = "noa";
                        tipoRecepcionInternacional.RetiroRegionInternacional = region;
                        break;
                    } while (true);

                    // Provincia de entrega
                    Console.Clear();
                    do
                    {
                        int menuProvincia = Validaciones.ValidarMenuPrincipal("Seleccione la Provincia donde se entrega el paquete: ", "1. Catamarca \n2. Jujuy \n3. Tucumán \n4. Salta \n5. Santiago del Estero", 1, 5);

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
                        var provincia = "catamarca";
                        tipoEntrega.EntregaProvincia = provincia;
                        break;
                    } while (true);


                    // Localidad de entrega
                    Console.Clear();
                    do
                    {
                        var menuLocalidad = Validaciones.ValidarMenuPrincipal("Seleccione la localidad donde se entrega el paquete: ", "1. San Fernando del Valle de Catamarca", 1, 1);

                        // Hardcodeado
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
                        var localidad = "san fernando del valle de catamarca";
                        tipoEntrega.EntregaLocalidad = localidad;
                        break;
                    } while (true);


                    // Sucursal de entrega
                    Console.Clear();
                    do
                    {
                        int menuNombreSucursal = Validaciones.ValidarMenuPrincipal("Seleccione la sucursal donde se realizara el retiro del paquete:", "1. San Fernando del Valle de Catamarca", 1, 1);

                    // Hardcodeado
                    
                        if (menuNombreSucursal != 1)
                        {
                            Console.WriteLine("Localidad no implementada, intente nuevamente:");
                            try
                            {
                                menuNombreSucursal = int.Parse(Console.ReadLine());
                            }
                            catch { menuNombreSucursal = -1; }
                            Console.Clear();
                            continue;
                        }
                        var nombreSucursal = "san fernando del valle de catamarca";
                        tipoEntrega.EntregaSucursal = nombreSucursal;
                        break;
                    } while (true);
                    
                }
                break;
            }
            return tipoEntrega;
        }
    }
}
