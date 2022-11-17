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
        public string? FechaFactura { get; set; }
        public string? NumeroFactura { get; set; }
        public string? NumeroCliente { get; set; }
        public string? EstadoFactura { get; set; }
        public int MontoFactura { get; set; }

        const string maestroFacturas = "maestrofacturas.txt";

        public List<Factura> facturas = new List<Factura>();

        public Factura(string linea)
        {
            var datos = linea.Split('|');
            FechaFactura = datos[0];
            NumeroFactura = datos[1];
            NumeroCliente = datos[2];
            EstadoFactura = datos[3];
            MontoFactura = int.Parse(datos[4]);
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
            int monto = 0;
            bool factura = false;
            Console.WriteLine("|Fecha| \t\t|Número Factura|  \t|Estado| \t|Monto|");
            for (int i = 0; i < facturas.Count; i++)
            {
                if (facturas[i].NumeroCliente == codCliente)
                {
                    var a = ($"{facturas[i].FechaFactura} \t\t{facturas[i].NumeroFactura} \t\t{facturas[i].EstadoFactura} \t\t${facturas[i].MontoFactura} ");
                    Console.WriteLine(a);
                    factura = true;
                }
                else
                {
                    factura = false;
                }
            }
            if (factura == true)
            {
                Console.WriteLine("");
                Console.WriteLine("|Monto Adeudado|");
                for (int i = 0; i < facturas.Count; i++)
                {
                    if (facturas[i].NumeroCliente == codCliente && facturas[i].EstadoFactura == "Impaga")
                    {
                        var b = ($"${facturas[i].MontoFactura}");
                        Console.WriteLine(b);
                        monto += facturas[i].MontoFactura;

                    }
                }
                Console.WriteLine("");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine($"Total 'Monto Adeudado': ${monto}");
                Console.WriteLine("------------------------------------------------------");
            }
            if (factura == false)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("No se econtraron facturas emitidas.");
                Console.WriteLine("------------------------------------------------------");
            }
        }
    }
}
