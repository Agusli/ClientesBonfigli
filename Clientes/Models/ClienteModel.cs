using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Clientes.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Cuenta { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string VencimientoP { get; set; }
        public string VencimientoC { get; set; }
        public string Nombre { get; set; }
        public Tipo Tipo { get; set; }
        public string Pantallas { get; set; }
        public string Comentario { get; internal set; }
    }
}
