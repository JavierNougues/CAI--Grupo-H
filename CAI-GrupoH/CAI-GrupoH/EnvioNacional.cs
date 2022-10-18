using System.Reflection.Metadata.Ecma335;

namespace CAIGrupoH
{
    internal class EnvioNacional
    {
        public string? TipoPaquete { get; set; }
        public string? PesoPaquete { get; set; }
        public string? TipoEnvio { get; set; }
        public int? TarifaPaqueteNacional { get; set; }

        Region RetiroPaquete = new Region();
        Region EntregaPaquete = new Region();

        public static EnvioNacional Ingresar()
        {
            var envioNacional = new EnvioNacional();
            Console.WriteLine("Nuevo Envío Nacional: ");
            while (true)
            {
                string tipoPaquete = "";
                int menuPrincipal = Validaciones.ValidarMenuPrincipal("Seleccione el tipo de paquete: ", "1. Correspondencia: hasta 500gr. \n 2. Encomienda: hasta 30kg.", 1, 2);

                if (menuPrincipal == 1)
                {
                    tipoPaquete = "Correspondencia";
                }
                if (menuPrincipal == 2)
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
                int menuPrincipal = Validaciones.ValidarMenuPrincipal("Seleccione el tipo de envío:", "1. Envío urgente: 48hs. \n2. Envío normal.", 1, 2);
                string tipoEnvio = "";
                if (menuPrincipal == 1)
                {
                    //No implemetado
                    Console.WriteLine("No implementado.");
                    //tipoEnvio = "Envío urgente";
                }
                if (menuPrincipal == 2)
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
            if(envioNacional.RetiroPaquete.RetiroRegion != envioNacional.EntregaPaquete.EntregaRegion)
            {
                // Tarifa extra por entega interegional.
                tarifaPaquete += 500;
            }
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
            if(envioNacional.EntregaPaquete.TipoEntrega == "Retiro en sucursal")
            {
                // Cargo fijo por entrega en sucursal.
                tarifaPaquete += 100;
            }

            envioNacional.TarifaPaqueteNacional = tarifaPaquete;

            return envioNacional;
        }

        

    }
}