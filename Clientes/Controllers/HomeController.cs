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

            return View(ClienteService.Obtener());
        }


        public IActionResult Privacy()
        {


            return View();
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ClientesServices _clientesServices = new ClientesServices();

            var cliente = _clientesServices.Buscar(id);


            return View(cliente);

        }

        [HttpPost]
        public Boolean Editar(Models.Clientes data)
        {
            bool Exito = false; 
            ClientesServices clientesServices = new ClientesServices();

            Exito= clientesServices.Actualizar(data);
            
            return Exito;

        }

        public IActionResult NuevoCliente()
        {

            return View();

        }

        [HttpPost]
        public Boolean NuevoCliente(Models.Clientes data)
        {

            ClientesServices clientesServices = new ClientesServices();

            bool clienteN = false;

            clienteN=clientesServices.Nuevo(data);
            
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

            try
            {
                ClientesServices _clientesServices = new ClientesServices();

                var cliente = _clientesServices.Buscar(id);

                if (cliente != null)
                {
                    exito = _clientesServices.Delete(cliente);

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
