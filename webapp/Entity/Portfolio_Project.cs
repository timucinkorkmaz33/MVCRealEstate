using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartAdminMvc.Entity
{
    public class Portfolio_Project
    { 
 
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Proje Tipi")]
        public string Type { get; set; }
         
        [StringLength(50)]
        [Display(Name = "Proje Oranı")]
        public string Rate { get; set; }
        [StringLength(50)]
        [Display(Name = "Proje Durumu")]
        public string ProjectStatus { get; set; }
        [StringLength(50)]
        
        [Display(Name = "Tamamlanma Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string FinishDate { get; set; }
         [Required]
     
        [Display(Name = "Firma")]
        public int? Company_Id { get; set; }
        [StringLength(50)]
         [Required]
        [Display(Name = "Başlık")]
        public string Header { get; set; }
        [StringLength(50)]
        [Display(Name = "Özel Başlık")]
        public string Special_Header { get; set; }
        [StringLength(50)]
        [Display(Name = "Açıklama")]
        public string Project_Description { get; set; }

        public virtual Portfolio_Company Portfolio_Company { get; set; }
       
    }
}