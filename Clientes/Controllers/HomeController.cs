using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Clientes.Models;
using Clientes.Services;
using Microsoft.AspNetCore.Http;

namespace Clientes.Controllers
{
    public class HomeController : Controller
    {
        public ClientesServices ClienteService { get; }
        public HomeController(ClientesContext db)
        {
            var tiposService = new TiposService();
            ClienteService = new ClientesServices(db, tiposService);
        }
        public IActionResult Tipos()
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var id = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, id))
            {
                return View(ClienteService.ObtenerTipos());
            }

            return RedirectToAction("Login", "User");
        }

        public IActionResult Index()
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var id = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, id))
            {
                CargarTipos();
                var listaClientes = ClienteService.ObtenerFecha("V");
                var filterStateKey = HttpContext.Session.GetObjectFromJson<string>("FilterStateKey");
                var filterStateValue = HttpContext.Session.GetObjectFromJson<string>("FilterStateValue");

                if (!string.IsNullOrEmpty(filterStateKey) && !string.IsNullOrEmpty(filterStateValue))
                {
                    if (filterStateKey.Equals("Nombre", StringComparison.OrdinalIgnoreCase))
                    {
                        return View(ClienteService.FiltrarNombre(filterStateValue, listaClientes));
                    }

                    if (filterStateKey.Equals("Cuenta", StringComparison.OrdinalIgnoreCase))
                    {
                        return View(ClienteService.FiltrarCuenta(filterStateValue, listaClientes));
                    }

                    if (filterStateKey.Equals("Comentario", StringComparison.OrdinalIgnoreCase))
                    {
                        return View(ClienteService.FiltrarComentario(filterStateValue, listaClientes));
                    }

                    if (filterStateKey.Equals("UnifiedSearch", StringComparison.OrdinalIgnoreCase))
                    {
                        return View(ClienteService.FiltrarUnificado(filterStateValue, listaClientes));
                    }
                }

                return View(listaClientes);
            }

            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                CargarTipos();
                var cliente = ClienteService.Buscar(id);
                return cliente == null ? RedirectToAction("Index") : View(cliente);
            }

            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public IActionResult Editar(Models.Clientes data)
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                return Json(ClienteService.Actualizar(data));
            }

            return Json(false);
        }

        [HttpGet]
        public IActionResult NuevoCliente()
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                CargarTipos();
                return View();
            }

            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public IActionResult NuevoCliente(Models.Clientes data)
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                return Json(ClienteService.Nuevo(data));
            }

            return Json(false);
        }

        [HttpPost]
        public IActionResult Borrar(int id)
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                var cliente = ClienteService.Buscar(id);
                return Json(cliente != null && ClienteService.Delete(cliente));
            }

            return Json(false);
        }

        [HttpPost]
        public IActionResult UnifiedSearch(string search)
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                var lista = ClienteService.Obtener();
                var resultado = ClienteService.FiltrarUnificado(search, lista);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    HttpContext.Session.SetObjectAsJson("FilterStateKey", "UnifiedSearch");
                    HttpContext.Session.SetObjectAsJson("FilterStateValue", search);
                }
                else
                {
                    LimpiarFiltrosSesion();
                }

                return Json(resultado);
            }

            return Json(new List<ClienteModel>());
        }

        [HttpPost]
        public IActionResult MostrarTodas()
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                LimpiarFiltrosSesion();
                return Json(ClienteService.Obtener());
            }

            return Json(new List<ClienteModel>());
        }

        [HttpPost]
        public IActionResult CuentaLibre()
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                return Json(ClienteService.ListaLibres(ClienteService.Obtener()));
            }

            return Json(new List<ClienteModel>());
        }

        [HttpPost]
        public IActionResult FiltrarPorTipo(int tipoId)
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                return Json(ClienteService.Obtener(tipoId));
            }

            return Json(new List<ClienteModel>());
        }

        [HttpPost]
        public IActionResult BuscarPorFecha()
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                return Json(ClienteService.ObtenerFecha("V"));
            }

            return Json(new List<ClienteModel>());
        }

        [HttpPost]
        public IActionResult BuscarPorFechaCuenta()
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                return Json(ClienteService.ObtenerFecha("VC"));
            }

            return Json(new List<ClienteModel>());
        }

        [HttpPost]
        public IActionResult BuscarCuenta()
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                return Json(ClienteService.Obtener());
            }

            return Json(new List<ClienteModel>());
        }

        [HttpPost]
        public IActionResult SortClients(string column, string direction)
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                var clients = ClienteService.Obtener();

                // Apply sorting logic based on column and direction
                switch (column)
                {
                    case "TipoNombre":
                        clients = (direction == "asc") ? clients.OrderBy(c => c.TipoNombre).ToList() : clients.OrderByDescending(c => c.TipoNombre).ToList();
                        break;
                    case "Nombre":
                        clients = (direction == "asc") ? clients.OrderBy(c => c.Nombre).ToList() : clients.OrderByDescending(c => c.Nombre).ToList();
                        break;
                    case "Cuenta":
                        clients = (direction == "asc") ? clients.OrderBy(c => c.Cuenta).ToList() : clients.OrderByDescending(c => c.Cuenta).ToList();
                        break;
                    case "Contraseña":
                        clients = (direction == "asc") ? clients.OrderBy(c => c.Contraseña).ToList() : clients.OrderByDescending(c => c.Contraseña).ToList();
                        break;
                    case "VencimientoC":
                        clients = (direction == "asc") ? clients.OrderBy(c => c.VencimientoC).ToList() : clients.OrderByDescending(c => c.VencimientoC).ToList();
                        break;
                    case "VencimientoP":
                        clients = (direction == "asc") ? clients.OrderBy(c => c.VencimientoP).ToList() : clients.OrderByDescending(c => c.VencimientoP).ToList();
                        break;
                    case "Pantallas":
                        clients = (direction == "asc") ? clients.OrderBy(c => c.Pantallas).ToList() : clients.OrderByDescending(c => c.Pantallas).ToList();
                        break;
                    case "Comentario":
                        clients = (direction == "asc") ? clients.OrderBy(c => c.Comentario).ToList() : clients.OrderByDescending(c => c.Comentario).ToList();
                        break;
                    default:
                        clients = (direction == "asc") ? clients.OrderBy(c => c.Nombre).ToList() : clients.OrderByDescending(c => c.Nombre).ToList();
                        break;
                }

                return Json(clients);
            }

            return Json(new List<ClienteModel>());
        }

        [HttpPost]
        public IActionResult AgregarTipo(string nombre)
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                var success = ClienteService.AgregarTipo(nombre);
                return Json(new { success, tipos = ClienteService.ObtenerTipos() });
            }

            return Json(new { success = false, message = "Sesion invalida" });
        }

        [HttpPost]
        public IActionResult EditarTipo(int id, string nombre)
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                var success = ClienteService.RenombrarTipo(id, nombre);
                return Json(new { success, tipos = ClienteService.ObtenerTipos() });
            }

            return Json(new { success = false, message = "Sesion invalida" });
        }

        [HttpPost]
        public IActionResult EliminarTipo(int id)
        {
            var token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            var userId = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (token != null && ClienteService.ValidateToken(token, userId))
            {
                if (ClienteService.TipoEnUso(id))
                {
                    return Json(new { success = false, message = "No se puede eliminar un tipo que ya esta en uso." });
                }

                var success = ClienteService.EliminarTipo(id);
                return Json(new { success, tipos = ClienteService.ObtenerTipos() });
            }

            return Json(new { success = false, message = "Sesion invalida" });
        }

        [HttpGet]
        public IActionResult LimpiarFiltros()
        {
            LimpiarFiltrosSesion();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void CargarTipos()
        {
            ViewBag.Tipos = ClienteService.ObtenerTipos();
        }

        private void LimpiarFiltrosSesion()
        {
            HttpContext.Session.Remove("FilterStateKey");
            HttpContext.Session.Remove("FilterStateValue");
        }

    }







}
