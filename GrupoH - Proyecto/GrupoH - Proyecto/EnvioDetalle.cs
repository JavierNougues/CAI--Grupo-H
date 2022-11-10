using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CAIGrupoH
{
    internal class EnvioDetalle
    {
        //Maestro Provincias
        public int CodigoProvincia { get; private set; }
        public string NombreProvincia { get; private set; }
        public int CodigoLocalidad { get; private set; }
        public string NombreLocalidad { get; private set; }
        public int CodigoSucursal { get; private set; }
        public string NombreSucursal { get; private set; }
        public string SucursalDireccion { get; private set; }


        // Propiedades Retiro
        public string? TipoRecepcion { get; set; }
        public string? RetiroProvincia { get; set; }
        public string? RetiroLocalidad { get; set; }
        public string? RetiroDireccion { get; set; }
        public string? RetiroDireccionNumero { get; set; }
        public string? RetiroSucursal { get; set; }

        // Propiedades Entrega
        public string? EntregaPais { get; set; }
        public string? TipoEntrega { get; set; }
        public string? EntregaProvincia { get; set; }
        public string? EntregaLocalidad { get; set; }
        public string? EntregaDireccion { get; set; }
        public string? EntregaDireccionNumero { get; set; }
        public string? EntregaSucursal { get; set; }

        // Propiedades Extra
        public string? EntregaInternacionalInfo { get; set; }
        public string? TipoEnvio { get; set; }


        const string maestroProvincias = "C:\\Users\\javier.nougues@sap.com\\Documents\\GitHub\\CAI--Grupo-H\\GrupoH - Proyecto\\maestroprovincias.txt";

        public List<EnvioDetalle> provincias = new List<EnvioDetalle>();

        public EnvioDetalle(string linea)
        {
            var datos = linea.Split('|');
            CodigoProvincia = int.Parse(datos[0]);
            NombreProvincia = datos[1];
            CodigoLocalidad = int.Parse(datos[2]);
            NombreLocalidad = datos[3];
            CodigoSucursal = int.Parse(datos[4]);
            NombreSucursal = datos[5];
            SucursalDireccion = datos[6];
        }

        public EnvioDetalle()
        {
        }

        public static EnvioDetalle RetiroPaquete()
        {
            Console.Clear();
            var tipoRecepcion = new EnvioDetalle();
            while (true)
            {
                string localidadSeleccionada = "";
                string sucursalSeleccionada = "";

                int menuOrigenPaquete = Validaciones.ValidarMenuPrincipal("Retiro del Paquete. \nSeleccione la opción que mas le convenga: ", "1. Retiro del paquete en puerta.\n2. Presentación en sucursal.", 1, 2);
                if (menuOrigenPaquete == 1)
                {
                    tipoRecepcion.TipoRecepcion = "Retiro en puerta";

                    // Provincia de retiro
                    Console.Clear();

                    int menuProvincia = Validaciones.ValidarMenuPrincipal("Seleccione la provincia donde se retira el paquete:", "1. Buenos Aires \n2. Chubut \n3. Catamarca \n4. Chaco \n5. CABA \n6. Córdoba \n7. Corrientes \n8. Entre Ríos \n9. Formosa \n10. Jujuy \n11. La Pampa n12. La Rioja \n13. Mendoza \n14. Misiones \n15. Neuquén \n16. Río Negro \n17. Salta \n18. San Juan \n19. San Luis \n20. Santa Cruz \n21. Santa Fe n22. Santiago del Estero \n23. Tierra del Fuego", 1, 23);

                    tipoRecepcion.LeerMaestroProvincias();
                    switch (menuProvincia)
                    {
                        case 1:
                            {
                                tipoRecepcion.RetiroProvincia = "buenos aires";
                                break;
                            }
                        case 2:
                            {
                                tipoRecepcion.RetiroProvincia = "chubut";
                                break;
                            }
                        case 3:
                            {
                                tipoRecepcion.RetiroProvincia = "catamarca";
                                break;
                            }
                        case 4:
                            {
                                tipoRecepcion.RetiroProvincia = "chaco";
                                break;
                            }
                        case 5:
                            {
                                tipoRecepcion.RetiroProvincia = "caba";
                                break;
                            }
                        case 6:
                            {
                                tipoRecepcion.RetiroProvincia = "cordoba";
                                break;
                            }
                        case 7:
                            {
                                tipoRecepcion.RetiroProvincia = "corrientes";
                                break;
                            }
                        case 8:
                            {
                                tipoRecepcion.RetiroProvincia = "entre rios";
                                break;
                            }
                        case 9:
                            {
                                tipoRecepcion.RetiroProvincia = "formosa";
                                break;
                            }
                        case 10:
                            {
                                tipoRecepcion.RetiroProvincia = "jujuy";
                                break;
                            }
                        case 11:
                            {
                                tipoRecepcion.RetiroProvincia = "la pampa";
                                break;
                            }
                        case 12:
                            {
                                tipoRecepcion.RetiroProvincia = "la rioja";
                                break;
                            }
                        case 13:
                            {
                                tipoRecepcion.RetiroProvincia = "mendoza";
                                break;
                            }
                        case 14:
                            {
                                tipoRecepcion.RetiroProvincia = "misiones";
                                break;
                            }
                        case 15:
                            {
                                tipoRecepcion.RetiroProvincia = "neuquen";
                                break;
                            }
                        case 16:
                            {
                                tipoRecepcion.RetiroProvincia = "rio negro";
                                break;
                            }
                        case 17:
                            {
                                tipoRecepcion.RetiroProvincia = "salta";
                                break;
                            }
                        case 18:
                            {
                                tipoRecepcion.RetiroProvincia = "san juan";
                                break;
                            }
                        case 19:
                            {
                                tipoRecepcion.RetiroProvincia = "san luis";
                                break;
                            }
                        case 20:
                            {
                                tipoRecepcion.RetiroProvincia = "santa cruz";
                                break;
                            }
                        case 21:
                            {
                                tipoRecepcion.RetiroProvincia = "santa fe";
                                break;
                            }
                        case 22:
                            {
                                tipoRecepcion.RetiroProvincia = "santiago del estero";
                                break;
                            }
                        case 23:
                            {
                                tipoRecepcion.RetiroProvincia = "tierra del fuego";
                                break;
                            }

                            tipoRecepcion.CodigoProvincia = menuProvincia;
                            tipoRecepcion.NombreProvincia = tipoRecepcion.RetiroProvincia;
                    }
                                           
                    // Localidad de retiro
                    Console.Clear();
                   Console.WriteLine("Seleccione la localidad donde se retira el paquete:");
                   int codLocalidad = tipoRecepcion.VerLocalidadPorProvincia(tipoRecepcion.CodigoProvincia);
                   localidadSeleccionada = tipoRecepcion.DevuelveNombreLocalidad(codLocalidad);
                   tipoRecepcion.NombreLocalidad = localidadSeleccionada;
                   tipoRecepcion.RetiroLocalidad = localidadSeleccionada;
                   tipoRecepcion.CodigoLocalidad = codLocalidad;

                    // Dirección exacta de retiro
                    Console.Clear();
                    var direccionCalle = Validaciones.ValidarStringIngresado("Ingrese la calle donde se realizara el retiro del paquete:", "Aclaración: solo la calle.");
                    Console.Clear();
                    var direccionNumero = Validaciones.ValidarAlturaIngresada("Ingrese la altura de la calle donde se realizara el retiro del paquete:", 0, 4);
                    tipoRecepcion.RetiroDireccion = direccionCalle;
                    tipoRecepcion.RetiroDireccionNumero = direccionNumero.ToString();

                }
                if (menuOrigenPaquete == 2)
                {
                    tipoRecepcion.TipoRecepcion = "Retiro en sucursal";

                    // Provincia de retiro
                    Console.Clear();

                    int menuProvincia = Validaciones.ValidarMenuPrincipal("Seleccione la provincia donde se retira el paquete:", "1. Buenos Aires \n2. Chubut \n3. Catamarca \n4. Chaco \n5. CABA \n6. Córdoba \n7. Corrientes \n8. Entre Ríos \n9. Formosa \n10. Jujuy \n11. La Pampa n12. La Rioja \n13. Mendoza \n14. Misiones \n15. Neuquén \n16. Río Negro \n17. Salta \n18. San Juan \n19. San Luis \n20. Santa Cruz \n21. Santa Fe n22. Santiago del Estero \n23. Tierra del Fuego", 1, 23);

                    tipoRecepcion.LeerMaestroProvincias();
                    switch (menuProvincia)
                    {
                        case 1:
                            {
                                tipoRecepcion.RetiroProvincia = "buenos aires";
                                break;
                            }
                        case 2:
                            {
                                tipoRecepcion.RetiroProvincia = "chubut";
                                break;
                            }
                        case 3:
                            {
                                tipoRecepcion.RetiroProvincia = "catamarca";
                                break;
                            }
                        case 4:
                            {
                                tipoRecepcion.RetiroProvincia = "chaco";
                                break;
                            }
                        case 5:
                            {
                                tipoRecepcion.RetiroProvincia = "caba";
                                break;
                            }
                        case 6:
                            {
                                tipoRecepcion.RetiroProvincia = "cordoba";
                                break;
                            }
                        case 7:
                            {
                                tipoRecepcion.RetiroProvincia = "corrientes";
                                break;
                            }
                        case 8:
                            {
                                tipoRecepcion.RetiroProvincia = "entre rios";
                                break;
                            }
                        case 9:
                            {
                                tipoRecepcion.RetiroProvincia = "formosa";
                                break;
                            }
                        case 10:
                            {
                                tipoRecepcion.RetiroProvincia = "jujuy";
                                break;
                            }
                        case 11:
                            {
                                tipoRecepcion.RetiroProvincia = "la pampa";
                                break;
                            }
                        case 12:
                            {
                                tipoRecepcion.RetiroProvincia = "la rioja";
                                break;
                            }
                        case 13:
                            {
                                tipoRecepcion.RetiroProvincia = "mendoza";
                                break;
                            }
                        case 14:
                            {
                                tipoRecepcion.RetiroProvincia = "misiones";
                                break;
                            }
                        case 15:
                            {
                                tipoRecepcion.RetiroProvincia = "neuquen";
                                break;
                            }
                        case 16:
                            {
                                tipoRecepcion.RetiroProvincia = "rio negro";
                                break;
                            }
                        case 17:
                            {
                                tipoRecepcion.RetiroProvincia = "salta";
                                break;
                            }
                        case 18:
                            {
                                tipoRecepcion.RetiroProvincia = "san juan";
                                break;
                            }
                        case 19:
                            {
                                tipoRecepcion.RetiroProvincia = "san luis";
                                break;
                            }
                        case 20:
                            {
                                tipoRecepcion.RetiroProvincia = "santa cruz";
                                break;
                            }
                        case 21:
                            {
                                tipoRecepcion.RetiroProvincia = "santa fe";
                                break;
                            }
                        case 22:
                            {
                                tipoRecepcion.RetiroProvincia = "santiago del estero";
                                break;
                            }
                        case 23:
                            {
                                tipoRecepcion.RetiroProvincia = "tierra del fuego";
                                break;
                            }

                            tipoRecepcion.CodigoProvincia = menuProvincia;
                            tipoRecepcion.NombreProvincia = tipoRecepcion.RetiroProvincia;
                    }

                    // Localidad de retiro
                    Console.Clear();
                    Console.WriteLine("Seleccione la localidad donde se retira el paquete:");
                    int codLocalidad = tipoRecepcion.VerLocalidadPorProvincia(menuProvincia);
                    localidadSeleccionada = tipoRecepcion.DevuelveNombreLocalidad(codLocalidad);
                    tipoRecepcion.NombreLocalidad = localidadSeleccionada;
                    tipoRecepcion.RetiroLocalidad = localidadSeleccionada;
                    tipoRecepcion.CodigoLocalidad = codLocalidad;

                    // Sucursal de retiro
                    Console.Clear();
                    Console.WriteLine("Seleccione la sucursal donde se hace retiro del paquete:");
                    int codSucursal = tipoRecepcion.VerSucursalPorLocalidad(tipoRecepcion.CodigoLocalidad);
                    sucursalSeleccionada = tipoRecepcion.DevuelveNombreSucursal(codSucursal);
                    tipoRecepcion.NombreSucursal = sucursalSeleccionada;
                    tipoRecepcion.RetiroSucursal = sucursalSeleccionada;
                    tipoRecepcion.CodigoSucursal = codSucursal;

                }
                break;
            }
            return tipoRecepcion;
        }

        public static EnvioDetalle EntregaPaquete()
        {
            var tipoEntrega = new EnvioDetalle();

            while (true)
            {
                Console.Clear();
                int menuPais = Validaciones.ValidarMenuPrincipal("Seleccione el país donde se entrega el paquete:", "1. Argentina \n2. Otro", 1, 2);

                switch (menuPais)
                {
                    case 1:
                        {
                            tipoEntrega.EntregaPais = "argentina";
                            tipoEntrega.TipoEnvio = "Envío Nacional";
                            break;
                        }
                    case 2:
                        {
                            tipoEntrega.TipoEnvio = "Envío Internacional";
                            int menuOtroPais = Validaciones.ValidarMenuPrincipal("Seleccione el país donde se entrega el paquete:", "América Latina: \n10. Brasil \n11. Bolivia \n12. Paraguay \n13. Uruguay \n14. Chile \n15. Colombia \n16. Perú \n17. Venezuela \n18. Ecuador \n \nAmérica del Norte \n20. Estados Unidos \n21. México \n23. Canadá \n \nEuropa \n30. Alemania \n31. Francia \n32. España \n33. Italia \n34. Inglaterra \n \nAsia \n40. Japón \n41. China \n42. Corea del Sur", 1, 42);
                            switch (menuOtroPais)
                            {
                                case 10:
                                    {
                                        tipoEntrega.EntregaPais = "brasil";
                                        break;
                                    }
                                case 11:
                                    {
                                        tipoEntrega.EntregaPais = "bolivia";
                                        break;
                                    }
                                case 12:
                                    {
                                        tipoEntrega.EntregaPais = "paraguay";
                                        break;
                                    }
                                case 13:
                                    {
                                        tipoEntrega.EntregaPais = "uruguay";
                                        break;
                                    }
                                case 14:
                                    {
                                        tipoEntrega.EntregaPais = "chile";
                                        break;
                                    }
                                case 15:
                                    {
                                        tipoEntrega.EntregaPais = "colombia";
                                        break;
                                    }
                                case 16:
                                    {
                                        tipoEntrega.EntregaPais = "perú";
                                        break;
                                    }
                                case 17:
                                    {
                                        tipoEntrega.EntregaPais = "venezuela";
                                        break;
                                    }
                                case 18:
                                    {
                                        tipoEntrega.EntregaPais = "ecuador";
                                        break;
                                    }
                                case 20:
                                    {
                                        tipoEntrega.EntregaPais = "estados unidos";
                                        break;
                                    }
                                case 21:
                                    {
                                        tipoEntrega.EntregaPais = "méxico";
                                        break;
                                    }
                                case 22:
                                    {
                                        tipoEntrega.EntregaPais = "canadá";
                                        break;
                                    }
                                case 30:
                                    {
                                        tipoEntrega.EntregaPais = "alemania";
                                        break;
                                    }
                                case 31:
                                    {
                                        tipoEntrega.EntregaPais = "francia";
                                        break;
                                    }
                                case 32:
                                    {
                                        tipoEntrega.EntregaPais = "españa";
                                        break;
                                    }
                                case 33:
                                    {
                                        tipoEntrega.EntregaPais = "italia";
                                        break;
                                    }
                                case 34:
                                    {
                                        tipoEntrega.EntregaPais = "inglaterra";
                                        break;
                                    }
                                case 40:
                                    {
                                        tipoEntrega.EntregaPais = "japón";
                                        break;
                                    }
                                case 41:
                                    {
                                        tipoEntrega.EntregaPais = "china";
                                        break;
                                    }
                                case 42:
                                    {
                                        tipoEntrega.EntregaPais = "corea del sur";
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("La opción ingresada es inválida, intente nuevamente:");
                                        continue;
                                    }
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("La opción ingresada es inválida, intente nuevamente:");
                            continue;
                        }
                }

                // Entrega del paquete es en ARGENTINA
                if (tipoEntrega.EntregaPais == "argentina")
                {
                    Console.Clear();

                    while (true)
                    {
                        string localidadSeleccionada = "";
                        string sucursalSeleccionada = "";

                        int menuEntregaPaquete = Validaciones.ValidarMenuPrincipal("Entrega del Paquete. \nSeleccione la opción que mas le convenga: ", "1. Entrega del paquete en puerta.\n2. Entrega en sucursal.", 1, 2);
                        if (menuEntregaPaquete == 1)
                        {
                            tipoEntrega.TipoEntrega = "Entrega en puerta";

                            // Provincia de entrega
                            Console.Clear();

                            int menuProvincia = Validaciones.ValidarMenuPrincipal("Seleccione la provincia donde se entrega el paquete:", "1. Buenos Aires \n2. Chubut \n3. Catamarca \n4. Chaco \n5. CABA \n6. Córdoba \n7. Corrientes \n8. Entre Ríos \n9. Formosa \n10. Jujuy \n11. La Pampa n12. La Rioja \n13. Mendoza \n14. Misiones \n15. Neuquén \n16. Río Negro \n17. Salta \n18. San Juan \n19. San Luis \n20. Santa Cruz \n21. Santa Fe n22. Santiago del Estero \n23. Tierra del Fuego", 1, 23);

                            tipoEntrega.LeerMaestroProvincias();
                            switch (menuProvincia)
                            {
                                case 1:
                                    {
                                        tipoEntrega.EntregaProvincia = "buenos aires";
                                        break;
                                    }
                                case 2:
                                    {
                                        tipoEntrega.EntregaProvincia = "chubut";
                                        break;
                                    }
                                case 3:
                                    {
                                        tipoEntrega.EntregaProvincia = "catamarca";
                                        break;
                                    }
                                case 4:
                                    {
                                        tipoEntrega.EntregaProvincia = "chaco";
                                        break;
                                    }
                                case 5:
                                    {
                                        tipoEntrega.EntregaProvincia = "caba";
                                        break;
                                    }
                                case 6:
                                    {
                                        tipoEntrega.EntregaProvincia = "cordoba";
                                        break;
                                    }
                                case 7:
                                    {
                                        tipoEntrega.EntregaProvincia = "corrientes";
                                        break;
                                    }
                                case 8:
                                    {
                                        tipoEntrega.EntregaProvincia = "entre rios";
                                        break;
                                    }
                                case 9:
                                    {
                                        tipoEntrega.EntregaProvincia = "formosa";
                                        break;
                                    }
                                case 10:
                                    {
                                        tipoEntrega.EntregaProvincia = "jujuy";
                                        break;
                                    }
                                case 11:
                                    {
                                        tipoEntrega.EntregaProvincia = "la pampa";
                                        break;
                                    }
                                case 12:
                                    {
                                        tipoEntrega.EntregaProvincia = "la rioja";
                                        break;
                                    }
                                case 13:
                                    {
                                        tipoEntrega.EntregaProvincia = "mendoza";
                                        break;
                                    }
                                case 14:
                                    {
                                        tipoEntrega.EntregaProvincia = "misiones";
                                        break;
                                    }
                                case 15:
                                    {
                                        tipoEntrega.EntregaProvincia = "neuquen";
                                        break;
                                    }
                                case 16:
                                    {
                                        tipoEntrega.EntregaProvincia = "rio negro";
                                        break;
                                    }
                                case 17:
                                    {
                                        tipoEntrega.EntregaProvincia = "salta";
                                        break;
                                    }
                                case 18:
                                    {
                                        tipoEntrega.EntregaProvincia = "san juan";
                                        break;
                                    }
                                case 19:
                                    {
                                        tipoEntrega.EntregaProvincia = "san luis";
                                        break;
                                    }
                                case 20:
                                    {
                                        tipoEntrega.EntregaProvincia = "santa cruz";
                                        break;
                                    }
                                case 21:
                                    {
                                        tipoEntrega.EntregaProvincia = "santa fe";
                                        break;
                                    }
                                case 22:
                                    {
                                        tipoEntrega.EntregaProvincia = "santiago del estero";
                                        break;
                                    }
                                case 23:
                                    {
                                        tipoEntrega.EntregaProvincia = "tierra del fuego";
                                        break;
                                    }

                                    tipoEntrega.CodigoProvincia = menuProvincia;
                                    tipoEntrega.NombreProvincia = tipoEntrega.EntregaProvincia;
                            }

                            // Localidad de entrega
                            Console.Clear();
                            Console.WriteLine("Seleccione la localidad donde se entrega el paquete:");
                            int codLocalidad = tipoEntrega.VerLocalidadPorProvincia(menuProvincia);
                            localidadSeleccionada = tipoEntrega.DevuelveNombreLocalidad(codLocalidad);
                            tipoEntrega.NombreLocalidad = localidadSeleccionada;
                            tipoEntrega.EntregaLocalidad = localidadSeleccionada;
                            tipoEntrega.CodigoLocalidad = codLocalidad;

                            // Dirección exacta de etrega
                            Console.Clear();
                            var direccionCalle = Validaciones.ValidarStringIngresado("Ingrese la calle donde se realizara la entrega del paquete:", "Aclaración: solo la calle.");
                            Console.Clear();
                            var direccionNumero = Validaciones.ValidarAlturaIngresada("Ingrese la altura de la calle donde se realizara la entrega del paquete:", 0, 4);
                            tipoEntrega.EntregaDireccion = direccionCalle;
                            tipoEntrega.EntregaDireccionNumero = direccionNumero.ToString();

                        }
                        
                        if (menuEntregaPaquete == 2)
                        {
                            tipoEntrega.TipoEntrega = "Entrega en sucursal";

                            // Provincia de entrega
                            Console.Clear();

                            int menuProvincia = Validaciones.ValidarMenuPrincipal("Seleccione la provincia donde se entrega el paquete:", "1. Buenos Aires \n2. Chubut \n3. Catamarca \n4. Chaco \n5. CABA \n6. Córdoba \n7. Corrientes \n8. Entre Ríos \n9. Formosa \n10. Jujuy \n11. La Pampa n12. La Rioja \n13. Mendoza \n14. Misiones \n15. Neuquén \n16. Río Negro \n17. Salta \n18. San Juan \n19. San Luis \n20. Santa Cruz \n21. Santa Fe n22. Santiago del Estero \n23. Tierra del Fuego", 1, 23);

                            tipoEntrega.LeerMaestroProvincias();
                            switch (menuProvincia)
                            {

                                case 1:
                                    {
                                        tipoEntrega.EntregaProvincia = "buenos aires";
                                        break;
                                    }
                                case 2:
                                    {
                                        tipoEntrega.EntregaProvincia = "chubut";
                                        break;
                                    }
                                case 3:
                                    {
                                        tipoEntrega.EntregaProvincia = "catamarca";
                                        break;
                                    }
                                case 4:
                                    {
                                        tipoEntrega.EntregaProvincia = "chaco";
                                        break;
                                    }
                                case 5:
                                    {
                                        tipoEntrega.EntregaProvincia = "caba";
                                        break;
                                    }
                                case 6:
                                    {
                                        tipoEntrega.EntregaProvincia = "cordoba";
                                        break;
                                    }
                                case 7:
                                    {
                                        tipoEntrega.EntregaProvincia = "corrientes";
                                        break;
                                    }
                                case 8:
                                    {
                                        tipoEntrega.EntregaProvincia = "entre rios";
                                        break;
                                    }
                                case 9:
                                    {
                                        tipoEntrega.EntregaProvincia = "formosa";
                                        break;
                                    }
                                case 10:
                                    {
                                        tipoEntrega.EntregaProvincia = "jujuy";
                                        break;
                                    }
                                case 11:
                                    {
                                        tipoEntrega.EntregaProvincia = "la pampa";
                                        break;
                                    }
                                case 12:
                                    {
                                        tipoEntrega.EntregaProvincia = "la rioja";
                                        break;
                                    }
                                case 13:
                                    {
                                        tipoEntrega.EntregaProvincia = "mendoza";
                                        break;
                                    }
                                case 14:
                                    {
                                        tipoEntrega.EntregaProvincia = "misiones";
                                        break;
                                    }
                                case 15:
                                    {
                                        tipoEntrega.EntregaProvincia = "neuquen";
                                        break;
                                    }
                                case 16:
                                    {
                                        tipoEntrega.EntregaProvincia = "rio negro";
                                        break;
                                    }
                                case 17:
                                    {
                                        tipoEntrega.EntregaProvincia = "salta";
                                        break;
                                    }
                                case 18:
                                    {
                                        tipoEntrega.EntregaProvincia = "san juan";
                                        break;
                                    }
                                case 19:
                                    {
                                        tipoEntrega.EntregaProvincia = "san luis";
                                        break;
                                    }
                                case 20:
                                    {
                                        tipoEntrega.EntregaProvincia = "santa cruz";
                                        break;
                                    }
                                case 21:
                                    {
                                        tipoEntrega.EntregaProvincia = "santa fe";
                                        break;
                                    }
                                case 22:
                                    {
                                        tipoEntrega.EntregaProvincia = "santiago del estero";
                                        break;
                                    }
                                case 23:
                                    {
                                        tipoEntrega.EntregaProvincia = "tierra del fuego";
                                        break;
                                    }
                                    tipoEntrega.CodigoProvincia = menuProvincia;
                                    tipoEntrega.NombreProvincia = tipoEntrega.EntregaProvincia;
                            }

                            // Localidad de entrega
                            Console.Clear();
                            Console.WriteLine("Seleccione la localidad donde se entrega el paquete:");
                            int codLocalidad = tipoEntrega.VerLocalidadPorProvincia(menuProvincia);
                            localidadSeleccionada = tipoEntrega.DevuelveNombreLocalidad(codLocalidad);
                            tipoEntrega.NombreLocalidad = localidadSeleccionada;
                            tipoEntrega.EntregaLocalidad = localidadSeleccionada;
                            tipoEntrega.CodigoLocalidad = codLocalidad;

                            // Sucursal de entrega
                            Console.Clear();
                            Console.WriteLine("Seleccione la sucursal donde se hace entrega del paquete:");
                            int codSucursal = tipoEntrega.VerSucursalPorLocalidad(tipoEntrega.CodigoLocalidad);
                            sucursalSeleccionada = tipoEntrega.DevuelveNombreSucursal(codSucursal);
                            tipoEntrega.NombreSucursal = sucursalSeleccionada;
                            tipoEntrega.EntregaSucursal = sucursalSeleccionada;
                            tipoEntrega.CodigoSucursal = codSucursal;

                        }
                        break;
                    }
                    break;
                }
                // Entrega en OTRO PAIS
                else
                {
                    // Dirección exacta de etrega
                    Console.Clear();
                    var direccionCalle = Validaciones.ValidarStringIngresado("Ingrese la calle donde se realizara la entrega del paquete:", "Aclaración: solo la calle.");
                    var direccionNumero = Validaciones.ValidarAlturaIngresada("Ingrese la altura de la calle donde se realizara la entrega del paquete:", 0, 4);
                    var infoAdicional = Validaciones.ValidarStringIngresado("Ingrese cualquier información adicional que considere relevante; ", "");
                    tipoEntrega.EntregaDireccion = direccionCalle;
                    tipoEntrega.EntregaDireccionNumero = direccionNumero.ToString();
                    tipoEntrega.EntregaInternacionalInfo = infoAdicional;
                }
                break;
            }
            return tipoEntrega;
        }



     //***********************************************************************************************************************************************************************************//
     //***********************************************************************************************************************************************************************************//
     // Leer Maestro Provincias
        public void LeerMaestroProvincias()
        {
            if (File.Exists(maestroProvincias))
            {
                using (var reader = new StreamReader(maestroProvincias))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();

                        var provincia = new EnvioDetalle(linea);
                        provincias.Add(provincia);
                    }
                }
            }
        }

        // Seleccion de localidad por provincia
        public int VerLocalidadPorProvincia(int codProvIngresado)
        {

            Console.WriteLine("Código Localidad \tNombre Localidad");

            Dictionary<int, string> auxProvincias = new Dictionary<int, string>();
            bool encontrado;
            foreach (var prov in provincias)
            {
                if (prov.CodigoProvincia == codProvIngresado)
                {
                    encontrado = auxProvincias.ContainsKey(prov.CodigoLocalidad);
                    if (!encontrado)
                    {
                        auxProvincias.Add(prov.CodigoLocalidad, prov.NombreLocalidad);
                    }
                }
            }
            foreach (var item in auxProvincias)
            {
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
            }
            // Validamos seleccion de localidad
            int opcLocalidad;
            do
            {
                var localidad = Console.ReadLine();

                bool ingresoOpcionValida = false;

                bool seleccionCorrecta = int.TryParse(localidad, out opcLocalidad);
                foreach (var item in auxProvincias)
                {
                    if (item.Key == opcLocalidad)
                    {
                        ingresoOpcionValida = true;
                        break;
                    }
                }
                if (seleccionCorrecta == false)
                {
                    Console.WriteLine("El código ingresado debe ser un número, intente nuevamente:");
                    continue;
                }
                if (ingresoOpcionValida == false)
                {
                    Console.WriteLine("Opción inválida, intente nuevamente:");
                    continue;
                }
                
                break;
            } while (true);
            return opcLocalidad;
        }

        // Seleccion de sucursal por localidad
        public int VerSucursalPorLocalidad(int codLocIngresada)
        {
            Console.WriteLine("Código Sucursal \tNombre Sucursal");

            Dictionary<int, string> auxLocalidades = new Dictionary<int, string>();
            bool encontrado = false;
            foreach (var prov in provincias)
            {
                if (prov.CodigoLocalidad == codLocIngresada)
                {
                    encontrado = auxLocalidades.ContainsKey(prov.CodigoSucursal);
                    if (!encontrado)
                    {
                        auxLocalidades.Add(prov.CodigoSucursal, prov.NombreSucursal);
                    }
                }
            }
            foreach (var item in auxLocalidades)
            {
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
            }
            // Validamos seleccion de localidad
            int opcSucursal;
            do
            {
                var sucursal = Console.ReadLine();

                bool ingresoOpcionValida = false;

                bool seleccionCorrecta = int.TryParse(sucursal, out opcSucursal);
                foreach (var item in auxLocalidades)
                {
                    if (item.Key == opcSucursal)
                    {
                        ingresoOpcionValida = true;
                    }
                }
                if (seleccionCorrecta == false)
                {
                    Console.WriteLine("El código ingresado debe ser un número, intente nuevamente:");
                    continue;
                }
                if(ingresoOpcionValida == false)
                {
                    Console.WriteLine("Opción inválida, intente nuevamente:");
                    continue;
                }
                break;
            } while (true);
            return opcSucursal;
        }


        // Devuelve la localidad segun el codigo de localidad
        public string DevuelveNombreLocalidad(int codigoLocalidad)
        {
            Dictionary<int, string> auxLocalidad = new Dictionary<int, string>();
            bool encontrado = false;
            foreach (var prov in provincias)
            {
                if (prov.CodigoLocalidad == codigoLocalidad)
                {
                    encontrado = auxLocalidad.ContainsKey(prov.CodigoLocalidad);
                    if (!encontrado)
                    {
                        auxLocalidad.Add(prov.CodigoLocalidad, prov.NombreLocalidad);
                    }
                }
            }
            string localidadNombre = "";
            foreach (var item in auxLocalidad)
            {
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
                localidadNombre = item.Value;
            }
            return localidadNombre;
        }


        // Devuelve la sucursal segun el codigo de localidad
        public string DevuelveNombreSucursal(int codigoSucursal)
        {
            Dictionary<int, string> auxSucursal = new Dictionary<int, string>();
            bool encontrado = false;
            foreach (var prov in provincias)
            {
                if (prov.CodigoSucursal == codigoSucursal)
                {
                    encontrado = auxSucursal.ContainsKey(prov.CodigoSucursal);
                    if (!encontrado)
                    {
                        auxSucursal.Add(prov.CodigoSucursal, prov.NombreSucursal);
                    }
                }
            }
            string sucursalNombre = "";
            foreach (var item in auxSucursal)
            {
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
                sucursalNombre = item.Value;
            }
            return sucursalNombre;
        }
    }
}