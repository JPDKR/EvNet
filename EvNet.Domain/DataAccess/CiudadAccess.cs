using EvNet.Domain.Context;
using EvNet.Domain.Entities;
using EvNet.Domain.Interfaces;

namespace EvNet.Domain.DataAccess
{
    public class CiudadAccess(EvNetContext context) : IABM<Ciudades>
    {
        private readonly EvNetContext _context = context;

        public int Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public int Insertar(Ciudades obj)
        {
            throw new NotImplementedException();
        }

        public int Modificar(Ciudades obj)
        {
            throw new NotImplementedException();
        }

        public Ciudades Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ciudades> ObtenerTodos() => [.. _context.Ciudades];
    }
}
