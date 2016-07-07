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
                               select new { ma.ID_MATERIAL, ma.NOMBRE, ma.TIPO, ma.MEDIDA, ma.CANTIDAD };

                return consulta.ToList<object>();
            }
            catch (Exception)
            {
                return null;
            }

        }
        public bool agregarherramienta(HERRAMIENTA nuevo)
        {
            try
            {
                modelo.HERRAMIENTA.Add(nuevo);
                return modelo.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool agregarmaterial(MATERIAL nuevo)
        {
            try
            {
                modelo.MATERIAL.Add(nuevo);
                return modelo.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
          
        public bool agregarmaterialI(MATERIAL_I nuevo)
        {
            try
            {
                modelo.MATERIAL_I.Add(nuevo);
                return modelo.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Actualizarmaterial(MATERIAL nueva)
        {
            try
            {
                MATERIAL original = new MATERIAL();
                original = modelo.MATERIAL.Find(nueva.ID_MATERIAL);
                original.CANTIDAD = nueva.CANTIDAD;
                return modelo.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}