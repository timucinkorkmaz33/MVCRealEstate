using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartAdminMvc.Entity
{
    public class Portfolio_Contract
    {

        public Portfolio_Contract()
        {
            Portfolio_General = new HashSet<Portfolio_General>();
        }

        public int Id { get; set; }
        // public int? Pg_Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Başlangıç Tarihi")]
       
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Bitiş Tarihi")]
        
        public DateTime FinishDate { get; set; }
        [Display(Name = "Alıcıdan Alınacak Oran")]
        public string Buyer_Rate { get; set; }
        [Display(Name = "Satıcıdan Alınacak Oran")]
        public string Seller_Rate { get; set; }
        [Display(Name = "Minimum Alış/Kiralama Bedeli")]
       
        public string MinPrice { get; set; }
        [Display(Name = "Maximum Alış/Kiralama Bedeli")]
      
        public string MaxPrice { get; set; }
        [Display(Name = "Alıcıdan Alınacak Hizmet Bedeli")]
        public string Buyer_ServicePrice { get; set; }
        [Display(Name = "Satıcıdan Alınacak Hizmet Bedeli")]
        public string Seller_ServicePrice { get; set; }
        [Display(Name = "Sözleşme No")]
        public string ContractNumber { get; set; }
        [Display(Name = "Yetki Belgesi")]
        public string AuthorityDocument { get; set; }

        public virtual ICollection<Portfolio_General> Portfolio_General { get; set; }
    }
}