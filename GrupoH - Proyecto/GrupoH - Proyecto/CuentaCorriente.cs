using CAIGrupoH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoH___Proyecto
{
    internal class CuentaCorriente
    {
        public string? NumeroCliente { get; set; }

        public static CuentaCorriente ConsultarCuentaCorriente(string codCliente)
        {
            var cuentaCorriente = new CuentaCorriente();
            cuentaCorriente.NumeroCliente = codCliente;

            while (true)
            {
                Console.Clear();
                int menuConsulta = Validaciones.ValidarMenuPrincipal("Consulta de 'Estado de Cuenta Corriente'", " \n1. Consultar 'Ordenes Pendientes de Facturar'  \n2. Consultar 'Saldo Adeudado'", 1, 2);

                switch (menuConsulta)
                {
                    case 1:
                        {
                            Console.Clear();
                            OrdenDeServicio OS = new OrdenDeServicio();
                            OS.LeerMaestroOrdenes();
                            OS.MostrarOSPendientesFacturar(cuentaCorriente.NumeroCliente);
                            Console.WriteLine("");
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("Gracias por utilizar nuestros servicios.");
                            Console.WriteLine("Ingrese cualquier tecla para continuar.");
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Factura Factura = new Factura();
                            Factura.LeerMaestroFacturas();
                            Factura.DesplegarFacturasCliente(cuentaCorriente.NumeroCliente);
                            Console.WriteLine("");
                            Console.WriteLine("Gracias por utilizar nuestros servicios.");
                            Console.WriteLine("Ingrese cualquier tecla para continuar.");
                            Console.ReadKey();
                            break;
                        }
                }
                break;
            }
            return cuentaCorriente;
        }
    }
}
