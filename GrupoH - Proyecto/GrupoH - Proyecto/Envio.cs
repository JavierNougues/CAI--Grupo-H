using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GrupoH___Proyecto;

namespace CAIGrupoH
{
    internal class Envio
    {
        public string? TipoPaquete { get; set; }
        public string? PesoPaquete { get; set; }
        public string? TipoEnvio { get; set; }
        public double? TarifaPaqueteNacional { get; set; }
        public string? OrdenDeServicio { get; set; }

        // Propiedades Tarifas
        public string? EnvioTarifa { get; set; }
        public string? PaqueteTarifa { get; set; }
        public string? ZonaTarifa  { get; set; }
        public double PrecioTarifa { get; }

        const string maestroTarifas = "C:\\Users\\javier.nougues@sap.com\\Documents\\GitHub\\CAI--Grupo-H\\GrupoH - Proyecto\\maestrotarifas.txt";

        public List<Envio> tarifas = new List<Envio>();

        public Envio(string linea)
        {
            var datos = linea.Split('|');
            EnvioTarifa = datos[0];
            PaqueteTarifa = datos[1];
            ZonaTarifa = datos[2];
            PrecioTarifa = double.Parse(datos[3]);
        }


        EnvioDetalle RetiroPaquete = new EnvioDetalle();
        EnvioDetalle EntregaPaquete = new EnvioDetalle();
        ClienteCorporativo Cliente = new ClienteCorporativo();

        public Envio()
        {

        }

        public void LeerMaestroTarifas()
        {
            if (File.Exists(maestroTarifas))
            {
                using (var reader = new StreamReader(maestroTarifas))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();

                        var tarifa = new Envio(linea);
                        tarifas.Add(tarifa);
                    }
                }
            }
        }
        public static Envio Ingresar()
        {
            Console.Clear();

            var nuevoEnvio = new Envio();
            Console.WriteLine("Nuevo Envío Nacional: ");
            while (true)
            {
                string tipoPaquete = "";
                int menuTipoPaquete = Validaciones.ValidarMenuPrincipal("Seleccione el tipo de paquete: ", "1. Correspondencia: hasta 500gr.\n2. Encomienda: hasta 30kg.", 1, 2);

                if (menuTipoPaquete == 1)
                {
                    tipoPaquete = "Correspondencia";
                }
                if (menuTipoPaquete == 2)
                {
                    tipoPaquete = "Encomienda";
                }

                nuevoEnvio.TipoPaquete = tipoPaquete;
                break;
            }

            if (nuevoEnvio.TipoPaquete == "Correspondencia")
            {
                string pesoEncomienda = "Correspondencia hasta 500g";
                nuevoEnvio.PesoPaquete = pesoEncomienda;
            }

            Console.Clear();
            if (nuevoEnvio.TipoPaquete == "Encomienda")
            {
                string pesoEncomienda = "";
                int menuPrincipal = Validaciones.ValidarMenuPrincipal("Seleccione el peso del paquete a enviar: ", "1. Bultos hasta 10Kg. \n2. Bultos hasta 20Kg. \n3. Bultos hasta 30Kg.", 1, 3);

                switch (menuPrincipal)
                {
                    case 1:
                        {
                            pesoEncomienda = "Bultos hasta 10Kg";
                            break;
                        }
                    case 2:
                        {
                            pesoEncomienda = "Bultos hasta 20Kg";
                            break;
                        }
                    case 3:
                        {
                            pesoEncomienda = "Bultos hasta 30Kg";
                            break;
                        }
                }
                nuevoEnvio.PesoPaquete = pesoEncomienda;
            }
            Console.Clear();
            do
            {
                int menuTipoEnvio = Validaciones.ValidarMenuPrincipal("Seleccione el tipo de envío:", "1. Envío urgente: 48hs.\n2. Envío normal.", 1, 2);
                string tipoEnvio = "";
                if (menuTipoEnvio == 1)
                {
                    tipoEnvio = "Envio urgente";
                }
                if (menuTipoEnvio == 2)
                {
                    tipoEnvio = "Envio normal";
                }
                nuevoEnvio.TipoEnvio = tipoEnvio;
                break;
            } while (true);

            /***************************************************************/
            // Origen del paquete (en puerta o presentacion en sucursal).
            // Traigo info del retiro del paquete.
            var retiroPaquete = EnvioDetalle.RetiroPaquete();
            nuevoEnvio.RetiroPaquete = retiroPaquete;

            // Destino del paquete (en puerta o presentacion en sucursal).
            // Traigo info de la entrega del paquete
            var entregaPaquete = EnvioDetalle.EntregaPaquete();
            nuevoEnvio.EntregaPaquete = entregaPaquete;
            /***************************************************************/

            /***************************************************************/
            //Calculo de las tarifas
            nuevoEnvio.CalcularTarifa();
            /***************************************************************/

            /***************************************************************/
            // Crear orden de servicio
            // Generamos numero aleatorio
            var numeroOS = new Random();
            int sigOrdenDeServicio = numeroOS.Next(1000, 9999);

            // Asignamos nueva orden al envio nacional.
            nuevoEnvio.OrdenDeServicio = sigOrdenDeServicio.ToString();

            // Mostramos en pantalla el envio al detalle
            Console.Clear();
            Console.Write("-----------------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine($"Tipo de Envío: {nuevoEnvio.EntregaPaquete.TipoEnvio}\n");
            Console.WriteLine($"Numero de Orden: {nuevoEnvio.OrdenDeServicio.ToUpper()}\n");
            Console.WriteLine($"Peso Paquete: {nuevoEnvio.PesoPaquete.ToUpper()}\n");
            Console.WriteLine($"Importe: ${nuevoEnvio.TarifaPaqueteNacional.ToString()}\n");
            Console.WriteLine($"Tipo Envío: {nuevoEnvio.TipoEnvio.ToUpper()}\n\n");

            Console.Write("Origen del Paquete: \n");
            Console.WriteLine($"Tipo de Retiro: {nuevoEnvio.RetiroPaquete.TipoRecepcion.ToUpper()}\n");
            Console.WriteLine($"Provincia de Retiro: {nuevoEnvio.RetiroPaquete.RetiroProvincia.ToUpper()}\n");
            Console.WriteLine($"Localidad de Retiro: {nuevoEnvio.RetiroPaquete.RetiroLocalidad.ToUpper()}\n");
            if (nuevoEnvio.RetiroPaquete.RetiroSucursal != null)
            {
                Console.WriteLine($"Sucursal de Retiro: {nuevoEnvio.RetiroPaquete.RetiroSucursal.ToUpper()}\n \n");
            }
            else
            {
                Console.WriteLine($"Dirección de Retiro: {nuevoEnvio.RetiroPaquete.RetiroDireccion} {nuevoEnvio.RetiroPaquete.RetiroDireccionNumero}\n");
            }


            Console.Write("Destino del Paquete: \n");
            if (nuevoEnvio.EntregaPaquete.EntregaPais == "argentina")
            {
                Console.WriteLine($"Tipo de Entrega: {nuevoEnvio.EntregaPaquete.TipoEntrega.ToUpper()}\n");
                Console.WriteLine($"Provincia de Entrega: {nuevoEnvio.EntregaPaquete.EntregaProvincia.ToUpper()}\n");
                Console.WriteLine($"Localidad de Entrega: {nuevoEnvio.EntregaPaquete.EntregaLocalidad.ToUpper()}\n");
                if (nuevoEnvio.EntregaPaquete.EntregaSucursal != null)
                {
                    Console.WriteLine($"Sucursal de Entrega: {nuevoEnvio.EntregaPaquete.EntregaSucursal.ToUpper()}\n");
                }
                else
                {
                    Console.WriteLine($"Dirección de Entrega: {nuevoEnvio.EntregaPaquete.EntregaDireccion} {nuevoEnvio.EntregaPaquete.EntregaDireccionNumero}\n");
                }
            }
            else
            {
                Console.WriteLine($"País de Entrega: {nuevoEnvio.EntregaPaquete.EntregaPais.ToUpper()}\n");
                Console.WriteLine($"Dirección de Entrega: {nuevoEnvio.EntregaPaquete.EntregaDireccion} {nuevoEnvio.EntregaPaquete.EntregaDireccionNumero}\n");
                Console.WriteLine($"Información Adicional: {nuevoEnvio.EntregaPaquete.EntregaInternacionalInfo}\n");
            }
            
            Console.Write("-----------------------------------------------------------------------------------------------------------------------\n");


            // Confirmamos la orden de envio
            int menuConfirmacion = Validaciones.ValidarMenuPrincipal("Desea confirmar la operación:", "Presione: 1 (Si) \nPresione: 2. (No)", 1, 2);
            if (menuConfirmacion == 2)
            {
                Console.Clear();
                Console.WriteLine("Ha finalizado la operación.");
                Console.WriteLine("Ingrese cualquier tecla para continuar");
                Console.ReadKey();

            }
            if (menuConfirmacion == 1)
            {
                Console.Clear();
                Console.WriteLine("Ha generado su solicitud con éxito!\n Gracias por utilizar nuestros servicios!");
                Console.WriteLine("Ingrese cualquier tecla para continuar");
                Console.ReadKey();

                //Creamos nueva orden
                OrdenDeServicio nuevaOS = new OrdenDeServicio();
                   
                nuevaOS.NroOrdenServicio = nuevoEnvio.OrdenDeServicio;
                nuevaOS.NumeroCliente = nuevoEnvio.Cliente.NroCliente();
                nuevaOS.NombreCliente = nuevoEnvio.Cliente.Cliente();
                nuevaOS.FechaOS = DateTime.Today;
                nuevaOS.EstadoOrden = "Iniciada";
                nuevaOS.TipoEnvio = nuevoEnvio.TipoEnvio;
                nuevaOS.PesoPaquete = nuevoEnvio.PesoPaquete;
                nuevaOS.Tarifa = nuevoEnvio.TarifaPaqueteNacional.ToString();

                nuevaOS.TipoRecepcion = nuevoEnvio.RetiroPaquete.TipoRecepcion;
                nuevaOS.RetiroProvincia = nuevoEnvio.RetiroPaquete.RetiroProvincia;
                nuevaOS.RetiroLocalidad = nuevoEnvio.RetiroPaquete.RetiroLocalidad;
                nuevaOS.RetiroDireccion = nuevoEnvio.RetiroPaquete.RetiroDireccion;
                nuevaOS.RetiroDireccionNumero = nuevoEnvio.RetiroPaquete.RetiroDireccionNumero;
                nuevaOS.RetiroSucursal = nuevoEnvio.RetiroPaquete.RetiroSucursal;

                nuevaOS.TipoEntrega = nuevoEnvio.EntregaPaquete.TipoEntrega;
                nuevaOS.EntregaPais = nuevoEnvio.EntregaPaquete.EntregaPais;
                nuevaOS.EntregaProvincia = nuevoEnvio.EntregaPaquete.EntregaProvincia;
                nuevaOS.EntregaLocalidad = nuevoEnvio.EntregaPaquete.EntregaLocalidad;
                nuevaOS.EntregaDireccion = nuevoEnvio.EntregaPaquete.EntregaDireccion;
                nuevaOS.EntregaDireccionNumero = nuevoEnvio.EntregaPaquete.EntregaDireccionNumero;
                nuevaOS.EntregaSucursal = nuevoEnvio.EntregaPaquete.EntregaSucursal;


                nuevaOS.LeerMaestroOrdenes();
                // Agregamos a la lista
                nuevaOS.AgregarOrdenDeServicio(nuevaOS);
                // Grabamos en el txt Maestro Ordenes de Servicio
                nuevaOS.GuardarOrdenDeServicio();
            }
            Console.Clear();
            return nuevoEnvio;
        }

        public void CalcularTarifa()
        {
            LeerMaestroTarifas();
            double tarifaPaquete = 0;
            for (int i = 0; i < tarifas.Count; i++)
            {
                if (RetiroPaquete.TipoRecepcion == "Retiro en puerta")
                {
                    // Cargo fijo por retiro en puerta.
                    if (tarifas[i].EnvioTarifa == "retiropuerta")
                    {
                        tarifaPaquete += tarifas[i].PrecioTarifa;
                    }
                }
                if (EntregaPaquete.TipoEntrega == "Entrega en puerta")
                {
                    // Cargo fijo por retiro en puerta.
                    if (tarifas[i].EnvioTarifa == "entregapuerta")
                    {
                        tarifaPaquete += tarifas[i].PrecioTarifa;
                    }
                }


                // TARIFA NACIONAL
                if (EntregaPaquete.EntregaPais == "argentina" && tarifas[i].EnvioTarifa == "nacional")
                {
                    if (TipoPaquete == "Correspondencia" && tarifas[i].PaqueteTarifa == "correspondencia")
                    {
                        // Tarifa local
                        if (RetiroPaquete.RetiroLocalidad == EntregaPaquete.EntregaLocalidad)
                        {
                            if (tarifas[i].ZonaTarifa == "local")
                            {
                                tarifaPaquete += tarifas[i].PrecioTarifa;
                                break;
                            }
                        }
                        // Tarifa regional
                        if (RetiroPaquete.RetiroRegion == EntregaPaquete.EntregaRegion)
                        {
                            // Tarifa Provincial
                            if (RetiroPaquete.RetiroProvincia == EntregaPaquete.EntregaProvincia)
                            {
                                if (tarifas[i].ZonaTarifa == "provincial")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                            // Tarifa Regional
                            else
                            {
                                if (tarifas[i].ZonaTarifa == "regional")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                        }
                        else
                        //Tarifa Nacional
                        {
                            if (tarifas[i].ZonaTarifa == "nacional")
                            {
                                tarifaPaquete += tarifas[i].PrecioTarifa;
                                break;
                            }
                        }
                    }
                    if (TipoPaquete == "Encomienda")
                    {
                        if (PesoPaquete == "Bultos hasta 10Kg" && tarifas[i].PaqueteTarifa == "bulto10")
                        {
                            // Tarifa local
                            if (RetiroPaquete.RetiroLocalidad == EntregaPaquete.EntregaLocalidad)
                            {
                                if (tarifas[i].ZonaTarifa == "local")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                            // Tarifa regional
                            if (RetiroPaquete.RetiroRegion == EntregaPaquete.EntregaRegion)
                            {
                                // Tarifa Provincial
                                if (RetiroPaquete.RetiroProvincia == EntregaPaquete.EntregaProvincia)
                                {
                                    if (tarifas[i].ZonaTarifa == "provincial")
                                    {
                                        tarifaPaquete += tarifas[i].PrecioTarifa;
                                        break;
                                    }
                                }
                                // Tarifa Regional
                                else
                                {
                                    if (tarifas[i].ZonaTarifa == "regional")
                                    {
                                        tarifaPaquete += tarifas[i].PrecioTarifa;
                                        break;
                                    }
                                }
                            }
                            else
                            //Tarifa Nacional
                            {
                                if (tarifas[i].ZonaTarifa == "nacional")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                        }
                        if (PesoPaquete == "Bultos hasta 20Kg" && tarifas[i].PaqueteTarifa == "bulto20")
                        {
                            // Tarifa local
                            if (RetiroPaquete.RetiroLocalidad == EntregaPaquete.EntregaLocalidad)
                            {
                                if (tarifas[i].ZonaTarifa == "local")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                            // Tarifa regional
                            if (RetiroPaquete.RetiroRegion == EntregaPaquete.EntregaRegion)
                            {
                                // Tarifa Provincial
                                if (RetiroPaquete.RetiroProvincia == EntregaPaquete.EntregaProvincia)
                                {
                                    if (tarifas[i].ZonaTarifa == "provincial")
                                    {
                                        tarifaPaquete += tarifas[i].PrecioTarifa;
                                        break;
                                    }
                                }
                                // Tarifa Regional
                                else
                                {
                                    if (tarifas[i].ZonaTarifa == "regional")
                                    {
                                        tarifaPaquete += tarifas[i].PrecioTarifa;
                                        break;
                                    }
                                }
                            }
                            else
                            //Tarifa Nacional
                            {
                                if (tarifas[i].ZonaTarifa == "nacional")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                        }
                        if (PesoPaquete == "Bultos hasta 30Kg" && tarifas[i].PaqueteTarifa == "bulto30")
                        {
                            // Tarifa local
                            if (RetiroPaquete.RetiroLocalidad == EntregaPaquete.EntregaLocalidad)
                            {
                                if (tarifas[i].ZonaTarifa == "local")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                            // Tarifa regional
                            if (RetiroPaquete.RetiroRegion == EntregaPaquete.EntregaRegion)
                            {
                                // Tarifa Provincial
                                if (RetiroPaquete.RetiroProvincia == EntregaPaquete.EntregaProvincia)
                                {
                                    if (tarifas[i].ZonaTarifa == "provincial")
                                    {
                                        tarifaPaquete += tarifas[i].PrecioTarifa;
                                        break;
                                    }
                                }
                                // Tarifa Regional
                                else
                                {
                                    if (tarifas[i].ZonaTarifa == "regional")
                                    {
                                        tarifaPaquete += tarifas[i].PrecioTarifa;
                                        break;
                                    }
                                }
                            }
                            else
                            //Tarifa Nacional
                            {
                                if (tarifas[i].ZonaTarifa == "nacional")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                        }

                    }
                }

                // ENTREGA INTERNACIONAL
                if (EntregaPaquete.EntregaPais != "argentina")
                {
                    // Tarifa hasta CABA
                    if (TipoPaquete == "Correspondencia" && tarifas[i].EnvioTarifa == "nacional" && tarifas[i].PaqueteTarifa == "correspondencia")
                    {
                        // Tarifa Nacional
                        if (RetiroPaquete.RetiroRegion != "centro")
                        {
                            if (tarifas[i].ZonaTarifa == "nacional")
                            {
                                tarifaPaquete += tarifas[i].PrecioTarifa;
                                break;
                            }
                        }
                        else
                        {
                            // Tarifa Regional
                            if (RetiroPaquete.RetiroProvincia != "caba")
                            {
                                if (tarifas[i].ZonaTarifa == "regional")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                            else
                            {
                                // Tarifa Provincial
                                if (tarifas[i].ZonaTarifa == "provincial")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                        }
                    }
                    if (TipoPaquete == "Encomienda" && tarifas[i].EnvioTarifa == "nacional" && tarifas[i].PaqueteTarifa == "bulto10")
                    {
                        // Tarifa Nacional
                        if (RetiroPaquete.RetiroRegion != "centro")
                        {
                            if (tarifas[i].ZonaTarifa == "nacional")
                            {
                                tarifaPaquete += tarifas[i].PrecioTarifa;
                                break;
                            }
                        }
                        else
                        {
                            // Tarifa Regional
                            if (RetiroPaquete.RetiroProvincia != "caba")
                            {
                                if (tarifas[i].ZonaTarifa == "regional")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                            else
                            {
                                // Tarifa Provincial
                                if (tarifas[i].ZonaTarifa == "provincial")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                        }
                    }
                    if (TipoPaquete == "Encomienda" && tarifas[i].EnvioTarifa == "nacional" && tarifas[i].PaqueteTarifa == "bulto20")
                    {
                        // Tarifa Nacional
                        if (RetiroPaquete.RetiroRegion != "centro")
                        {
                            if (tarifas[i].ZonaTarifa == "nacional")
                            {
                                tarifaPaquete += tarifas[i].PrecioTarifa;
                                break;
                            }
                        }
                        else
                        {
                            // Tarifa Regional
                            if (RetiroPaquete.RetiroProvincia != "caba")
                            {
                                if (tarifas[i].ZonaTarifa == "regional")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                            else
                            {
                                // Tarifa Provincial
                                if (tarifas[i].ZonaTarifa == "provincial")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                        }
                    }
                    if (TipoPaquete == "Encomienda" && tarifas[i].EnvioTarifa == "nacional" && tarifas[i].PaqueteTarifa == "bulto30")
                    {
                        // Tarifa Nacional
                        if (RetiroPaquete.RetiroRegion != "centro")
                        {
                            if (tarifas[i].ZonaTarifa == "nacional")
                            {
                                tarifaPaquete += tarifas[i].PrecioTarifa;
                                break;
                            }
                        }
                        else
                        {
                            // Tarifa Regional
                            if (RetiroPaquete.RetiroProvincia != "caba")
                            {
                                if (tarifas[i].ZonaTarifa == "regional")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                            else
                            {
                                // Tarifa Provincial
                                if (tarifas[i].ZonaTarifa == "provincial")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                        }
                    }

                    // Resto de la Tarifa Internacional
                    if (tarifas[i].EnvioTarifa == "internacional")
                    {
                        if (EntregaPaquete.EntregaPaisRegion == "pais limitrofe" && tarifas[i].ZonaTarifa == "limitrofe")
                        {
                            if (TipoPaquete == "Correspondencia" && tarifas[i].PaqueteTarifa == "correspondencia")
                            {
                                tarifaPaquete += tarifas[i].PrecioTarifa;
                                break;
                            }
                            if (TipoPaquete == "Encomienda")
                            {
                                if (PesoPaquete == "Bultos hasta 10Kg" && tarifas[i].PaqueteTarifa == "bulto10")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                                if (PesoPaquete == "Bultos hasta 20Kg" && tarifas[i].PaqueteTarifa == "bulto20")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                                if (PesoPaquete == "Bultos hasta 30Kg" && tarifas[i].PaqueteTarifa == "bulto30")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                        }
                        if (EntregaPaquete.EntregaPaisRegion == "america latina" && tarifas[i].ZonaTarifa == "latina")
                        {
                            if (TipoPaquete == "Correspondencia" && tarifas[i].PaqueteTarifa == "correspondencia")
                            {
                                tarifaPaquete += tarifas[i].PrecioTarifa;
                                break;
                            }
                            if (TipoPaquete == "Encomienda")
                            {
                                if (PesoPaquete == "Bultos hasta 10Kg" && tarifas[i].PaqueteTarifa == "bulto10")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                                if (PesoPaquete == "Bultos hasta 20Kg" && tarifas[i].PaqueteTarifa == "bulto20")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                                if (PesoPaquete == "Bultos hasta 30Kg" && tarifas[i].PaqueteTarifa == "bulto30")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                        }
                        if (EntregaPaquete.EntregaPaisRegion == "america del norte" && tarifas[i].ZonaTarifa == "norte")
                        {
                            if (TipoPaquete == "Correspondencia" && tarifas[i].PaqueteTarifa == "correspondencia")
                            {
                                tarifaPaquete += tarifas[i].PrecioTarifa;
                                break;
                            }
                            if (TipoPaquete == "Encomienda")
                            {
                                if (PesoPaquete == "Bultos hasta 10Kg" && tarifas[i].PaqueteTarifa == "bulto10")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                                if (PesoPaquete == "Bultos hasta 20Kg" && tarifas[i].PaqueteTarifa == "bulto20")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                                if (PesoPaquete == "Bultos hasta 30Kg" && tarifas[i].PaqueteTarifa == "bulto30")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                        }
                        if (EntregaPaquete.EntregaPaisRegion == "europa" && tarifas[i].ZonaTarifa == "europa")
                        {
                            if (TipoPaquete == "Correspondencia" && tarifas[i].PaqueteTarifa == "correspondencia")
                            {
                                tarifaPaquete += tarifas[i].PrecioTarifa;
                                break;
                            }
                            if (TipoPaquete == "Encomienda")
                            {
                                if (PesoPaquete == "Bultos hasta 10Kg" && tarifas[i].PaqueteTarifa == "bulto10")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                                if (PesoPaquete == "Bultos hasta 20Kg" && tarifas[i].PaqueteTarifa == "bulto20")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                                if (PesoPaquete == "Bultos hasta 30Kg" && tarifas[i].PaqueteTarifa == "bulto30")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                        }
                        if (EntregaPaquete.EntregaPaisRegion == "asia" && tarifas[i].ZonaTarifa == "asia")
                        {
                            if (TipoPaquete == "Correspondencia" && tarifas[i].PaqueteTarifa == "correspondencia")
                            {
                                tarifaPaquete += tarifas[i].PrecioTarifa;
                                break;
                            }
                            if (TipoPaquete == "Encomienda")
                            {
                                if (PesoPaquete == "Bultos hasta 10Kg" && tarifas[i].PaqueteTarifa == "bulto10")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                                if (PesoPaquete == "Bultos hasta 20Kg" && tarifas[i].PaqueteTarifa == "bulto20")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                                if (PesoPaquete == "Bultos hasta 30Kg" && tarifas[i].PaqueteTarifa == "bulto30")
                                {
                                    tarifaPaquete += tarifas[i].PrecioTarifa;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (TipoEnvio == "Envio urgente")
            {
                // Cargo fijo por envio urgente.
                double t = 0;
                t = (tarifaPaquete * 1.5);
                if (t <= 15000)
                {
                    tarifaPaquete += t;
                }
                else
                {
                    tarifaPaquete += 15000;
                }
            }
            TarifaPaqueteNacional = tarifaPaquete;
        }
    }
}