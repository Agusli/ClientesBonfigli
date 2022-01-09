using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Clientes.Controllers;
using Clientes.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Remotion.Linq.Clauses;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;

namespace Clientes.Services
{
    public class ClientesServices
    {
        public readonly ClientesContext _clientesContext;
        public ClientesServices(ClientesContext db)
        {
            _clientesContext = db;
        }

        public List<ClienteModel> Obtener(int TipoFiltro = 0)
        {
            var sortedList = _clientesContext.Clientes.ToList();
            List<ClienteModel> clientes = new List<ClienteModel>();

            if (TipoFiltro != 0)
                sortedList = sortedList.Where(x => x.Tipo == TipoFiltro).OrderBy(x => x.Cuenta).ToList();

            foreach (var item in sortedList)// en el caso que el quiera le fecha de vencimiento hay que colocar la variable resultado
            {
                ClienteModel cliente = new ClienteModel()
                {
                    Id = item.Id,
                    Cuenta = string.IsNullOrEmpty(item.Cuenta) ? "" : item.Cuenta,
                    Contraseña = string.IsNullOrEmpty(item.Contraseña) ? "" : item.Contraseña,
                    Email = string.IsNullOrEmpty(item.Email) ? "" : item.Email,
                    Nombre = string.IsNullOrEmpty(item.Nombre) ? "" : item.Nombre,
                    Pantallas = string.IsNullOrEmpty(item.Pantallas) ? "" : item.Pantallas,
                    VencimientoC = item.VencimientoC.HasValue ? item.VencimientoC.Value.ToString("dd/MM/yyyy") : "",
                    VencimientoP = item.VencimientoP.HasValue ? item.VencimientoP.Value.ToString("dd/MM/yyyy") : "",
                    Comentario = string.IsNullOrEmpty(item.Comentario) ? "" : item.Comentario,

                };

                switch (item.Tipo)
                {
                    case 1:
                        cliente.Tipo = Tipo.Netflix;
                        break;
                    case 2:
                        cliente.Tipo = Tipo.Flow;
                        break;
                    case 3:
                        cliente.Tipo = Tipo.IPTV;
                        break;
                    case 4:
                        cliente.Tipo = Tipo.DirecTVGo;
                        break;
                    case 5:
                        cliente.Tipo = Tipo.AmazonPrime;
                        break;

                    case 6:
                        cliente.Tipo = Tipo.Spotify;
                        break;
                    case 7:
                        cliente.Tipo = Tipo.DisneyPlus;
                        break;
                    case 8:
                        cliente.Tipo = Tipo.HBOMax;
                        break;
                }


                clientes.Add(cliente);
            }


            return clientes;

        }



        public List<ClienteModel> ObtenerFecha(string TipoOrden)
        {
            var resultado = _clientesContext.Clientes.ToList();
            List<ClienteModel> clientes = new List<ClienteModel>();

            if (TipoOrden.Equals("V"))
            {
                resultado = resultado.OrderBy(x => x.VencimientoP).ToList();
            }
            else if (TipoOrden.Equals("VC"))
            {
                resultado = resultado.OrderBy(x => x.VencimientoC).ToList();
            }


            foreach (var item in resultado)// en el caso que el quiera le fecha de vencimiento hay que colocar la variable resultado
            {
                ClienteModel cliente = new ClienteModel()
                {
                    Id = item.Id,
                    Cuenta = string.IsNullOrEmpty(item.Cuenta) ? "" : item.Cuenta,
                    Contraseña = string.IsNullOrEmpty(item.Contraseña) ? "" : item.Contraseña,
                    Email = string.IsNullOrEmpty(item.Email) ? "" : item.Email,
                    Nombre = string.IsNullOrEmpty(item.Nombre) ? "" : item.Nombre,
                    Pantallas = string.IsNullOrEmpty(item.Pantallas) ? "" : item.Pantallas,
                    VencimientoC = item.VencimientoC.HasValue ? item.VencimientoC.Value.ToString("dd/MM/yyyy") : "",
                    VencimientoP = item.VencimientoP.HasValue ? item.VencimientoP.Value.ToString("dd/MM/yyyy") : "",
                    Comentario = string.IsNullOrEmpty(item.Comentario) ? "" : item.Comentario,



                };

                switch (item.Tipo)
                {
                    case 1:
                        cliente.Tipo = Tipo.Netflix;
                        break;
                    case 2:
                        cliente.Tipo = Tipo.Flow;
                        break;
                    case 3:
                        cliente.Tipo = Tipo.IPTV;
                        break;
                    case 4:
                        cliente.Tipo = Tipo.DirecTVGo;
                        break;
                    case 5:
                        cliente.Tipo = Tipo.AmazonPrime;
                        break;

                    case 6:
                        cliente.Tipo = Tipo.Spotify;
                        break;
                    case 7:
                        cliente.Tipo = Tipo.DisneyPlus;
                        break;
                    case 8:
                        cliente.Tipo = Tipo.HBOMax;
                        break;
                }


                clientes.Add(cliente);
            }


            return clientes;

        }


        internal static void Buscar()
        {
            throw new NotImplementedException();
        }

        public Boolean Agregar(Models.Clientes _clientes)
        {
            try
            {
                _clientesContext.Clientes.Add(_clientes);
                _clientesContext.SaveChanges();
                return true;

            }
            catch (Exception error)
            {
                return false;
            }

        }

        public Boolean AgregarVarios(List<Models.Clientes> _clientes)
        {
            try
            {
                _clientesContext.Clientes.AddRange(_clientes);
                _clientesContext.SaveChanges();
                return true;

            }
            catch (Exception error)
            {
                return false;
            }

        }

        public Boolean Delete(Models.Clientes clientes)
        {
            try
            {
                _clientesContext.Clientes.Remove(clientes);
                _clientesContext.SaveChanges();
                return true;

            }

            catch (Exception error)
            {
                return false;
            }
        }

        public Models.Clientes Buscar(int id)
        {
            var x = _clientesContext.Clientes.FirstOrDefault(l => l.Id == id);

            return x;


        }



        public Boolean Nuevo(Models.Clientes data)
        {
            var _cliente = data;
            try
            {
                var cuenta = _clientesContext.Clientes.Where(x => x.Cuenta == data.Cuenta).ToList();

                _clientesContext.Clientes.Add(_cliente);
                _clientesContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }



        }

        public bool Actualizar(Models.Clientes data)
        {
            try
            {
                Models.Clientes cliente = _clientesContext.Clientes.FirstOrDefault(x => x.Id == data.Id);

                _clientesContext.Clientes.Remove(cliente);

                _clientesContext.Clientes.Add(data);

                _clientesContext.SaveChanges();

                return true;

            }
            catch (Exception e)
            {
                return false;
            }

        }

        public Models.Usuario GetUserByCredentials(Models.Usuario data)
        {
            try
            {
                return _clientesContext.Usuario.FirstOrDefault(u => u.Usuario1 == data.Usuario1 && u.Password == data.Password);
            }
            catch (System.Exception e)
            {
                return null;
            }
        }


        public bool UpdateUserToken(Models.Usuario data, string token)
        {
            try
            {
                _clientesContext.Usuario.FirstOrDefault(u => u.Id == data.Id).Token = token;
                _clientesContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public bool ValidateToken(string token, string id)
        {
            Usuario user = _clientesContext.Usuario.FirstOrDefault(u => u.Id == int.Parse(id));

            if (user != null)
            {
                if (user.Token == token)
                {
                    return true;
                }
            }

            return false;

        }

        public List<ClienteModel> FiltrarNombre(string Nombre, List<ClienteModel> ListaClientes)
        {
            List<ClienteModel> ClientesFiltrados = new List<ClienteModel>();

            if (!string.IsNullOrEmpty(Nombre))
            {

                foreach (var item in ListaClientes)
                {
                    if (string.IsNullOrEmpty(item.Nombre))
                    {
                        item.Nombre = "";
                    }
                }

                ClientesFiltrados = ListaClientes.Where(x => x.Nombre.ToLower().StartsWith(Nombre.ToLower())).ToList();
            }
            else
            {
                ClientesFiltrados = ListaClientes;
            }

            return ClientesFiltrados;

        }

        public List<ClienteModel> FiltrarCuenta(string Cuenta, List<ClienteModel> filtrarCuenta)
        {
            List<ClienteModel> Cuentasfiltradas = new List<ClienteModel>();

            if (!string.IsNullOrEmpty(Cuenta))
            {
                foreach (var item in Cuentasfiltradas)
                {
                    if (string.IsNullOrEmpty(item.Cuenta))
                    {
                        item.Cuenta = "";
                    }
                }

                Cuentasfiltradas = filtrarCuenta.Where(x => x.Cuenta.ToLower().StartsWith(Cuenta.ToLower())).ToList();

            }
            else
            {
                Cuentasfiltradas = filtrarCuenta;
            }

            return Cuentasfiltradas;
        }

        public List<ClienteModel> FiltrarComentario(string Coment, List<ClienteModel> FiltrarComent)
        {
            List<ClienteModel> Comentarios = new List<ClienteModel>();

            if (!string.IsNullOrEmpty(Coment))
            {
                foreach (var item in Comentarios)
                {
                    if (string.IsNullOrEmpty(item.Cuenta))
                    {
                        item.Cuenta = "";
                    }
                }

                Comentarios = FiltrarComent.Where(x => x.Comentario.ToLower().StartsWith(Coment.ToLower())).ToList();

            }
            else
            {
                Comentarios = FiltrarComent;
            }

            return Comentarios;
        }


        public List<ClienteModel> ListaLibres(List<ClienteModel> filtrarCuentasLibres)
        {
            List<ClienteModel> FiltrarCuentasLibres = new List<ClienteModel>();

            FiltrarCuentasLibres = filtrarCuentasLibres.Where(x => x.Nombre == "" || x.Comentario.ToLower() == "libre").ToList();

            return FiltrarCuentasLibres;

        }


    }
}