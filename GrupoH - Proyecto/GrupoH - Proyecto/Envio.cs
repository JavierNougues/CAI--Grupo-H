namespace CAIGrupoH
{
    internal class Envio
    {
        public string? TipoPaquete { get; set; }
        public string? PesoPaquete { get; set; }
        public string? TipoEnvio { get; set; }
        public int? TarifaPaqueteNacional { get; set; }
        public string? OrdenDeServicio { get; set; }

        Region RetiroPaquete = new Region();
        Region EntregaPaquete = new Region();

        public static Envio Ingresar()
        {
            Console.Clear();

            var envioNacional = new Envio();
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

                envioNacional.TipoPaquete = tipoPaquete;
                break;
            }

            if (envioNacional.TipoPaquete == "Correspondencia")
            {
                string pesoEncomienda = "Correspondencia hasta 500g";
                envioNacional.PesoPaquete = pesoEncomienda;
            }

            Console.Clear();
            if (envioNacional.TipoPaquete == "Encomienda")
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
                envioNacional.PesoPaquete = pesoEncomienda;
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
                envioNacional.TipoEnvio = tipoEnvio;
                break;
            } while (true);

            /***************************************************************/
            // Origen del paquete (en puerta o presentacion en sucursal).
            // Traigo info del retiro del paquete.
            var retiroPaquete = Region.RetiroPaquete();
            envioNacional.RetiroPaquete = retiroPaquete;

            // Destino del paquete (en puerta o presentacion en sucursal).
            // Traigo info de la entrega del paquete
            var entregaPaquete = Region.EntregaPaquete();
            envioNacional.EntregaPaquete = entregaPaquete;
            /***************************************************************/

            /***************************************************************/
            //Calculo de las tarifas
            int tarifaPaquete = 0;

            if (envioNacional.TipoEnvio == "Envio normal")
            {
                // Cargo fijo por envio normal.
                tarifaPaquete += 200;
            }
            if (envioNacional.TipoEnvio == "Envio urgente")
            {
                // Cargo fijo por envio urgente.
                tarifaPaquete += 400;
            }

            if (envioNacional.RetiroPaquete.TipoRecepcion == "Retiro en sucursal")
            {
                // Cargo fijo por retiro en sucursal..
                tarifaPaquete += 100;
            }
            if (envioNacional.RetiroPaquete.TipoRecepcion == "Retiro en puerta")
            {
                // Cargo fijo por retiro en puerta.
                tarifaPaquete += 400;
            }


            else
            {
                if (envioNacional.RetiroPaquete.RetiroProvincia != envioNacional.EntregaPaquete.EntregaProvincia)
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
            if (envioNacional.EntregaPaquete.TipoEntrega == "Retiro en sucursal")
            {
                // Cargo fijo por entrega en sucursal.
                tarifaPaquete += 100;
            }
            if (envioNacional.EntregaPaquete.TipoEntrega == "Entrega en puerta")
            {
                // Cargo fijo por entrega en puerta.
                tarifaPaquete += 400;
            }

            if (envioNacional.PesoPaquete == "Bultos hasta 10Kg")
            {
                // Cargo fijo por bulto de 10kg.
                tarifaPaquete += 700;
            }
            if (envioNacional.PesoPaquete == "Bultos hasta 20Kg")
            {
                // Cargo fijo por bulto de 20kg.
                tarifaPaquete += 900;
            }
            if (envioNacional.PesoPaquete == "Bultos hasta 30Kg")
            {
                // Cargo fijo por bulto de 30kg.
                tarifaPaquete += 1100;
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
            String sigOrdenDeServicio = "N100";

            // Asignamos nueva orden al envio nacional.
            envioNacional.OrdenDeServicio = sigOrdenDeServicio.ToString();

            // Mostramos en pantalla el envio al detalle: --> esto lo podemos modularizar despues.
            Console.Clear();
            Console.Write("---------------------------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("Envio Nacional\n");
            Console.WriteLine($"Numero de Orden: {envioNacional.OrdenDeServicio.ToUpper()}\n");
            Console.WriteLine($"Peso Paquete: {envioNacional.PesoPaquete.ToUpper()}\n");
            Console.WriteLine($"Importe: ${envioNacional.TarifaPaqueteNacional.ToString()}\n");
            Console.WriteLine($"Tipo Envío: {envioNacional.TipoEnvio.ToUpper()}\n\n");

            Console.Write("Origen del Paquete: \n");
            Console.WriteLine($"Tipo de Retiro: {envioNacional.RetiroPaquete.TipoRecepcion.ToUpper()}\n");
            Console.WriteLine($"Provincia de Retiro: {envioNacional.RetiroPaquete.RetiroProvincia.ToUpper()}\n");
            Console.WriteLine($"Localidad de Retiro: {envioNacional.RetiroPaquete.RetiroLocalidad.ToUpper()}\n");
            if (envioNacional.RetiroPaquete.RetiroSucursal != null)
            {
                Console.WriteLine($"Sucursal de Retiro: {envioNacional.RetiroPaquete.RetiroSucursal.ToUpper()}\n \n");
            }


            Console.Write("Destino del Paquete: \n");
            Console.WriteLine($"Tipo de Entrega: {envioNacional.EntregaPaquete.TipoEntrega.ToUpper()}\n");
            Console.WriteLine($"Provincia de Entrega: {envioNacional.EntregaPaquete.EntregaProvincia.ToUpper()}\n");
            Console.WriteLine($"Localidad de Entrega: {envioNacional.EntregaPaquete.EntregaLocalidad.ToUpper()}\n");
            if (envioNacional.EntregaPaquete.EntregaSucursal != null)
            {
                Console.WriteLine($"Sucursal de Entrega: {envioNacional.EntregaPaquete.EntregaSucursal.ToUpper()}\n");
            }
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");

            // Confirmamos la orden
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
            Console.Clear();
            return envioNacional;
        }
    }
}