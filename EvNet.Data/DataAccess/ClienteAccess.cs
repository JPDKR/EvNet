using EvNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    cliente.Email = obj.Email;
                    cliente.Password = obj.Password;
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
            using (var context = new EvNetEntities())
            {
                return context.Clientes.Where(c => c.Email.ToLower().Equals(email.ToLower()) && c.Password.ToLower().Equals(password.ToLower())).FirstOrDefault();
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
