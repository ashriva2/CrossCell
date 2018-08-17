//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrossSell_App.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Portfolio_Agile_Lab
    {
        public int Pal_Id { get; set; }
        public int Company_Id { get; set; }
        public int Portfolio_Id { get; set; }
        [Range(0,10,ErrorMessage = "Company Name is required")]
        [Required(ErrorMessage = "Company Name is required")]
        public int Current_Usage { get; set; }
       
        public bool Future_Scope { get; set; }
        public bool IsMarketLead { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Portfolio Portfolio { get; set; }
    }
}
