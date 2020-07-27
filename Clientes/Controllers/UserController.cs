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
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;


namespace User.Controllers
{
    public class UserController : Controller
    { 
        private ClientesServices _ClienteServices { get; set;}

        public UserController(ClientesContext db) 
        {
            this._ClienteServices = new ClientesServices(db) ;
        } 
        
        public IActionResult Login()
        {            
            string Token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            string id = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if(Token != null)
            {
                if(_ClienteServices.ValidateToken(Token, id))
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();

        }

//        var userInfo= HttpContext.Session.GetObjectFromJson<string>("SessionToken");
//        HttpContext.Session.Remove("UserInfo");

        [HttpPost]
        public bool Login(Usuario Data)
        {
            Usuario userFinded = _ClienteServices.GetUserByCredentials(Data);

            if (userFinded != null)
            {
                string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                // userFinded.Token = token;
                _ClienteServices.UpdateUserToken(userFinded, token);
                HttpContext.Session.SetObjectAsJson("SessionToken", token);
                HttpContext.Session.SetObjectAsJson("SessionUserID", userFinded.Id);

                return true; 
            }
            else
            {
                return false;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
