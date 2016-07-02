using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lemoncellar.modelo;

namespace lemoncellar.controlador
{
    public class controladorusuario
    {
        lemoncellarEntities contexto = new lemoncellarEntities();
        public bool validarusuario(string nombre, string clave, ref string estado) {
            try
            {
                var consulta = from ui in contexto.USUARIO
                               where ui.NOMBRE.Equals(nombre) && ui.CLAVE.Equals(clave)
                               select ui;
                bool valido = consulta.Count() == 1;
                if (valido == true)
                {
                    string estado_usuario = consulta.First().ESTADO;
                    if (estado_usuario.Equals("activo"))
                    {
                        estado = consulta.First().ESTADO;
                    }
                    else {
                        valido = false;
                    }
                }
                return valido;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}