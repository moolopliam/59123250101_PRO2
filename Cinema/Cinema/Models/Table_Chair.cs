//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cinema.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Table_Chair
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table_Chair()
        {
            this.Table_DetailOder = new HashSet<Table_DetailOder>();
        }
    
        public int C_ChairID { get; set; }
        public string C_NameChair { get; set; }
        public Nullable<int> C_SatatusID { get; set; }
        public Nullable<int> C_ScreenID { get; set; }
        public Nullable<int> C_Price { get; set; }
    
        public virtual Table_Screen Table_Screen { get; set; }
        public virtual Table_StatusChire Table_StatusChire { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_DetailOder> Table_DetailOder { get; set; }
    }
}
