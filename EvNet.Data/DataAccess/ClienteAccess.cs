using EvNet.Data.Interfaces;
using EvNet.Data.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvNet.Data.DataAccess
{
    public class ClienteAccess : IABM<Clientes>
    {
        public ClienteAccess()
        {

        }

        public int Insertar(Clientes obj)
        {
            try
            {
                using (var context = new EvNetEntities())
                {
                    obj.Password = PasswordHelper.Hash(obj.Password);
                    context.Clientes.Add(obj);

                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int Eliminar(int id)
        {
            try
            {
                using (var context = new EvNetEntities())
                {
                    var cliente = context.Clientes.Where(c => c.Id == id).FirstOrDefault();

                    if (cliente != null)
                    {
                        context.Clientes.Remove(cliente);

                        return context.SaveChanges();
                    }
                    else return -1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int Modificar(Clientes obj)
        {
            try
            {
                using (var context = new EvNetEntities())
                {
                    var cliente = context.Clientes.Where(c => c.Id.Equals(obj.Id)).FirstOrDefault();

                    cliente.Id = obj.Id;
                    cliente.Nombre = obj.Nombre;
                    cliente.Apellido = obj.Apellido;
                    cliente.Domicilio = obj.Domicilio;
                    cliente.Email = obj.Email;
                    cliente.Password = string.IsNullOrEmpty(obj.Password) ? cliente.Password : PasswordHelper.Hash(obj.Password);
                    cliente.IdCiudad = obj.IdCiudad;
                    cliente.Habilitado = obj.Habilitado;

                    return context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Clientes Obtener(int id)
        {
            using (var context = new EvNetEntities())
            {
                return context.Clientes.Where(c => c.Id == id).FirstOrDefault();
            }
        }
        
        public Clientes Obtener(string email, string password)
        {
            var hashedPassword = PasswordHelper.Hash(password);
            using (var context = new EvNetEntities())
            {
                return context.Clientes
                    .Where(c => c.Email.ToLower() == email.ToLower() && c.Password == hashedPassword)
                    .FirstOrDefault();
            }
        }

        public List<Clientes> ObtenerTodos()
        {
            using (var context = new EvNetEntities())
            {
                return context.Clientes.ToList();
            }
        }
    }
}
