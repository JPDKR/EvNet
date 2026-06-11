using EvNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvNet.Data.DataAccess
{
    public class CiudadAccess : IABM<Ciudades>
    {
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

        public List<Ciudades> ObtenerTodos()
        {
            using (var context = new EvNetEntities())
            {
                return context.Ciudades.ToList();
            }
        }
    }
}
