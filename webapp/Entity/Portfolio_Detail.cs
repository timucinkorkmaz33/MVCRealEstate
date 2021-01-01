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
         [Display(Name = "Kullan�m Durumu")]
        public bool Status { get; set; }
          [Display(Name = "Is�nma")]
        public int? Heating { get; set; }
          [Display(Name = "Binadaki Kat Say�s�")]
        public int? Building_Floor { get; set; }
        [Display(Name = "Bulundu�u Kat")]
        public int? Floor { get; set; }
        [Display(Name = "Kat Kar��l���")]
        public bool? Floor_Change { get; set; }
        [Display(Name = "Banyo Say�s�")]
        public int? Bathroom_Number { get; set; }
        [Display(Name = "Balkon Say�s�")]
        public int? Balcony_Number { get; set; }
         [Display(Name = "Binan�n Ya��")]
        public int? Building_Age { get; set; }
         [Display(Name = "Oda Say�s�")]
        public int? Room_Number { get; set; }
         [Display(Name = "Salon Say�s�")]
        public int? Saloon_Number { get; set; }
      
         [Display(Name = "Resimler")]
        public string Image { get; set; }

        public virtual Portfolio_General Portfolio_General { get; set; }
    }
}
