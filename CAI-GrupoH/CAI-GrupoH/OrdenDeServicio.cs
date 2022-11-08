namespace CAIGrupoH
{
    internal class OrdenDeServicio
    {
        //Propiedades
        public string? NumeroCliente { get; set; }
        public string? OrdenServicio { get; set; }
        public string? EstadoOrden { get; set; }  
        public string? PesoPaquete { get; set; }
        public int? TarifaPaqueteNacional { get; set; }
        public string? TipoEnvio { get; set; }

        public string? RegionOrigen { get; set; }
        public string? ProvinciaOrigen { get; set; }
        public string? LocalidadOrigen { get; set; }
        public string? TipoRecepcion { get; set; }
        public string? SucursalOrigen { get; set; }

        public string? RegionEntrega { get; set; }
        public string? ProvinciaEntrega { get; set; }
        public string? LocalidadEntrega { get; set; }
        public string? TipoEntrega { get; set; }
        public string? SucursalEntrega { get; set; }

        List<OrdenDeServicio> ordenesDeServicio = new List<OrdenDeServicio>();

        public void AgregarOrdenesDeServicio(OrdenDeServicio nuevaOrdenDeServicio)
        {
            ordenesDeServicio.Add(nuevaOrdenDeServicio);
        }

        public static OrdenDeServicio MostrarOrden()
        {
            var ordenMostrar = new OrdenDeServicio();
            string ordenIngresada;
            do
            {
                Console.WriteLine("Ingrese la Orden de Servicio:");
                ordenIngresada = Console.ReadLine().ToLower();
                if (ordenIngresada == "n100" || ordenIngresada == "i100")
                {
                    ordenMostrar.ImprimirOrdenDeServicio(ordenIngresada);
                    Console.WriteLine("Gracias por utilizar nuestros servicios.");
                }
                else
                {

                    Console.WriteLine("Orden de Servicio inválida. Intente nuevamente: ");
                    ordenIngresada = Console.ReadLine();
                    continue;
                }
                break;
            } while (true);


            return ordenMostrar;
        }

        public void ImprimirOrdenDeServicio(string ordenDeServicio)
        {
            Console.Clear();
            foreach (var orden in ordenesDeServicio)
            {
                Console.WriteLine(orden);
                /*
                        Console.WriteLine($"Orden de Servicio: {orden.OrdenServicio}\n");
                        Console.WriteLine($"Estado de Orden: {orden.EstadoOrden}\n");
                        Console.WriteLine($"Peso de Paquete: {orden.PesoPaquete}\n");
                        Console.WriteLine($"Envio: {orden.TarifaPaqueteNacional}\n");
                        Console.WriteLine($"Tipo de Envio: {orden.TipoEnvio}\n");
                        Console.WriteLine($"Region de Origen: {orden.RegionOrigen}\n");
                        Console.WriteLine($"Provincia de Origen: {orden.ProvinciaOrigen}\n");
                        Console.WriteLine($"Localidad de Origen: {orden.LocalidadOrigen} \n");
                        Console.WriteLine($"Retiro de Paquete: {orden.TipoRecepcion} \n");
                        Console.WriteLine($"Sucursal de Origen: {orden.SucursalOrigen} \n");
                        Console.WriteLine($"Region de Entrega: {orden.RegionEntrega} \n");
                        Console.WriteLine($"Provincia de Entrega: {orden.ProvinciaEntrega} \n");
                        Console.WriteLine($"Localidad de Entrega: {orden.LocalidadEntrega} \n");
                        Console.WriteLine($"Tipo de Entrega: {orden.TipoEntrega} \n");
                        Console.WriteLine($"Sucursal de Entrega: {orden.SucursalEntrega} \n");
                */
                Console.WriteLine("***************************************************************************************");

            }
            Console.WriteLine("Ingrese cualquier tecla para continuar");
            Console.ReadKey();

        }




    }
}