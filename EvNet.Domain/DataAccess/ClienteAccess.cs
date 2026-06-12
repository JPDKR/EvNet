using EvNet.Domain.Context;
using EvNet.Domain.Entities;
using EvNet.Domain.Interfaces;
using EvNet.Domain.Security;

namespace EvNet.Domain.DataAccess
{
    public class ClienteAccess(EvNetContext context) : IABM<Clientes>
    {
        private readonly EvNetContext _context = context;

        public int Insertar(Clientes obj)
        {
            try
            {
                if (string.IsNullOrEmpty(obj.Password))
                {
                    throw new ArgumentException("La contraseña es obligatoria.", nameof(obj.Password));
                }

                obj.Password = PasswordHelper.Hash(obj.Password);
                _context.Clientes.Add(obj);

                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Eliminar(int id)
        {
            try
            {
                var cliente = _context.Clientes.Where(c => c.Id == id).FirstOrDefault();

                if (cliente != null)
                {
                    _context.Clientes.Remove(cliente);

                    return _context.SaveChanges();
                }
                else return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Modificar(Clientes obj)
        {
            try
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.Id.Equals(obj.Id))!;

                cliente.Id = obj.Id;
                cliente.Nombre = obj.Nombre;
                cliente.Apellido = obj.Apellido;
                cliente.Domicilio = obj.Domicilio;
                cliente.Email = obj.Email;
                cliente.Password = string.IsNullOrEmpty(obj.Password) ? cliente.Password : PasswordHelper.Hash(obj.Password);
                cliente.IdCiudad = obj.IdCiudad;
                cliente.Habilitado = obj.Habilitado;

                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Clientes Obtener(int id) => _context.Clientes.FirstOrDefault(c => c.Id == id)!;

        public Clientes Obtener(string email, string password)
        {
            var hashedPassword = PasswordHelper.Hash(password);
            return _context.Clientes
                .FirstOrDefault(c => c.Email == email && c.Password == hashedPassword)!;
        }

        public List<Clientes> ObtenerTodos() => [.. _context.Clientes];
    }
}
