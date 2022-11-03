namespace CAIGrupoH
{
    internal class EnvioInternacional
    {
        public string? TipoPaquete { get; set; }
        public string? PesoPaquete { get; set; }
        public int? TarifaPaqueteInternacional { get; set; }

        public string? OrdenDeServicio { get; set; }

        RegionInternacional RetiroPaqueteInternacional = new RegionInternacional();
        RegionInternacional EntregaPaqueteInternacional = new RegionInternacional();

        public static EnvioInternacional Ingresar()
        {
            var envioInternacional = new EnvioInternacional();

            Console.WriteLine("Nuevo Envío Internacional: ");
            while (true)
            {
                string tipoPaquete = "";
                Console.Clear();
                int menuTipoPaquete = Validaciones.ValidarMenuPrincipal("Seleccione el tipo de paquete: ", "1. Correspondencia: hasta 500gr.\n2. Encomienda: hasta 30kg.", 1, 2);

                if (menuTipoPaquete == 1)
                {
                    tipoPaquete = "Correspondencia";
                }
                if (menuTipoPaquete == 2)
                {
                    tipoPaquete = "Correspondencia";
                }

                envioInternacional.TipoPaquete = tipoPaquete;
                break;
            }

            if (envioInternacional.TipoPaquete == "Correspondencia")
            {
                string pesoEncomienda = "Correspondencia hasta 500g";
                envioInternacional.PesoPaquete = pesoEncomienda;
            }

            if (envioInternacional.TipoPaquete == "Encomienda")
            {
                    string pesoEncomienda = "";
                    int menuPrincipal = Validaciones.ValidarMenuPrincipal("Seleccione el peso del paquete a enviar: ", "1. Bultos hasta 10Kg. \n2. Bultos hasta 20Kg. \n3. Bultos hasta 30Kg.", 1, 3);

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
                    envioInternacional.PesoPaquete = pesoEncomienda;
            }

            /***************************************************************/
            // Origen del paquete (en puerta o presentacion en sucursal).
            // Traigo info de la recepcion internacional.
            var retiroPaquete = RegionInternacional.RetiroPaqueteInternacional();
            envioInternacional.RetiroPaqueteInternacional = retiroPaquete;

            // Destino del paquete (presentacion en sucursal).
            // Traigo info de la entrega internacional.
            var entregaPaquete = RegionInternacional.EntregaPaqueteInternacional();
            envioInternacional.EntregaPaqueteInternacional = entregaPaquete;
            /***************************************************************/

            /***************************************************************/
            //Calculo de las tarifas
            int tarifaPaqueteInternacional = 0;

            if (envioInternacional.RetiroPaqueteInternacional.TipoRecepcionInternacional == "Retiro en sucursal")
            {
                // Cargo fijo por retiro en sucursal..
                tarifaPaqueteInternacional += 100;
            }
            if (envioInternacional.RetiroPaqueteInternacional.TipoRecepcionInternacional == "Retiro en puerta")
            {
                // Cargo fijo por retiro en puerta.
                tarifaPaqueteInternacional += 400;
            }
            if (envioInternacional.EntregaPaqueteInternacional.EntregaRegionInternacional == "Europa")
            {
                // Cargo por entrega a Europa.
                tarifaPaqueteInternacional += 30000;
            }

            if (envioInternacional.PesoPaquete == "Bultos hasta 10Kg")
            {
                // Cargo fijo por bulto de 10kg.
                tarifaPaqueteInternacional += 700;
            }
            if (envioInternacional.PesoPaquete == "Bultos hasta 20Kg")
            {
                // Cargo fijo por bulto de 20kg.
                tarifaPaqueteInternacional += 900;
            }
            if (envioInternacional.PesoPaquete == "Bultos hasta 30Kg")
            {
                // Cargo fijo por bulto de 30kg.
                tarifaPaqueteInternacional += 1100;
            }

            envioInternacional.TarifaPaqueteInternacional = tarifaPaqueteInternacional;

            //Hardcodeado
            String sigOrdenDeServicioInternacional = "I100";

            // Asignamos nueva orden al envio nacional.
            envioInternacional.OrdenDeServicio = sigOrdenDeServicioInternacional.ToString();

            // Mostramos en pantalla el envio al detalle: --> esto lo podemos modularizar despues.
            Console.Clear();
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Envio Internacional\n");
            Console.WriteLine($"Numero de Orden: {envioInternacional.OrdenDeServicio.ToUpper()}\n");
            Console.WriteLine($"Peso Paquete: {envioInternacional.PesoPaquete.ToUpper()}\n");
            Console.WriteLine($"Importe: ${envioInternacional.TarifaPaqueteInternacional.ToString()}\n\n");

            Console.Write("Origen del Paquete: \n");
            Console.WriteLine($"Tipo de Retiro: {envioInternacional.RetiroPaqueteInternacional.TipoRecepcionInternacional.ToUpper()}\n");
            Console.WriteLine($"Provincia de Retiro: {envioInternacional.RetiroPaqueteInternacional.RetiroProvinciaInternacional.ToUpper()}\n");
            Console.WriteLine($"Localidad de Retiro: {envioInternacional.RetiroPaqueteInternacional.RetiroLocalidadInternacional.ToUpper()}\n");
            if (envioInternacional.RetiroPaqueteInternacional.RetiroSucursalInternacional != null)
            {
                Console.WriteLine($"Sucursal de Retiro: {envioInternacional.RetiroPaqueteInternacional.RetiroSucursalInternacional.ToUpper()}\n \n");
            }


            Console.Write("Destino del Paquete: \n");
            Console.WriteLine($"Tipo de Entrega: {envioInternacional.EntregaPaqueteInternacional.TipoEntregaInternacional.ToUpper()}\n");
            Console.WriteLine($"Continente de Entrega: {envioInternacional.EntregaPaqueteInternacional.EntregaRegionInternacional.ToUpper()}\n");
            Console.WriteLine($"Pais de Entrega: {envioInternacional.EntregaPaqueteInternacional.EntregaPaisInternacional.ToUpper()}\n");
            Console.Write("---------------------------------------------------------------------------------------------------------------------------");

            // Confirmamos la orden
            int menuConfirmacion = Validaciones.ValidarMenuPrincipal("Desea confirmar la operación:", "\nPresione: 1 (Si) \nPresione: 2. (No)", 1, 2);
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
            }
            Console.Clear();
            return envioInternacional;
        }
    }
}