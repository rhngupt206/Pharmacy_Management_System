//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pharma_Library
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Seller_details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seller_details()
        {
            this.Billing_details = new HashSet<Billing_details>();
        }
        
        public int SelId { get; set; }
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage ="Only letters are allowed")]
        public string SelName { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string SelEmail { get; set; }
        [Display(Name = "Password")]
        public string SelPwd { get; set; }
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        public System.DateTime SelDOB { get; set; }
        [Display(Name = "Gender")]
        public string SelGen { get; set; }
        [Display(Name = "Address")]
        public string SelAdd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Billing_details> Billing_details { get; set; }
    }
}