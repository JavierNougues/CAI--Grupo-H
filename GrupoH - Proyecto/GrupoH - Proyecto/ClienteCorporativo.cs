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
        public string dniPersonalAutorizado { get; }
        public string nombrePersonalAutorizado { get; }

        const string maestroClienteCorporativo = "maestroclientecorporativo.txt";

        static List<ClienteCorporativo> clientes = new List<ClienteCorporativo>();
        public ClienteCorporativo() { }
        public ClienteCorporativo(string linea)
        {
            var datos = linea.Split('|');
            NumeroCliente = datos[0];
            Contraseña = datos[1];
            NombreCliente = datos[2];
            CUIT = datos[3];
            dniPersonalAutorizado = datos[4];
            nombrePersonalAutorizado = datos[5];
        }

       
    }
}
