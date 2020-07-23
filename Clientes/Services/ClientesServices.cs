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
using Remotion.Linq.Clauses;

namespace Clientes.Services
{
    public class ClientesServices
    {
        public readonly ClientesContext _clientesContext;

        public ClientesServices()
        {
            _clientesContext = new ClientesContext();
        }

        public List<ClienteModel> Obtener()
        {
            var resultado = _clientesContext.Clientes.ToList();
            List<ClienteModel> clientes = new List<ClienteModel>();

            foreach (var item in resultado)
            {
                ClienteModel cliente = new ClienteModel() {
                    Id = item.Id,
                    Cuenta = item.Cuenta,
                    Contraseña = item.Contraseña,
                    Email = item.Email,
                    Nombre = item.Nombre,
                    Pantallas= item.Pantallas, 
                    VencimientoC = item.VencimientoC,
                    VencimientoP=item.VencimientoP,

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

        public Boolean Agregar(Models.Clientes _clientes )
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

        public  Boolean Delete(Models.Clientes clientes)
        {
            try { 
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
            var x = _clientesContext.Clientes.FirstOrDefault(l=> l.Id == id);

            return x;
            
            
        }

       
        //crear un metodo q busque el id q coincida con el que estoy seleccionando




    }

    

    




}
