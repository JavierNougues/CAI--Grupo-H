using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GrupoH___Proyecto
{
    internal class ClienteCorporativo
    {
        public string NumeroCliente { get; }
        public string? Contraseña { get; }
        public string NombreCliente { get; }
        public string CUIT { get; }
        public string DNIPersonalAutorizado { get; }
        public string NombrePersonalAutorizado { get; }

        const string maestroClienteCorporativo = "C:\\Users\\javier.nougues@sap.com\\Documents\\GitHub\\CAI--Grupo-H\\GrupoH - Proyecto\\maestroclientecorporativo.txt";

        static List<ClienteCorporativo> clientes = new List<ClienteCorporativo>();
        public ClienteCorporativo() { }
        public ClienteCorporativo(string linea)
        {
            var datos = linea.Split('|');
            NumeroCliente = datos[0];
            Contraseña = datos[1];
            NombreCliente = datos[2];
            CUIT = datos[3];
            DNIPersonalAutorizado = datos[4];
            NombrePersonalAutorizado = datos[5];
        }

        public void LeerMaestroCliente(string nroCliente, string contraCliente, string dniCliente)
        {

            if (File.Exists(maestroClienteCorporativo))
            {
                using (var reader = new StreamReader(maestroClienteCorporativo))
                {
                    bool numero = false;
                    bool contra = false;
                    bool dni = false;

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var cliente = new ClienteCorporativo(linea);

                        numero = cliente.NumeroCliente == nroCliente;
                        contra = cliente.Contraseña == contraCliente;
                        dni = cliente.DNIPersonalAutorizado == dniCliente;

                        if (numero && contra && dni)
                        {
                            clientes.Add(cliente);
                            break;

                        }

                    }
                    if (numero == false || contra == false || dni == false)
                    {   Console.Clear();
                        Console.WriteLine("Los datos de inicio de sesión ingresados son incorrectos.");
                        Console.WriteLine("Presione cualquier tecla para continuar.");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                    }
                }
            }
        }

        public void VisualizarCliente()
        {

            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("¡Bienvenido!");
                Console.WriteLine($"Cliente: {clientes[i].NombreCliente}");
                Console.WriteLine($"CUIT: {clientes[i].CUIT}");
                Console.WriteLine("");
                Console.WriteLine("Usuario Autorizado");
                Console.WriteLine($"Nombre: {clientes[i].NombrePersonalAutorizado}");
                Console.WriteLine("--------------------------------------------------");

                Console.WriteLine("");
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey();
            }
        }

        public string Cliente()
        {
            string cliente = "";
            for (int i = 0; i < clientes.Count; i++)
            {
                cliente = clientes[i].NombreCliente;
            }
            return cliente;
        }

        public string NroCliente()
        {
            string nroCliente = "";
            for (int i = 0; i < clientes.Count; i++)
            {
                nroCliente = clientes[i].NumeroCliente;
            }
            return nroCliente;
        }
    }
}
