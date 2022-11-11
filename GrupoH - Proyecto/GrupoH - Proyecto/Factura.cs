using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace GrupoH___Proyecto
{
    internal class Factura
    {
        //Propiedades
        public DateTime? FechaFactura { get; set; }
        public string? NumeroFactura { get; set; }
        public string? NumeroCliente { get; set; }
        public string? EstadoFactura { get; set; }
        public int? MontoFactura { get; set; }

        const string maestroFacturas = "C:\\Users\\javier.nougues@sap.com\\Documents\\GitHub\\CAI--Grupo-H\\GrupoH - Proyecto\\maestrofacturas.txt";

        public List<Factura> facturas = new List<Factura>();

        public Factura(string linea)
        {
            var datos = linea.Split('|');
            FechaFactura = DateTime.Parse(datos[0]);
            NumeroFactura = datos[1];
            NumeroCliente = datos[2];
            EstadoFactura = datos[2];
            MontoFactura = int.Parse(datos[3]);
        }
        public Factura()
        {

        }

        public void LeerMaestroFacturas()
        {
            if (File.Exists(maestroFacturas))
            {
                using (var reader = new StreamReader(maestroFacturas))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();

                        var factura = new Factura(linea);
                        facturas.Add(factura);
                    }
                }
            }
        }

        public void DesplegarFacturasCliente(string codCliente)
        {
            Console.Clear();
            Console.WriteLine("Fecha \t\tNúmero Factura  \t\tEstado \t\tMonto");
            for (int i = 0; i < facturas.Count; i++)
            {
                if (facturas[i].NumeroCliente == codCliente)
                {
                    Console.WriteLine($"{facturas[i].FechaFactura} \t\t{facturas[i].NumeroFactura} \t\t{facturas[i].EstadoFactura} \t\t{facturas[i].MontoFactura} ");
                }
                else
                {
                    Console.WriteLine("No se econtraron facturas emitidas.");
                    Console.WriteLine("Gracias por utilizar nuestros servicios.");
                    Console.WriteLine("Ingrese cualquier tecla para continuar.");
                    Console.ReadKey();
                }
            }
        }
        public void MostrarSaldoCliente(string codCliente)
        {
            Console.Clear();
            for (int i = 0; i < facturas.Count; i++)
            {

                if (codCliente == facturas[i].NumeroCliente && facturas[i].EstadoFactura == "Impaga")
                {
                    MontoFactura += facturas[i].MontoFactura;
                }
            }
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"Posee un saldo deudor de: ${MontoFactura}");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Gracias por utilizar nuestros servicios.");
            Console.WriteLine("Ingrese cualquier tecla para continuar.");
            Console.ReadKey();
        }
    }
}
