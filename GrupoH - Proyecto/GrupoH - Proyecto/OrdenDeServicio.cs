using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GrupoH___Proyecto;

namespace CAIGrupoH
{
    internal class OrdenDeServicio
    {
        //Propiedades
        public DateTime? FechaOS { get; set; }
        public string? NumeroCliente { get; set; }
        public string? NombreCliente { get; set; }
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


        const string maestroOrdenesServicio = "maestroordenesservicio.txt";

        List<OrdenDeServicio> ordenesDeServicio = new List<OrdenDeServicio>();

        public OrdenDeServicio(string linea)
        {
            var datos = linea.Split('|');
            NroOrdenServicio = datos[0];
            NumeroCliente = datos[1];
            FechaOS = DateTime.Parse(datos[2]);
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

            NombreCliente = datos[20];
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
                nuevaSW.WriteLine(OS.NroOrdenServicio + "|" + OS.NumeroCliente + "|" + OS.FechaOS + "|" + OS.EstadoOrden + "|" + OS.TipoEnvio + "|"
                    + OS.PesoPaquete + "|" + OS.Tarifa + "|" + OS.TipoRecepcion + "|" + OS.RetiroProvincia + "|" + OS.RetiroLocalidad + "|"
                    + OS.RetiroDireccion + "|" + OS.RetiroDireccionNumero + "|" + OS.RetiroSucursal + "|" + OS.TipoEntrega + "|"
                    + OS.EntregaPais + "|" + OS.EntregaProvincia + "|" + OS.EntregaLocalidad + "|" + OS.EntregaDireccion + "|" + OS.EntregaDireccion + "|"
                    + OS.EntregaDireccionNumero + "|" + OS.EntregaSucursal + "|" + OS.NombreCliente);
            }

            nuevaSW.Close();
            Console.WriteLine("La 'Orden de Servicio' se guardó correctamente en el archivo.");
        }

        public static OrdenDeServicio ConsultarEstadoOrden()
        {
            var consultarOS = new OrdenDeServicio();

            Console.Clear();

            consultarOS.LeerMaestroOrdenes();
            string numeroOrden;
            var numeroOSIngresado = Validaciones.ValidarIntIngresado("Ingrese el 'Número de Orden de Servicio:");
            numeroOrden = numeroOSIngresado.ToString();
            consultarOS.MostrarOrdenServicio(numeroOrden);
            return consultarOS;
        }

        public void MostrarOrdenServicio(string numeroOrden)
        {

            Dictionary<string, string> auxOrdenes = new Dictionary<string, string>();
            bool encontrado = false;
            for (int i = 0; i < ordenesDeServicio.Count; i++)
            {
                if (ordenesDeServicio[i].NroOrdenServicio == numeroOrden)
                {
                    encontrado = auxOrdenes.ContainsKey(ordenesDeServicio[i].NroOrdenServicio);
                    if (!encontrado)
                    {
                        auxOrdenes.Add(ordenesDeServicio[i].NroOrdenServicio, ordenesDeServicio[i].EstadoOrden);
                    }
                }
            }
            if (!auxOrdenes.ContainsKey(numeroOrden))
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("El 'Número de Orden de Servicio' ingresado es incorrecto.");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Gracias por utilizar nuestros servicios.");
                Console.WriteLine("Ingrese cualquier tecla para continuar.");
                Console.ReadKey();
            }

            foreach (var item in auxOrdenes)
            {
                Console.Clear();
                Console.WriteLine("|Número de Orden| \t|Estado|");
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
                Console.WriteLine("");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Gracias por utilizar nuestros servicios.");
                Console.WriteLine("Ingrese cualquier tecla para continuar.");
                Console.ReadKey();
            }
        }

        public void MostrarOSPendientesFacturar(string codCliente)
        {
            bool OSPendiente = false;
            Console.WriteLine("Fecha \t\t\tNúmero Orden de Servicio  \tEstado \t\tMonto");
            for (int i = 0; i < ordenesDeServicio.Count; i++)
            {
                if (ordenesDeServicio[i].NumeroCliente == codCliente)
                {
                    Console.WriteLine($"{ordenesDeServicio[i].FechaOS} \t\t{ordenesDeServicio[i].NroOrdenServicio} \t\t\t{ordenesDeServicio[i].EstadoOrden} \t{ordenesDeServicio[i].Tarifa}");
                    OSPendiente = true;
                }
                else
                {
                    OSPendiente = false;
                }
            }
            if (OSPendiente == false)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("No se encontraron 'Ordenes Pendientes de Facturar'");
                Console.WriteLine("------------------------------------------------------");
            }
        }
    }
}