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
            bool factura = false;
            for (int i = 0; i < facturas.Count; i++)
            {
                if (facturas[i].NumeroCliente == codCliente)
                {
                    Console.WriteLine("Fecha \t\tNúmero Factura  \t\tEstado \t\tMonto");
                    Console.WriteLine($"{facturas[i].FechaFactura} \t\t{facturas[i].NumeroFactura} \t\t{facturas[i].EstadoFactura} \t\t{facturas[i].MontoFactura} ");

                    Console.WriteLine("\n\n");
                    Console.WriteLine("Gracias por utilizar nuestros servicios.");
                    Console.WriteLine("Ingrese cualquier tecla para continuar.");
                    Console.ReadKey();
                    factura = true;
                }
                else
                {
                    factura = false;
                }
            }
            if (factura == false)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("No se econtraron facturas emitidas.");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Gracias por utilizar nuestros servicios.");
                Console.WriteLine("Ingrese cualquier tecla para continuar.");
                Console.ReadKey();
            }
        }
        public void MostrarSaldoCliente(string codCliente)
        {
            var monto = new Factura();
            bool montoNegativo = false;
            Console.Clear();
            for (int i = 0; i < facturas.Count; i++)
            {
                if (facturas[i].NumeroCliente == codCliente &&  "Impaga" == facturas[i].EstadoFactura)
                {
                    monto.MontoFactura += facturas[i].MontoFactura;
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine($"Posee un saldo deudor de: ${monto.MontoFactura}");
                    Console.WriteLine("------------------------------------------------------");
                    var montoAcumulado = monto.MontoFactura;
                    if (montoAcumulado > 0)
                    {
                        montoNegativo = true;
                    }
                }
            }
            if (montoNegativo == false)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("No posee un saldo deudor de cuenta.");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Gracias por utilizar nuestros servicios.");
                Console.WriteLine("Ingrese cualquier tecla para continuar.");
                Console.ReadKey();
            }
        }
    }
}
