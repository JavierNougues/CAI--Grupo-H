namespace CAIGrupoH
{
    internal class Envio
    {
        public string? TipoPaquete { get; set; }
        public string? PesoPaquete { get; set; }
        public string? TipoEnvio { get; set; }
        public int? TarifaPaqueteNacional { get; set; }
        public string? OrdenDeServicio { get; set; }

        EnvioDetalle RetiroPaquete = new EnvioDetalle();
        EnvioDetalle EntregaPaquete = new EnvioDetalle();

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
            int tarifaPaquete = 0;

            if (nuevoEnvio.TipoEnvio == "Envio normal")
            {
                // Cargo fijo por envio normal.
                tarifaPaquete += 200;
            }
            if (nuevoEnvio.TipoEnvio == "Envio urgente")
            {
                // Cargo fijo por envio urgente.
                tarifaPaquete += 400;
            }

            if (nuevoEnvio.RetiroPaquete.TipoRecepcion == "Retiro en sucursal")
            {
                // Cargo fijo por retiro en sucursal..
                tarifaPaquete += 100;
            }
            if (nuevoEnvio.RetiroPaquete.TipoRecepcion == "Retiro en puerta")
            {
                // Cargo fijo por retiro en puerta.
                tarifaPaquete += 400;
            }
            else
            {
                if (nuevoEnvio.RetiroPaquete.RetiroProvincia != nuevoEnvio.EntregaPaquete.EntregaProvincia)
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

            if (nuevoEnvio.EntregaPaquete.EntregaPais != "argentina")
            {
                // Tarifa entrega internacional.
                tarifaPaquete += 500;
            }

            if (nuevoEnvio.EntregaPaquete.TipoEntrega == "Retiro en sucursal")
            {
                // Cargo fijo por entrega en sucursal.
                tarifaPaquete += 100;
            }
            if (nuevoEnvio.EntregaPaquete.TipoEntrega == "Entrega en puerta")
            {
                // Cargo fijo por entrega en puerta.
                tarifaPaquete += 400;
            }

            if (nuevoEnvio.PesoPaquete == "Bultos hasta 10Kg")
            {
                // Cargo fijo por bulto de 10kg.
                tarifaPaquete += 700;
            }
            if (nuevoEnvio.PesoPaquete == "Bultos hasta 20Kg")
            {
                // Cargo fijo por bulto de 20kg.
                tarifaPaquete += 900;
            }
            if (nuevoEnvio.PesoPaquete == "Bultos hasta 30Kg")
            {
                // Cargo fijo por bulto de 30kg.
                tarifaPaquete += 1100;
            }


            nuevoEnvio.TarifaPaqueteNacional = tarifaPaquete;


            // Crear orden de servicio
            // Generamos numero aleatorio
            var numeroOS = new Random();
            int sigOrdenDeServicio = numeroOS.Next(1, 10);

            // Asignamos nueva orden al envio nacional.
            nuevoEnvio.OrdenDeServicio = sigOrdenDeServicio.ToString();

            // Mostramos en pantalla el envio al detalle
            Console.Clear();
            Console.Write("---------------------------------------------------------------------------------------------------------------------------\n");
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
                Console.WriteLine($"Dirección de Retiro: {nuevoEnvio.RetiroPaquete.RetiroDireccion} ' ' {nuevoEnvio.RetiroPaquete.RetiroDireccionNumero}\n");
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
                    Console.WriteLine($"Dirección de Entrega: {nuevoEnvio.EntregaPaquete.EntregaDireccion} ' ' {nuevoEnvio.EntregaPaquete.EntregaDireccionNumero}\n");
                }
            }
            else
            {
                Console.WriteLine($"País de Entrega: {nuevoEnvio.EntregaPaquete.EntregaPais}\n");
                Console.WriteLine($"Dirección de Entrega: {nuevoEnvio.EntregaPaquete.EntregaDireccion} ' ' {nuevoEnvio.EntregaPaquete.EntregaDireccionNumero}\n");
                Console.WriteLine($"información Adicional: {nuevoEnvio.EntregaPaquete.EntregaInternacionalInfo}\n");
            }
            
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");


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
                //nuevaOS.NumeroCliente = ;
                nuevaOS.Fecha = DateTime.Today;
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
    }
}