namespace SmartAdminMvc.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Portfolio_Detail
    {
        public int Id { get; set; }

        public int? Pg_Id { get; set; }
         [Display(Name = "Kullaným Durumu")]
        public bool Status { get; set; }
          [Display(Name = "Isýnma")]
        public int? Heating { get; set; }
          [Display(Name = "Binadaki Kat Sayýsý")]
        public int? Building_Floor { get; set; }
        [Display(Name = "Bulunduðu Kat")]
        public int? Floor { get; set; }
        [Display(Name = "Kat Karþýlýðý")]
        public bool? Floor_Change { get; set; }
        [Display(Name = "Banyo Sayýsý")]
        public int? Bathroom_Number { get; set; }
        [Display(Name = "Balkon Sayýsý")]
        public int? Balcony_Number { get; set; }
         [Display(Name = "Binanýn Yaþý")]
        public int? Building_Age { get; set; }
         [Display(Name = "Oda Sayýsý")]
        public int? Room_Number { get; set; }
         [Display(Name = "Salon Sayýsý")]
        public int? Saloon_Number { get; set; }
      
         [Display(Name = "Resimler")]
        public string Image { get; set; }

        public virtual Portfolio_General Portfolio_General { get; set; }
    }
}
