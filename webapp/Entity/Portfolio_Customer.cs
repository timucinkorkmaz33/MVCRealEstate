using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartAdminMvc.Entity
{
    public class Portfolio_Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Portfolio_Customer()
        {
            Portfolio_CustomerRequest = new HashSet<Portfolio_CustomerRequest>();
            Portfolio_General = new HashSet<Portfolio_General>();
        }
        public int Id { get; set; }
        public int? Pg_Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "İsim")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Soyisim")]
        public string Surname { get; set; }

      
        [StringLength(50)]
        [Display(Name = "E-Mail")]
        public string EMail { get; set; }

        [StringLength(50)]
        [Display(Name = "Telefon1")]
        public string Phone1 { get; set; }

        [StringLength(50)]
        [Display(Name = "Telefon2")]
        public string Phone2 { get; set; }


        [StringLength(500)]
        [Display(Name = "Firma")]
        public string Company { get; set; }

    
        [StringLength(50)]
        [Display(Name = "Ünvan")]
        public string Title { get; set; }

      
        [Display(Name = "Müşteri Tipi")]
        public int Type { get; set; }

        [StringLength(10)]
        [Display(Name = "Bireysel/Kurumsal")]
        public string Individual_Corporate { get; set; }

        [Display(Name = "Alıcı")]
        public bool Buyer { get; set; }

        [Display(Name = "Mülk Sahibi")]
        public bool Seller { get; set; }
        [Display(Name = "Kiracı")]
        public bool Renter { get; set; }

        [Display(Name = "Yatırımcı")]
        public bool Financier { get; set; }

        [Display(Name = "Komisyoncu")]
        public bool MiddleMan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Portfolio_CustomerRequest> Portfolio_CustomerRequest { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Portfolio_General> Portfolio_General { get; set; }
    }
}