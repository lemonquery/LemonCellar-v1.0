using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lemoncellar.modelo;

namespace lemoncellar.controlador
{
    public class controlvistas
    {
        lemoncellarEntities contexto = new lemoncellarEntities();
        public List<object> listamaterial() {
            try
            {
                var consulta = from material in contexto.MATERIAL
                               where material.CANTIDAD > 0
                               select new { material.NOMBRE, material.TIPO, material.MEDIDA, material.CANTIDAD };
                               
                return consulta.ToList<object>();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<object> listaherramienta()
        {
            try
            {
                var consulta = from herra in contexto.HERRAMIENTA
                               where herra.ESTADO.Equals("activo")
                               select new { herra.NOMBRE, herra.DETALLE, herra.FECHA};

                return consulta.ToList<object>();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<object> listaconsumible()
        {
            try
            {
                var consulta = from consu in contexto.CONSUMIBLE
                               select new { consu.NOMBRE, consu.CANTIDAD, consu.DETALLE };

                return consulta.ToList<object>();
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}