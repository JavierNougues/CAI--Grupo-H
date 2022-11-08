using CAIGrupoH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_GrupoH
{
    static class EstadoCuenta
    {
        public static void  EstadodeCuenta()
        {
            Console.Clear();
            do
            {
                Console.WriteLine("Seleccione una Factura para ver su detalle: \n");
                Console.WriteLine("   Fecha     Factura  Importe  Ya pagado");
                var menuRegion = Validaciones.ValidarEstadoCuenta("1. 03/09/2022  F100   $1000    Si   \n2. 10/10/2022  F101   $1500    No \n3. 31/10/2022  F102   $2500    No\n4. Volver al menu", 1, 4);
                if (menuRegion == 1)
                {
                    Console.Clear();
                    Console.Write("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("Factura Numero F100");
                    Console.WriteLine("Fecha Factura 03/09/2022\n");
                    Console.WriteLine($"Numero de Orden: I100\n");
                    Console.WriteLine($"Peso Paquete:Correspondencia hasta 500g \n");
                    Console.WriteLine($"Importe: $1000\n");

                    Console.Write("Origen del Paquete: \n");
                    Console.WriteLine($"Tipo de Retiro: Retiro en sucursal\n");
                    Console.WriteLine($"Provincia de Retiro: Buenos Aires \n");
                    Console.WriteLine($"Localidad de Retiro: Belgrano\n");

                    Console.WriteLine($"Sucursal de Retiro: CABA \n");



                    Console.Write("Destino del Paquete: \n");
                    Console.WriteLine($"Tipo de Entrega: Entrega en sucursal \n");
                    Console.WriteLine($"Continente de Entrega: Europa\n");
                    Console.WriteLine($"Pais de Entrega: España\n");
                    Console.Write("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("Presione Cualquier tecla para volver atras");
                    Console.ReadKey();
                    Console.Clear();
                    continue;

                }
                else if (menuRegion == 2)
                {
                    Console.Clear();
                    Console.Write("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("Factura Numero F101");
                    Console.WriteLine("Fecha Factura 10/10/2022\n");
                    Console.WriteLine($"Numero de Orden: N100\n");
                    Console.WriteLine($"Peso Paquete: Correspondencia hasta 500g \n");
                    Console.WriteLine($"Importe: $1500\n");

                    Console.Write("Origen del Paquete: \n");
                    Console.WriteLine($"Tipo de Retiro: Retiro en sucursal\n");
                    Console.WriteLine($"Provincia de Retiro: Buenos Aires \n");
                    Console.WriteLine($"Localidad de Retiro: Belgrano\n");


                    Console.Write("Destino del Paquete: \n");
                    Console.WriteLine($"Tipo de Entrega: Entrega en puerta \n");
                    Console.WriteLine($"Provincia de Entrega:Catamarca \n");
                    Console.WriteLine($"Localidad de Entrega: San Fernando del Valle de Catamarca\n");
                    Console.Write("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("Presione Cualquier tecla para volver atras");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else if (menuRegion == 3)
                {
                    Console.Clear();
                    Console.Write("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("Factura Numero F102");
                    Console.WriteLine("Fecha Factura 31/10/2022\n");
                    Console.WriteLine($"Numero de Orden: I101\n");
                    Console.WriteLine($"Peso Paquete: Encomienda: hasta 30kg \n");
                    Console.WriteLine($"Importe: $2500\n");

                    Console.Write("Origen del Paquete: \n");
                    Console.WriteLine($"Tipo de Retiro: Retiro en puerta\n");
                    Console.WriteLine($"Provincia de Retiro: Buenos Aires \n");
                    Console.WriteLine($"Localidad de Retiro: Belgrano\n");


                    Console.Write("Destino del Paquete: \n");
                    Console.WriteLine($"Tipo de Entrega: Entrega en sucursal \n");
                    Console.WriteLine($"Continente de Entrega: Europa\n");
                    Console.WriteLine($"Pais de Entrega: España\n");
                    Console.Write("------------------------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("Presione Cualquier tecla para volver atras");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else
                {
                    Console.Clear();
                    return;
                }
            }while (true);
        }
    }
}
