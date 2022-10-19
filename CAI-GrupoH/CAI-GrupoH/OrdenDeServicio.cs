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

        public void ListaOrdenesDeServicio(OrdenDeServicio nuevaOrdenDeServicio)
        {
            ordenesDeServicio.Add(nuevaOrdenDeServicio);
        }
    }
}