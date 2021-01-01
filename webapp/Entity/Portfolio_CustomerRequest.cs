using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartAdminMvc.Entity
{
    public class Portfolio_CustomerRequest
    {
   

        public int Id { get; set; }
        public int C_Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Müşteri Tipi")]
        public string Status { get; set; }

         [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Bitiş Tarihi")]
        public DateTime FinishDate { get; set; }

        [Display(Name = "Arsa")]
        public bool Land { get; set; }

        [Display(Name = "Konut")]
        public bool Housing { get; set; }
        [Display(Name = "Ofis")]
        public bool Office { get; set; }


        [StringLength(50)]
        [Display(Name = "Şehir")]
        public string Country { get; set; }

 
        [StringLength(50)]
        [Display(Name = "İlçe")]
        public string City { get; set; }

        

        
        [Display(Name = "Fiyat Aralığı")]
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
      
        [Display(Name = "m^2 Aralığı")]
        public string MinArea { get; set; }
        public string MaxArea { get; set; }

        

        [Display(Name = "Kat Karşılığı")]
        public bool FloorChange { get; set; }

        [Display(Name = "Kentsel Dönüşüm")]
        public bool Transformation { get; set; }
        [Display(Name = "Notlar")]
        public string Note { get; set; }

        public virtual Portfolio_Customer Portfolio_Customer { get; set; }
    }
}