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

            if (Token != null)
            {
                if (ClienteService.ValidateToken(Token, id))
                {
                    return View(ClienteService.Obtener());
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

            return listaNombres;
        }

        public List<ClienteModel> FiltrarCuenta(string Cuenta) 
        {
            List<ClienteModel> ListaCuentas = new List<ClienteModel>();

            var lista = ClienteService.Obtener();
            
            ListaCuentas = ClienteService.FiltrarCuenta(Cuenta, lista);

            return ListaCuentas;
            
        }


    }
}
