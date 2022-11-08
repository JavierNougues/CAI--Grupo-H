namespace CAIGrupoH
{
    internal class OrdenDeServicio
    {
        //Propiedades
        public DateTime? Fecha { get; set; }
        public string? NumeroCliente { get; set; }
        public string? NroOrdenServicio { get; set; }
        public string? EstadoOrden { get; set; }
        public string? TipoEnvio { get; set; }
        public string? PesoPaquete { get; set; }
        public string? Tarifa { get; set; }
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


        const string maestroOrdenesServicio = "maestroOrdenesServicio.txt";

        List<OrdenDeServicio> ordenesDeServicio = new List<OrdenDeServicio>();

        public OrdenDeServicio(string linea)
        {
            var datos = linea.Split('|');
            NroOrdenServicio = datos[0];
            NumeroCliente = datos[1];
            Fecha = DateTime.Parse(datos[2]);
            EstadoOrden = datos[3];
            TipoEnvio = datos[4];
            PesoPaquete = datos[5];
            Tarifa = datos[6];

            TipoRecepcion = datos[7];
            RetiroProvincia = datos[8];
            RetiroLocalidad = datos[9];
            RetiroDireccion = datos[10];
            RetiroDireccionNumero = datos[11];
            RetiroSucursal = datos[12];

            TipoEntrega = datos[13];
            EntregaPais = datos[14];
            EntregaProvincia = datos[15];
            EntregaLocalidad = datos[16];
            EntregaDireccion = datos[17];
            EntregaDireccionNumero = datos[18];
            EntregaSucursal = datos[19];
        }


        public OrdenDeServicio()
        {

        }

        public void LeerMaestroOrdenes()
        {
            if (File.Exists(maestroOrdenesServicio))
            {
                using (var reader = new StreamReader(maestroOrdenesServicio))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();

                        var orden = new OrdenDeServicio(linea);
                        ordenesDeServicio.Add(orden);
                    }
                }
            }
        }

        public void AgregarOrdenDeServicio(OrdenDeServicio nuevaOS)
        {
            ordenesDeServicio.Add(nuevaOS);
        }

        public void GuardarOrdenDeServicio()
        {

            StreamWriter nuevaSW = new StreamWriter(maestroOrdenesServicio);

            foreach (OrdenDeServicio OS in ordenesDeServicio)
            {
                nuevaSW.WriteLine(OS.NroOrdenServicio + "|" + OS.NumeroCliente + "|" + OS.Fecha + "|" + OS.EstadoOrden + "|" + OS.TipoEnvio + "|"
                    + OS.PesoPaquete + "|" + OS.Tarifa + "|" + OS.TipoRecepcion + "|" + OS.RetiroProvincia + "|" + OS.RetiroLocalidad + "|"
                    + OS.RetiroDireccion + "|" + OS.RetiroDireccionNumero + "|" + OS.RetiroSucursal + "|" + OS.TipoEntrega + "|"
                    + OS.EntregaPais + "|" + OS.EntregaProvincia + "|" + OS.EntregaLocalidad + "|" + OS.EntregaDireccion + "|" + OS.EntregaDireccion + "|"
                    + OS.EntregaDireccionNumero + "|" + OS.EntregaSucursal);
            }

            nuevaSW.Close();
            Console.WriteLine("La Orden de Servicio se guardó correctamente.");
        }

        public static OrdenDeServicio ConsultarEstadoOrden()
        {
            var consultarOS = new OrdenDeServicio();

            consultarOS.LeerMaestroOrdenes();
            string numeroOrden;
            do
            {
                Console.WriteLine("Ingrese el 'Número de Orden de Servicio':");
                var numeroOSIngresado = Validaciones.ValidarIntIngresado("Ingrese el 'Número de Orden de Servicio:", 0, 9999999999);
                numeroOrden = numeroOSIngresado.ToString();
            } while (true);

            consultarOS.MostrarOrdenServicio(numeroOrden);
            Console.WriteLine("Gracias por utilizar nuestros servicios.");
            Console.WriteLine("Ingrese cualquier tecla para continuar");
            Console.ReadKey();
            return consultarOS;
        }

        public void MostrarOrdenServicio(string numeroOrden)
        {

            Dictionary<string, string> auxOrdenes = new Dictionary<string, string>();
            bool encontrado = false;
            foreach (var orden in ordenesDeServicio)
            {
                if (orden.NroOrdenServicio == numeroOrden)
                {
                    encontrado = auxOrdenes.ContainsKey(orden.NroOrdenServicio);
                    if (!encontrado)
                    {
                        auxOrdenes.Add(orden.NroOrdenServicio, orden.EstadoOrden);
                    }
                }
            }
            if (!auxOrdenes.ContainsKey(numeroOrden))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El 'Número de Orden de Servicio' ingresado es incorrecto.");
                Console.WriteLine("Ingrese cualquier tecla para continuar");
                Console.ReadKey();
            }

            foreach (var item in auxOrdenes)
            {
                Console.WriteLine($"{item.Key} \t\t{item.Value}");
            }
        }
    }
}