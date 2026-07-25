using System;

namespace Clientes.Models
{
    public class TipoCuenta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; } = true;
    }
}
