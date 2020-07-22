using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Cuenta { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public DateTime? VencimientoP { get; set; }
        public DateTime? VencimientoC { get; set; }
        public string Nombre { get; set; }
        public Tipo Tipo { get; set; }
        public string Pantallas { get; set; }
    }
}
