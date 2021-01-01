namespace SmartAdminMvc.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Portfolio_Personal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Portfolio_Personal()
        {
            Portfolio_General = new HashSet<Portfolio_General>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Personel Ýsmi")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Personel Soyismi")]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Telefon1")]
        public string Phone1 { get; set; }

       
        [StringLength(50)]
        [Display(Name = "Telefon2")]
        public string Phone2 { get; set; }

        [Required]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "TC Kimlik No")]
        public string TC { get; set; }

        
        [StringLength(50)]
        [Display(Name = "Doðum Yeri")]
        public string BirthPlace { get; set; }

        [Display(Name = "Doðum Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Ehliyet Tipi")]
        public string Driving_Licence { get; set; }

        
        [Display(Name = "Resim")]
        public string Image { get; set; }

        
        [StringLength(50)]
        [Display(Name = "Görevi")]
        public string Department { get; set; }

         [Display(Name = "Kullanýcý Kodu")]
        public string UserId { get; set;}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Portfolio_General> Portfolio_General { get; set; }
    }
}
