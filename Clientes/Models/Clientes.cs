using System;
using System.Collections.Generic;

namespace Clientes.Models
{
    public partial class Clientes
    {
        public int Id { get; set; }
        public string Cuenta { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public DateTime? VencimientoP { get; set; }
        public DateTime? VencimientoC { get; set; }
        public string Nombre { get; set; }
        public int? Tipo { get; set; }
        public string Pantallas { get; set; }
        public string Comentario {get; set;}
    }
}
