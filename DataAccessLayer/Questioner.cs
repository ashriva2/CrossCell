//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Questioner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Questioner()
        {
            this.Objectives = new HashSet<Objective>();
        }
    
        public int Questioner_Id { get; set; }
        public int Metadata_Id { get; set; }
        public string Questioner1 { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Metadata Metadata { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Objective> Objectives { get; set; }
    }
}
