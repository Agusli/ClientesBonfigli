using System;
using System.Collections.Generic;
using System.Linq;
using Clientes.Models;

namespace Clientes.Services
{
    public class TiposService
    {
        private readonly ClientesContext _db;

        public TiposService(ClientesContext db)
        {
            _db = db;
        }

        public List<TipoCuenta> ObtenerTodos()
        {
            return _db.Tipos.Where(x => x.Activo).OrderBy(x => x.Nombre).ToList();
        }

        public TipoCuenta Buscar(int id)
        {
            return _db.Tipos.FirstOrDefault(x => x.Id == id);
        }

        public TipoCuenta BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return null;
            }

            var nombreNormalizado = nombre.Trim().ToLower();

            return _db.Tipos.AsEnumerable().FirstOrDefault(x =>
                x.Nombre.Trim().ToLower() == nombreNormalizado && x.Activo);
        }

        public bool Agregar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return false;
            }

            var nombreNormalizado = nombre.Trim().ToLower();

            // Usamos AsEnumerable para realizar la comparación de strings que EF Core 2.2 puede no traducir bien con Trim/OrdinalIgnoreCase
            if (_db.Tipos.AsEnumerable().Any(x => x.Nombre.Trim().ToLower() == nombreNormalizado))
            {
                return false;
            }

            try
            {
                _db.Tipos.Add(new TipoCuenta
                {
                    Nombre = nombre.Trim(),
                    Activo = true
                });
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Renombrar(int id, string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return false;
            }

            var tipo = _db.Tipos.FirstOrDefault(x => x.Id == id);
            if (tipo == null)
            {
                return false;
            }

            var nombreNormalizado = nombre.Trim().ToLower();

            if (_db.Tipos.AsEnumerable().Any(x => x.Id != id && x.Nombre.Trim().ToLower() == nombreNormalizado))
            {
                return false;
            }

            try
            {
                tipo.Nombre = nombre.Trim();
                tipo.Activo = true;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(int id)
        {
            var tipo = _db.Tipos.FirstOrDefault(x => x.Id == id);
            if (tipo == null)
            {
                return false;
            }

            try
            {
                _db.Tipos.Remove(tipo);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
