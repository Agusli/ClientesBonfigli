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

namespace Clientes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ClientesServices ClienteService = new ClientesServices();
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
            ClientesServices ClienteServices = new ClientesServices();
            string Token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            string UserId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (Token != null)
            {
                if (ClienteServices.ValidateToken(Token, UserId))
                {
                    var cliente = ClienteServices.Buscar(id);

                    return View(cliente);
                }
            }

            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public Boolean Editar(Models.Clientes data)
        {
            bool Exito = false;
            ClientesServices ClienteServices = new ClientesServices();
            string Token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            string UserId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (Token != null)
            {
                if (ClienteServices.ValidateToken(Token, UserId))
                {
                    Exito = ClienteServices.Actualizar(data);
                    return Exito;
                }
            }

            return Exito;

        }

        public IActionResult NuevoCliente()
        {
            ClientesServices ClienteServices = new ClientesServices();
            string Token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            string UserId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (Token != null)
            {
                if (ClienteServices.ValidateToken(Token, UserId))
                {
                    return View();
                }
            }

            return RedirectToAction("Login", "User");

        }

        [HttpPost]
        public Boolean NuevoCliente(Models.Clientes data)
        {
            ClientesServices ClienteServices = new ClientesServices();
            string Token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            string UserId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");
            bool clienteN = false;

            if (Token != null)
            {
                if (ClienteServices.ValidateToken(Token, UserId))
                {
                    clienteN = ClienteServices.Nuevo(data);
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
                ClientesServices ClienteServices = new ClientesServices();
                string Token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
                string UserId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

                if (Token != null)
                {
                    if (ClienteServices.ValidateToken(Token, UserId))
                    {
                        cliente = ClienteServices.Buscar(id);

                        if (cliente != null)
                        {
                            exito = ClienteServices.Delete(cliente);
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

    }
}
