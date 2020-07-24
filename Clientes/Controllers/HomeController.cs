﻿using System;
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


        public IActionResult Editar(int id)
        {
            ClientesServices _clientesServices = new ClientesServices();

            var cliente = _clientesServices.Buscar(id);


            return View(cliente);

        }

        [HttpPost]
        public IActionResult Editar(Models.Clientes data, int id )
        {
           
            ClientesServices _clientesServices = new ClientesServices();

            var cliente = _clientesServices.Buscar(id);

            if(cliente != null)
            {
               
                _clientesServices.Delete(cliente);
                _clientesServices.Nuevo(data);
            }

            return View("Index");
        }

        public IActionResult NuevoCliente()
        {

            return View();

        }

        [HttpPost]
        public IActionResult NuevoCliente(Models.Clientes data)
        {
            ClientesServices clientesServices = new ClientesServices();

            var clienteN = data;

            clientesServices.Nuevo(clienteN);


            return View("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //crear un metodo de tipo string q reciba como parametro id que toma de ajax

        public Boolean Recibir(int id)
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
