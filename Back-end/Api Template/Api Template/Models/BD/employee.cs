//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api_control_comercio.Models.BD
{
    using System;
    using System.Collections.Generic;
    
    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            this.user = new HashSet<user>();
        }
    
        public System.Guid employee_id { get; set; }
        public Nullable<int> employee_dni { get; set; }
        public string employee_name { get; set; }
        public string employee_lastname { get; set; }
        public string employee_address { get; set; }
        public Nullable<int> employee_cellphone { get; set; }
        public Nullable<System.Guid> physical_location_id { get; set; }
        public Nullable<System.DateTime> creation_date { get; set; }
        public Nullable<System.DateTime> modification_date { get; set; }
    
        public virtual physical_location physical_location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> user { get; set; }
    }
}
