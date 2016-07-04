using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lemoncellar.modelo;

namespace lemoncellar.controlador
{   
    public class controlbuscar
    {
        lemoncellarEntities modelo = new lemoncellarEntities();

        public List<object> buscarmaterial(String buscar)
        {
            try
            {
                var consulta = from ma in modelo.MATERIAL

                               where ma.NOMBRE == buscar
                               select new { ma.NOMBRE, ma.TIPO, ma.MEDIDA, ma.CANTIDAD};

                return consulta.ToList<object>();
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}