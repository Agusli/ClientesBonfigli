using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clientes.Models;
using System.Security.Cryptography.X509Certificates;
using Clientes.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;


namespace Clientes.Controllers
{
    public class HomeController : Controller
    {
        public ClientesServices ClienteService;
        public HomeController (ClientesContext db){
            ClienteService = new ClientesServices(db);
        }
        public IActionResult Index()
        {
            string Token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            string id = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");
            string FilterStateKey = HttpContext.Session.GetObjectFromJson<string>("FilterStateKey");
            string FilterStateValue = HttpContext.Session.GetObjectFromJson<string>("FilterStateValue");
            List<ClienteModel> ListaClientes = ClienteService.Obtener();

            if (Token != null)
            {
                if (ClienteService.ValidateToken(Token, id))
                {
                    if(string.IsNullOrEmpty(FilterStateKey) || string.IsNullOrEmpty(FilterStateValue))
                    {
                        return View(ListaClientes);
                    }
                    else
                    {
                        if(FilterStateKey.Equals("Nombre"))
                        {
                            return View(ClienteService.FiltrarNombre(FilterStateValue, ListaClientes));
                        }
                        else if(FilterStateKey.Equals("Cuenta"))
                        {
                            return View(ClienteService.FiltrarCuenta(FilterStateValue, ListaClientes));
                        }
                    }
                }
            }
            return RedirectToAction("Login", "User");

        } 

        [HttpGet]
        public IActionResult Editar(int id)
        {
            string Token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            string UserId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (Token != null)
            {
                if (ClienteService.ValidateToken(Token, UserId))
                {
                    var cliente = ClienteService.Buscar(id);

                    return View(cliente);
                }
            }

            return RedirectToAction("Login", "User");
        }




        [HttpPost]
        public Boolean Editar(Models.Clientes data)
        {
            bool Exito = false;
            string Token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            string UserId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (Token != null)
            {
                if (ClienteService.ValidateToken(Token, UserId))
                {
                    Exito = ClienteService.Actualizar(data);
                    return Exito;
                }
            }

            return Exito;

        }

        public IActionResult NuevoCliente()
        {
            string Token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            string UserId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (Token != null)
            {
                if (ClienteService.ValidateToken(Token, UserId))
                {
                    return View();
                }
            }

            return RedirectToAction("Login", "User");

        }

        [HttpPost]
        public Boolean NuevoCliente(Models.Clientes data)
        {
            string Token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            string UserId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");
            bool clienteN = false;

            if (Token != null)
            {
                if (ClienteService.ValidateToken(Token, UserId))
                {
                    clienteN = ClienteService.Nuevo(data);
                }
            }

            return clienteN;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public Boolean Borrar(int id)
        {
            bool exito = false;
            Models.Clientes cliente = new Models.Clientes();

            try
            {
                string Token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
                string UserId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

                if (Token != null)
                {
                    if (ClienteService.ValidateToken(Token, UserId))
                    {
                        cliente = ClienteService.Buscar(id);

                        if (cliente != null)
                        {
                            exito = ClienteService.Delete(cliente);
                        }

                    }
                }

                return exito;
            }
            catch (Exception error)
            {

                return false;
            }
        }



        public List<ClienteModel> Filtrar(string Search)
        {
            List<ClienteModel> listaNombres = new List<ClienteModel>();

            List<ClienteModel> list = ClienteService.Obtener();

            listaNombres = ClienteService.FiltrarNombre(Search, list);

            if(!string.IsNullOrEmpty(Search))
            {
                HttpContext.Session.SetObjectAsJson("FilterStateKey", "Nombre");
                HttpContext.Session.SetObjectAsJson("FilterStateValue", Search);
            }
            else
            {
                HttpContext.Session.Remove("FilterStateKey");
                HttpContext.Session.Remove("FilterStateValue");

            }


            return listaNombres;
        }

        public List<ClienteModel> FiltrarCuenta(string Cuenta) 
        {
            List<ClienteModel> ListaCuentas = new List<ClienteModel>();

            var lista = ClienteService.Obtener();
            
            ListaCuentas = ClienteService.FiltrarCuenta(Cuenta, lista);

            if(!string.IsNullOrEmpty(Cuenta))
            {
                HttpContext.Session.SetObjectAsJson("FilterStateKey", "Cuenta");
                HttpContext.Session.SetObjectAsJson("FilterStateValue", Cuenta);
            }
            else
            {
                HttpContext.Session.Remove("FilterStateValue");
                HttpContext.Session.Remove("FilterStateKey");
            }

            return ListaCuentas;
            
        }

        public List<ClienteModel> CuentaLibre()
        { List<ClienteModel> cuentaslibres = new List<ClienteModel>();

            var lista = ClienteService.Obtener();
           
                cuentaslibres = ClienteService.ListaLibres(lista);
         

            return cuentaslibres;
        }

    }
}
//ambos parametros se tienen que comparar con los de la lista del service