//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lemoncellar.modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class MATERIAL_S
    {
        public int ID_MATERIAL_S { get; set; }
        public Nullable<int> ID_MATERIAL { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public string OPERADOR { get; set; }
        public Nullable<int> CANTIDAD_SM { get; set; }
        public string DETALLE { get; set; }
    
        public virtual MATERIAL MATERIAL { get; set; }
    }
}
