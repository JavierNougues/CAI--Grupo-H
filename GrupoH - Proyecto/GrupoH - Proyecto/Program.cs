﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GrupoH___Proyecto;

namespace CAIGrupoH
{
    class Program
    {
        static void Main(string[] strings)
        {
            // Ingreso de Cliente + Contraseña + DNI Autorizado


            Console.Clear();

            // Menu Princiapl: Opciones
            while (true)
            {
                int menuPrincipal = Validaciones.ValidarMenuPrincipal("Seleccione la acción a realizar: ", "1. Realizar Envío \n2. Consultar Estado de su Envío \n3. Consultar Estado de su Cuenta Corriente \n0. Salir", 0, 3);
                switch (menuPrincipal)
                {
                    case 1:
                        {
                            var realizarEnvioNacional = Envio.Ingresar();
                            break;
                        }
                    case 2:
                        {
                            var conultarEstadoEnvio = OrdenDeServicio.ConsultarEstadoOrden();
                            break;
                        }
                    case 3:
                        {
                            //Falta generar el inicio donde se obtendra el codigo de cliente.
                            //var consultarEstadoCuentaCorriente = CuentaCorriente.ConsultarCuentaCorriente(codCliente);
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Ha salido exitosamente del sistema.");
                            System.Environment.Exit(0);
                            break;

                        }
                }
            }
        }

    }
}