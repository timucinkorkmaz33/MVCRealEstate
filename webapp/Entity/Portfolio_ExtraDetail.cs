namespace SmartAdminMvc.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Portfolio_ExtraDetail
    {
        public int Id { get; set; }

        public int? Pg_Id { get; set; }
         [Display(Name = "Kuzey")]
        public bool North { get; set; }
         [Display(Name = "G�ney")]
         public bool Sourth { get; set; }
         [Display(Name = "Do�u")]
         public bool East { get; set; }
         [Display(Name = "Bat�")]
         public bool West { get; set; }

         [Display(Name = "Fiber")]
         public bool Fiber { get; set; }
         [Display(Name = "Uydu")]
         public bool Satellite { get; set; }
         [Display(Name = "Kablo Tv")]
         public bool Cable_tv { get; set; }
         [Display(Name = "ADSL")]
         public bool Adsl { get; set; }
         [Display(Name = "Fax")]
         public bool Fax { get; set; }
         [Display(Name = "Telefon")]
         public bool Phone { get; set; }
         [Display(Name = "Wi-Fi")]
         public bool WiFi { get; set; }


         [Display(Name = "Asans�r")]
         public bool Elevator { get; set; }
         [Display(Name = "Havuz")]
         public bool Pool { get; set; }
         [Display(Name = "�ocuk Park�")]
         public bool Child_Park { get; set; }
         [Display(Name = "Garaj")]
         public bool Garage { get; set; }
         [Display(Name = "Bah�e")]
         public bool Garden { get; set; }
         [Display(Name = "Yang�n Merdiveni")]
         public bool Fire_Stairs { get; set; }
         [Display(Name = "G�venlik")]
         public bool Securityman { get; set; }
         [Display(Name = "Jenerat�r")]
         public bool Generator { get; set; }

         [Display(Name = "Kamera")]
         public bool Camera { get; set; }
         [Display(Name = "Yang�n Alarm�")]
         public bool Fire_Alarm { get; set; }
         [Display(Name = "H�rs�z Alarm�")]
         public bool Thief_Alarm { get; set; }



         [Display(Name = "Deniz")]
         public bool Sea { get; set; }
         [Display(Name = "Bo�az")]
         public bool Throat { get; set; }
         [Display(Name = "Da�")]
         public bool Mountain { get; set; }
         [Display(Name = "�ehir")]
         public bool City { get; set; }
         [Display(Name = "Do�a")]
         public bool Nature { get; set; }
         [Display(Name = "G�l")]
         public bool Lake { get; set; }

        public virtual Portfolio_General Portfolio_General { get; set; }
    }
}
