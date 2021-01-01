namespace SmartAdminMvc.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Portfolio_General
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Portfolio_General()
        {
            Portfolio_Address = new HashSet<Portfolio_Address>();
            Portfolio_Detail = new HashSet<Portfolio_Detail>();
            Portfolio_ExtraDetail = new HashSet<Portfolio_ExtraDetail>();


        }
        [Display(Name = "PortFöy Number")]
        public int? Id { get; set; }
        [Display(Name = "Gayrimenkul Tipi")]
        public int? Type { get; set; }
        [Display(Name = "Gayrimenkul Durumu")]
        public int? Type_State { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Baþlýk")]

        public string Header { get; set; }
        [Display(Name = "Durum")]
        public int Status { get; set; }
        [Required]
        [Display(Name = "Açýklama")]
        public string Description { get; set; }
        [Display(Name = "Gayrimenkul Alaný(m^2)")]
        public int? Area_Brut { get; set; }

        [Display(Name = "Gayrimenkul Alaný(m^2)")]
        public int? Area_Net { get; set; }

        [Display(Name = "Aylýk Gider(Aydat)")]
        public int? Subscription { get; set; }
        [Display(Name = "Fiyatý")]
        public int? Price { get; set; }
        [Display(Name = "Fiyat Tipi")]

        public int? Price_Type { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Giriþ Tarihi")]
        public DateTime Date { get; set; }

     
        [Display(Name = "Yorum")]
        public string Comment { get; set; }
        [Display(Name = "Krediye Uygunluk")]
        public bool? Credit { get; set; }
        [Display(Name = "Personel Kimliði")]
        public string Personal_Id { get; set; }

        [Display(Name = "Müþteri Kimliði")]
        public int? Customer_Id { get; set; }

        [Display(Name = "Sözleþme")]
        public int? Contract_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Portfolio_Address> Portfolio_Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Portfolio_Detail> Portfolio_Detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Portfolio_ExtraDetail> Portfolio_ExtraDetail { get; set; }

        public virtual Portfolio_Contract Portfolio_Contract { get; set; }
        public virtual Portfolio_Personal Portfolio_Personal { get; set; }
        public virtual Portfolio_Customer Portfolio_Customer { get; set; }
    }
}
