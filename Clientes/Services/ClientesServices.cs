using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Clientes.Models;

namespace Clientes.Services
{
    public class ClientesServices
    {
        private readonly ClientesContext _clientesContext;
        private readonly TiposService _tiposService;

        public ClientesServices(ClientesContext db, TiposService tiposService)
        {
            _clientesContext = db;
            _tiposService = tiposService;
        }

        public List<TipoCuenta> ObtenerTipos()
        {
            return _tiposService.ObtenerTodos();
        }

        public bool AgregarTipo(string nombre)
        {
            return _tiposService.Agregar(nombre);
        }

        public bool RenombrarTipo(int id, string nombre)
        {
            return _tiposService.Renombrar(id, nombre);
        }

        public bool EliminarTipo(int id)
        {
            return _tiposService.Eliminar(id);
        }

        public bool TipoEnUso(int tipoId)
        {
            return _clientesContext.Clientes.Any(x => x.Tipo == tipoId);
        }

        public List<ClienteModel> Obtener(int tipoFiltro = 0)
        {
            var query = _clientesContext.Clientes.AsQueryable();

            if (tipoFiltro != 0)
            {
                query = query.Where(x => x.Tipo == tipoFiltro);
            }

            var lista = query
                .OrderBy(x => x.Cuenta)
                .ToList();

            var mappedList = lista.Select(MapCliente).ToList();
            PopulateTipoNombres(mappedList);
            return mappedList;
        }

        public List<ClienteModel> ObtenerFecha(string tipoOrden)
        {
            var query = _clientesContext.Clientes.AsQueryable();

            if (tipoOrden.Equals("VC", StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderBy(x => x.VencimientoC).ThenBy(x => x.Cuenta);
            }
            else
            {
                query = query.OrderBy(x => x.VencimientoP).ThenBy(x => x.Cuenta);
            }

            var lista = query.ToList();

            var mappedList = lista.Select(MapCliente).ToList();
            PopulateTipoNombres(mappedList);
            return mappedList;
        }

        private void PopulateTipoNombres(List<ClienteModel> mappedList)
        {
            if (!mappedList.Any()) return;

            var tipos = _tiposService.ObtenerTodos().ToDictionary(t => t.Id, t => t.Nombre);
            foreach (var item in mappedList)
            {
                if (item.TipoId.HasValue && tipos.TryGetValue(item.TipoId.Value, out var nombre))
                {
                    item.TipoNombre = nombre;
                }
                else if (item.TipoId.HasValue)
                {
                    item.TipoNombre = $"Tipo {item.TipoId.Value}";
                }
            }
        }

        public bool Agregar(Models.Clientes clientes)
        {
            try
            {
                _clientesContext.Clientes.Add(clientes);
                _clientesContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AgregarVarios(List<Models.Clientes> clientes)
        {
            try
            {
                _clientesContext.Clientes.AddRange(clientes);
                _clientesContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Models.Clientes clientes)
        {
            try
            {
                _clientesContext.Clientes.Remove(clientes);
                _clientesContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Models.Clientes Buscar(int id)
        {
            return _clientesContext.Clientes.FirstOrDefault(l => l.Id == id);
        }

        public bool Nuevo(Models.Clientes data)
        {
            try
            {
                var cuentaNormalizada = (data.Cuenta ?? string.Empty).Trim();
                if (string.IsNullOrWhiteSpace(cuentaNormalizada))
                {
                    return false;
                }

                var existeCuenta = _clientesContext.Clientes.Any(x =>
                    x.Cuenta != null && x.Cuenta.Trim().ToLower() == cuentaNormalizada.ToLower());

                if (existeCuenta)
                {
                    return false;
                }

                if (data.Tipo.HasValue && _tiposService.Buscar(data.Tipo.Value) == null)
                {
                    return false;
                }

                data.Cuenta = cuentaNormalizada;
                _clientesContext.Clientes.Add(data);
                _clientesContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(Models.Clientes data)
        {
            try
            {
                var cliente = _clientesContext.Clientes.FirstOrDefault(x => x.Id == data.Id);
                if (cliente == null)
                {
                    return false;
                }

                if (data.Tipo.HasValue && _tiposService.Buscar(data.Tipo.Value) == null)
                {
                    return false;
                }

                cliente.Cuenta = data.Cuenta?.Trim();
                cliente.Email = data.Email?.Trim();
                cliente.Telefono = data.Telefono?.Trim();
                cliente.Contraseña = data.Contraseña;
                cliente.VencimientoP = data.VencimientoP;
                cliente.VencimientoC = data.VencimientoC;
                cliente.Nombre = data.Nombre?.Trim();
                cliente.Tipo = data.Tipo;
                cliente.Pantallas = data.Pantallas?.Trim();
                cliente.Comentario = data.Comentario?.Trim();

                _clientesContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Models.Usuario GetUserByCredentials(Models.Usuario data)
        {
            try
            {
                var usuario = (data.Usuario1 ?? string.Empty).Trim();
                var password = data.Password ?? string.Empty;
                return _clientesContext.Usuario.FirstOrDefault(u => u.Usuario1 == usuario && u.Password == password);
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateUserToken(Models.Usuario data, string token)
        {
            try
            {
                var usuario = _clientesContext.Usuario.FirstOrDefault(u => u.Id == data.Id);
                if (usuario == null)
                {
                    return false;
                }

                usuario.Token = token;
                _clientesContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidateToken(string token, string id)
        {
            if (string.IsNullOrWhiteSpace(token) || !int.TryParse(id, out var userId))
            {
                return false;
            }

            var user = _clientesContext.Usuario.FirstOrDefault(u => u.Id == userId);
            return user != null && user.Token == token;
        }

        public List<ClienteModel> FiltrarNombre(string nombre, List<ClienteModel> listaClientes)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return listaClientes;
            }

            return listaClientes
                .Where(x => !string.IsNullOrWhiteSpace(x.Nombre) &&
                            x.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<ClienteModel> FiltrarCuenta(string cuenta, List<ClienteModel> listaClientes)
        {
            if (string.IsNullOrWhiteSpace(cuenta))
            {
                return listaClientes;
            }

            return listaClientes
                .Where(x => !string.IsNullOrWhiteSpace(x.Cuenta) &&
                            x.Cuenta.Contains(cuenta, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<ClienteModel> FiltrarComentario(string comentario, List<ClienteModel> listaClientes)
        {
            if (string.IsNullOrWhiteSpace(comentario))
            {
                return listaClientes;
            }

            return listaClientes
                .Where(x => !string.IsNullOrWhiteSpace(x.Comentario) &&
                            x.Comentario.Contains(comentario, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<ClienteModel> ListaLibres(List<ClienteModel> clientes)
        {
            return clientes
                .Where(x => string.IsNullOrWhiteSpace(x.Nombre) ||
                            string.Equals(x.Comentario, "libre", StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<ClienteModel> FiltrarUnificado(string search, List<ClienteModel> listaClientes)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return listaClientes;
            }

            return listaClientes
                .Where(x => (!string.IsNullOrWhiteSpace(x.Nombre) && x.Nombre.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                            (!string.IsNullOrWhiteSpace(x.Cuenta) && x.Cuenta.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                            (!string.IsNullOrWhiteSpace(x.Email) && x.Email.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                            (!string.IsNullOrWhiteSpace(x.Contraseña) && x.Contraseña.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                            (!string.IsNullOrWhiteSpace(x.VencimientoC) && x.VencimientoC.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                            (!string.IsNullOrWhiteSpace(x.VencimientoP) && x.VencimientoP.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                            (!string.IsNullOrWhiteSpace(x.Pantallas) && x.Pantallas.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                            (!string.IsNullOrWhiteSpace(x.Comentario) && x.Comentario.Contains(search, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        private ClienteModel MapCliente(Models.Clientes item)
        {
            return new ClienteModel
            {
                Id = item.Id,
                Cuenta = item.Cuenta ?? string.Empty,
                Contraseña = item.Contraseña ?? string.Empty,
                Email = item.Email ?? string.Empty,
                Nombre = item.Nombre ?? string.Empty,
                Pantallas = item.Pantallas ?? string.Empty,
                VencimientoC = item.VencimientoC.HasValue ? item.VencimientoC.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : string.Empty,
                VencimientoP = item.VencimientoP.HasValue ? item.VencimientoP.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : string.Empty,
                Comentario = item.Comentario ?? string.Empty,
                TipoId = item.Tipo,
                TipoNombre = "Sin tipo"
            };
        }
    }
}
