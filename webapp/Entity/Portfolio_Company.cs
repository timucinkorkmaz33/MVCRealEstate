using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartAdminMvc.Entity
{
    public class Portfolio_Company
    {  [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Portfolio_Company()
        {
            Portfolio_Project = new HashSet<Portfolio_Project>();
        }
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "Firma Adı")]
        public string Company_Name { get; set; }
        [StringLength(500)]
        [Display(Name = "Firma WebSitesi")]
        public string Company_Website { get; set; }
        [StringLength(500)]
        [Display(Name = "Firma Ünvanı")]
        public string Company_Title { get; set; }
        [StringLength(50)]
        [Display(Name = "Firma Telefon1")]
        public string Company_Phone1 { get; set; }
        [StringLength(50)]
        [Display(Name = "Firma Telefon2")]
        public string Company_Phone2 { get; set; }
        [StringLength(50)]
        [Display(Name = "Firma E-Mail")]
        public string Company_EMail { get; set; }
        [Display(Name = "Firma Adres")]
        public string Company_Address { get; set; }
        [Required]
        [Display(Name = "Firma Yetkilisi")]
        public string Owner_NameSurname { get; set; }
        [Display(Name = "Ünvanı")]
        public string Owner_Title { get; set; }
        [Display(Name = "Yetkili E-Mail")]
   
        public string Owner_EMail { get; set; }
        [Required]
        [Display(Name = "Yetkili Telefon1")]
        public string Owner_Phone { get; set; }
        [Display(Name = "Yetkili Telefon2")]
        public string Owner_Phone2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<Portfolio_Project> Portfolio_Project { get; set; }
    }
}