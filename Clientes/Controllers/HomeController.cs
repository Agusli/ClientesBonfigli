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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //crear un metodo de tipo string q reciba como parametro id que toma de ajax
       
           public Boolean Recibir(int Id)
        {
            try
            {
               

                

                return true;
            }


            catch (Exception error)
            {

                return false; 
            }
        }
        //llamar el metodo del service el buscar y el eliminar 
    }
}
