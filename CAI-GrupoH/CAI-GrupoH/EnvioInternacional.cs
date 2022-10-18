namespace CAIGrupoH
{
    internal class EnvioInternacional
    {
        public string? TipoPaquete { get; set; }
        public string? PesoPaquete { get; set; }
        public int   TarifaPaqueteInternacional { get; set; }

        RegionInternacional RetiroPaqueteInternacional = new RegionInternacional();
        RegionInternacional EntregaPaqueteInternacional = new RegionInternacional();

        public static EnvioInternacional Ingresar()
        {
            var envioInternacional = new EnvioInternacional();

            Console.WriteLine("Nuevo Envío Internacional: ");
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

                envioInternacional.TipoPaquete = tipoPaquete;
                break;
            }

            if (envioInternacional.TipoPaquete == "Correspondencia")
            {
                string pesoEncomienda = "Correspondencia hasta 500g";
                envioInternacional.PesoPaquete = pesoEncomienda;
            }

            //No implementado
            if (envioInternacional.TipoPaquete == "Encomienda")
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

            // Origen del paquete (en puerta o presentacion en sucursal).
            // Traigo info de la recepcion internacional.
            var retiroPaquete = RegionInternacional.RetiroPaqueteInternacional();
            envioInternacional.RetiroPaqueteInternacional = retiroPaquete;

            // Destino del paquete (presentacion en sucursal).
            // Traigo info de la entrega internacional.
            var entregaPaquete = RegionInternacional.EntregaPaqueteInternacional();
            envioInternacional.EntregaPaqueteInternacional = entregaPaquete;


            //Calculo de las tarifas
            /* No implementado:
 *              - Encomiendas --> 10k, 20kg, 30kg.
 *              - Retiro en puerta.
            */
            int tarifaPaqueteInternacional = 0;

            if (envioInternacional.RetiroPaqueteInternacional.TipoRecepcionInternacional == "Retiro en sucursal")
            {
                // Cargo fijo por retiro en sucursal..
                tarifaPaqueteInternacional += 100;
            }
            if (envioInternacional.EntregaPaqueteInternacional.EntregaRegionInternacional == "Europa")
            {
                // Cargo por entrega a Europa.
                tarifaPaqueteInternacional += 30000;
            }

            envioInternacional.TarifaPaqueteInternacional = tarifaPaqueteInternacional;

           
            return envioInternacional;
        }
    }
}