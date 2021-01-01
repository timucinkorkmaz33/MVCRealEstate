using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartAdminMvc.Entity
{
    public class Portfolio_Banks
    {
        public int Id { get; set; }
        [Display(Name = "Banka Adı")]
        public string BankName { get; set; }
        [Display(Name = "Güncelleme Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; }
        [Display(Name = "Aylık Faiz(5 Yıl)")]
        public float? FiveYear { get; set; }
         [Display(Name = "Aylık Faiz(10 Yıl)")]
        public float? TenYear { get; set; }
         [Display(Name = "Aylık Faiz(15 Yıl)")]
         public float? FifteenYear { get; set; }
       
    }
}