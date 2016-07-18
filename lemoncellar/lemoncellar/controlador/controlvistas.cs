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
                               select new { material.NOMBRE, material.TIPO, material.MEDIDA, material.CANTIDAD, material.ID_MATERIAL};
                               
                return consulta.ToList<object>();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<object> buscarherra(string buscar)
        {
            try
            {
                var consulta = from herra in contexto.HERRAMIENTA
                               where herra.ESTADO.Equals("activo") && herra.NOMBRE == buscar
                               select herra;

                return consulta.ToList<object>();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<object> buscarherras()
        {
            try
            {
                var consulta = from herra in contexto.HERRAMIENTA
                               where herra.ESTADO.Equals("activo") 
                               select herra;

                return consulta.ToList<object>();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<object> listaherramientaL()
        {
            try
            {
                var consulta = from herra in contexto.HERRAMIENTA
                               
                               select new { herra.NOMBRE, herra.DETALLE, herra.FECHA, herra.ESTADO, herra.VALOR };

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
                               where herra.ESTADO == "activo"
                               select new { herra.NOMBRE, herra.DETALLE, herra.FECHA
                               };

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
        public List<object> listaconsumibleI()
        {
            try
            {
                var consulta = from consu in contexto.CONSUMIBLE_I
                               join con in contexto.CONSUMIBLE on consu.ID_CONSUMIBLE equals con.ID_CONSUMIBLE
                               select new { con.NOMBRE, con.DETALLE,  consu.FECHA, consu.VALOR , consu.CANTIDAD_IC };

                return consulta.ToList<object>();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<object> listaconsumibleG()
        {
            try
            {
                var consulta = from consu in contexto.CONSUMIBLE_G
                               join con in contexto.CONSUMIBLE on consu.ID_CONSUMIBLE equals con.ID_CONSUMIBLE
                               select new { con.NOMBRE,  consu.FECHA, consu.DETALLE ,consu.CANTIDAD_SC };

                return consulta.ToList<object>();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<object> listamaterialI()
        {
            try
            {
                var consulta = from mat in contexto.MATERIAL_I
                               join ma in contexto.MATERIAL on mat.ID_MATERIAL equals ma.ID_MATERIAL
                               select new { ma.NOMBRE, ma.TIPO, ma.MEDIDA, mat.FECHA, mat.VALOR,mat.CANTIDAD_IM };

                return consulta.ToList<object>();
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<object> listamaterialS()
        {
            try
            {
                var consulta = from mat in contexto.MATERIAL_S
                               join ma in contexto.MATERIAL on mat.ID_MATERIAL equals ma.ID_MATERIAL
                               select new { ma.NOMBRE, ma.TIPO, ma.MEDIDA, mat.FECHA, mat.OPERADOR, mat.CANTIDAD_SM, mat.DETALLE };

                return consulta.ToList<object>();
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}