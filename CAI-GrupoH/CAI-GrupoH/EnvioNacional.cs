using System.Reflection.Metadata.Ecma335;

namespace CAIGrupoH
{
    internal class EnvioNacional
    {
        public string? TipoPaquete { get; set; }
        public string? PesoPaquete { get; set; }
        public string? TipoEnvio { get; set; }
        public int? TarifaPaqueteNacional { get; set; }
        public string? OrdenDeServicio { get; set; }

        Region RetiroPaquete = new Region();
        Region EntregaPaquete = new Region();

        public static EnvioNacional Ingresar()
        {
            var envioNacional = new EnvioNacional();
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
                    Console.WriteLine("No implementado.");
                    //tipoPaquete = "Correspondencia";
                }

                envioNacional.TipoPaquete = tipoPaquete;
                break;
            }

            if (envioNacional.TipoPaquete == "Correspondencia")
            {
                string pesoEncomienda = "Correspondencia hasta 500g";
                envioNacional.PesoPaquete = pesoEncomienda;
            }

            //No implementado
            if (envioNacional.TipoPaquete == "Encomienda")
            {
                Console.WriteLine("No implementado.");
                System.Environment.Exit(0);
                /*
                    string pesoEncomienda = "";
                    int menuPrincipal = Validaciones.ValidarMenuPrincipal("Seleccione el peso del paquete a enviar: ", "1. Bultos hasta 10Kg. \n 2. Bultos hasta 20Kg.\n 3. Bultos hasta 30Kg.", 1, 3);

                    switch (menuPrincipal)
                    {
                        case 1:
                            {
                                pesoEncomienda = "Bultos hasta 10Kg.";
                                break;
                            }
                        case 2:
                            {
                                pesoEncomienda = "Bultos hasta 20Kg.";
                                break;
                            }
                        case 3:
                            {
                                pesoEncomienda = "Bultos hasta 30Kg.";
                                break;
                            }
                    }
                    envioNacional.PesoPaquete = pesoEncomienda;
                */
            }

            do
            {
                int menuTipoEnvio = Validaciones.ValidarMenuPrincipal("Seleccione el tipo de envío:", "1. Envío urgente: 48hs.\n2. Envío normal.", 1, 2);
                string tipoEnvio = "";
                if (menuTipoEnvio == 1)
                {
                    //No implemetado
                    Console.WriteLine("No implementado.");
                    System.Environment.Exit(0);
                    //tipoEnvio = "Envío urgente";
                }
                if (menuTipoEnvio == 2)
                {
                    tipoEnvio = "Envio normal";
                }
                envioNacional.TipoEnvio = tipoEnvio;
                break;
            } while (true);

            // Origen del paquete (en puerta o presentacion en sucursal).
            // Traigo info de la recepcion del paquete.
            var retiroPaquete = Region.RetiroPaquete();
            envioNacional.RetiroPaquete = retiroPaquete;

            // Destino del paquete (en puerta o presentacion en sucursal).
            // Traigo info de la entrega del paquete
            var entregaPaquete = Region.EntregaPaquete();
            envioNacional.EntregaPaquete = entregaPaquete;


            //Calculo de las tarifas
            /* No implementado:
 *              - Encomiendas --> 10k, 20kg, 30kg.
 *              - Retiro en puerta.
 *              - Entrega en puerta.
 *              - Envio rapido.
            */
            int tarifaPaquete = 0;

            if (envioNacional.RetiroPaquete.TipoRecepcion == "Retiro en sucursal")
            {
                // Cargo fijo por retiro en sucursal..
                tarifaPaquete += 100;
            }
            if (envioNacional.RetiroPaquete.RetiroRegion != envioNacional.EntregaPaquete.EntregaRegion)
            {
                // Tarifa extra por entega interegional.
                tarifaPaquete += 500;
            }
            // No implementado
            /*
            else
            {
                if(envioNacional.RetiroPaquete.RetiroProvincia != envioNacional.EntregaPaquete.EntregaProvincia)
                {
                    // Tarifa extra por entrega interprovincial.
                    tarifaPaquete += 300;
                }
                else
                {
                    // Tarifa extra por entrega provincial.
                    tarifaPaquete += 150; 
                }
            }
            */
            if (envioNacional.EntregaPaquete.TipoEntrega == "Retiro en sucursal")
            {
                // Cargo fijo por entrega en sucursal.
                tarifaPaquete += 100;
            }

            envioNacional.TarifaPaqueteNacional = tarifaPaquete;


            // Crear orden de servicio
            // Generamos numero aleatorio
            /*
             * Revisar --> no funciona
            Random orden() = new Random();
            int sigOrdenDeServicio = orden.Next(1, 10);
            */
            //Hardcodeado
            int sigOrdenDeServicio = 100;

            // Asignamos nueva orden al envio nacional.
            envioNacional.OrdenDeServicio = sigOrdenDeServicio.ToString();

            // Mostramos en pantalla el envio al detalle: --> esto lo podemos modularizar despues.
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Numero de Orden: {envioNacional.OrdenDeServicio}\n");
            Console.WriteLine("Tipo de Envio: Nacional\n");
            Console.WriteLine($"Tipo de Paquete: {envioNacional.TipoPaquete}\n");
            Console.WriteLine($"Peso: {envioNacional.PesoPaquete}");
            Console.WriteLine($"Importe: ${envioNacional.TarifaPaqueteNacional.ToString()}");
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");

            // Confirmamos la orden
            int menuConfirmacion = Validaciones.ValidarMenuPrincipal("Desea confirmar la operación:", "\nPresione: 1 (Si) \nPresione: 2. (No)", 1, 2);
            if (menuConfirmacion == 2)
            {
                Console.WriteLine("Ha finalizado la operación.");
                System.Environment.Exit(0);
            }
            if (menuConfirmacion == 1)
            {
                Console.WriteLine("Ha generado su solicitud con éxito!\n Gracias por utilizar nuestros servicios!");

                /*
                 * No es necesario para el prototipo.
                //Creamos la orden
                OrdenDeServicio nuevaOrdenDeServicio = new OrdenDeServicio();
                // Asignamos todos los valores --> despues se puede modularizar
                nuevaOrdenDeServicio.NumeroCliente = "123456789";
                nuevaOrdenDeServicio.OrdenServicio = envioNacional.OrdenDeServicio;

                nuevaOrdenDeServicio.EstadoOrden = "Iniciada";

                nuevaOrdenDeServicio.PesoPaquete = envioNacional.PesoPaquete;
                nuevaOrdenDeServicio.TarifaPaqueteNacional = envioNacional.TarifaPaqueteNacional;

                nuevaOrdenDeServicio.TipoEnvio = envioNacional.TipoEnvio;

                nuevaOrdenDeServicio.RegionOrigen = envioNacional.RetiroPaquete.RetiroRegion;
                nuevaOrdenDeServicio.ProvinciaOrigen = envioNacional.RetiroPaquete.RetiroProvincia;
                nuevaOrdenDeServicio.LocalidadOrigen = envioNacional.RetiroPaquete.RetiroLocalidad;
                nuevaOrdenDeServicio.TipoRecepcion = envioNacional.RetiroPaquete.TipoRecepcion;
                nuevaOrdenDeServicio.SucursalOrigen = envioNacional.RetiroPaquete.RetiroSucursal;

                nuevaOrdenDeServicio.RegionEntrega = envioNacional.EntregaPaquete.EntregaRegion;
                nuevaOrdenDeServicio.ProvinciaEntrega = envioNacional.EntregaPaquete.EntregaProvincia;
                nuevaOrdenDeServicio.LocalidadEntrega = envioNacional.EntregaPaquete.EntregaLocalidad;
                nuevaOrdenDeServicio.TipoEntrega = envioNacional.EntregaPaquete.TipoEntrega;
                nuevaOrdenDeServicio.SucursalEntrega = envioNacional.EntregaPaquete.EntregaSucursal;

                // Agregamos orden a Lista de ordenes de servicio
                nuevaOrdenDeServicio.ListaOrdenesDeServicio(nuevaOrdenDeServicio);
                */

            }

            return envioNacional;
        }

    }
}