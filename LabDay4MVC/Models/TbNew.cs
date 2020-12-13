namespace LabDay4MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TbNew
    {
        public int id { get; set; }
        [Required(ErrorMessage ="*")]
        [StringLength(50)]
        [DisplayName("Title")]

        public string title { get; set; }
        [DisplayName("Pref")]
        [Required(ErrorMessage = "*")]


        public string pref { get; set; }
        [DisplayName("Description")]
        [Required(ErrorMessage = "*")]

        public string description { get; set; }

        [StringLength(50)]
        [DisplayName("Photo")]

        public string photo { get; set; }

        [Column("User-id")]
        public int? User_id { get; set; }
        [DisplayName("Catalog-Name")]

        public int? Catalog_id { get; set; }
        public DateTime? date { get; set; }


        public virtual TbCatalog TbCatalog { get; set; }

        public virtual TbUser TbUser { get; set; }
    }
}
