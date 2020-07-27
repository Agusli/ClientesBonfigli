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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Remotion.Linq.Clauses;

namespace Clientes.Services
{
    public class ClientesServices
    {
        public readonly ClientesContext _clientesContext;

        public ClientesServices(ClientesContext db)
        {
            _clientesContext = db;
        }

        public List<ClienteModel> Obtener()
        {
            var resultado = _clientesContext.Clientes.ToList();
            List<ClienteModel> clientes = new List<ClienteModel>();

            foreach (var item in resultado)
            {
                ClienteModel cliente = new ClienteModel()
                {
                    Id = item.Id,
                    Cuenta = item.Cuenta,
                    Contraseña = item.Contraseña,
                    Email = item.Email,
                    Nombre = item.Nombre,
                    Pantallas = item.Pantallas,
                    VencimientoC = item.VencimientoC,
                    VencimientoP = item.VencimientoP,

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
                _clientesContext.Clientes.Add(_cliente);
                _clientesContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
            

           
        }

       public bool Actualizar (Models.Clientes data)
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
            try{
                _clientesContext.Usuario.FirstOrDefault(u => u.Id == data.Id).Token = token;
                _clientesContext.SaveChanges();
                return true;
            }
            catch(Exception e){
                return false;
            }
        }

        public bool ValidateToken(string token, string id)
        {
            Usuario user = _clientesContext.Usuario.FirstOrDefault(u => u.Id == int.Parse(id));

            if(user != null)
            {
                if(user.Token == token)
                {
                    return true;
                }
            }        
            
            return false;            

        }

    }

}
