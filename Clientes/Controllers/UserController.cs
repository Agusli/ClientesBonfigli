using System;
using System.IO;
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
        private ClientesServices _ClienteServices { get; set; }

        public UserController(ClientesContext db)
        {
            this._ClienteServices = new ClientesServices(db);
        }

        public IActionResult Login()
        {
            string Token = HttpContext.Session.GetObjectFromJson<string>("SessionToken");
            string id = HttpContext.Session.GetObjectFromJson<string>("SessionUserID");

            if (Token != null)
            {
                if (_ClienteServices.ValidateToken(Token, id))
                {

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();

        }

        //Metodo para leer data de un archivo y cargarlo a la bd

        //static List<Clientes.Models.Clientes> ReadFile()
        //{
        //    using (var reader = new StreamReader(@"C:\Cuentas.csv"))
        //    {
        //        List<Clientes.Models.Clientes> listA = new List<Clientes.Models.Clientes>();
        //        int contador = 0;
        //        try
        //        {
        //            while (!reader.EndOfStream)
        //            {
        //                var line = reader.ReadLine();
        //                var values = line.Split(',');
        //                var vencimientoP = values[3].Split("/");
        //                var vencimientoC = values[4].Split("/");

        //                listA.Add(new Clientes.Models.Clientes()
        //                {
        //                    Cuenta = values[0],
        //                    Email = values[1],
        //                    Contraseña = values[2],
        //                    VencimientoP = new DateTime(2020, int.Parse(vencimientoP[1]), int.Parse(vencimientoP[0])),
        //                    VencimientoC = new DateTime(2020, int.Parse(vencimientoC[1]), int.Parse(vencimientoC[0])),
        //                    Nombre = values[5],
        //                    Tipo = int.Parse(values[6]),
        //                    Pantallas = values[7],
        //                    Comentario = values[8]
        //                });
        //                contador++;
        //            }

        //            return listA;
        //        }
        //        catch (Exception e)
        //        {
        //            return listA;
        //        }

        //    }
        //}

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
