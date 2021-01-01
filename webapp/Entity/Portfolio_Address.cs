namespace SmartAdminMvc.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Portfolio_Address
    {
        public int Id { get; set; }

        public int? Pg_Id { get; set; }

       
        [StringLength(50)]
        [Display(Name = "Þehir")]
        public string Country { get; set; }

        
        [StringLength(50)]
        [Display(Name = "Ýlçe")]
        public string City { get; set; }

        
        [StringLength(500)]
        [Display(Name = "Mahalle")]
        public string District { get; set; }

        
        [Display(Name = "Adres")]
        public string Address { get; set; }

        
        [StringLength(500)]
        [Display(Name = "Site Adý")]
        public string Site_Name { get; set; }
        [Display(Name = "KonumX")]
        public string Latitude { get; set; }
        [Display(Name = "KonumY")]
        public string Longitude { get; set; }

        public virtual Portfolio_General Portfolio_General { get; set; }
    }
}
