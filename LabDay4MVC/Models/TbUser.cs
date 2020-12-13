namespace LabDay4MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("TbUser")]
    public partial class TbUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TbUser()
        {
            TbNews = new HashSet<TbNew>();
        }

        public int id { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage ="*")]
        [StringLength(50)]
       [Remote("check", "User", ErrorMessage = "Exit Name")]
        public string name { get; set; }
        //[DisplayName("E-Mail")]
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "invalid email")]


        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "*")]
        [DisplayName("Password")]

        public string password { get; set; }
        [NotMapped]
        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "*")]
        [System.ComponentModel.DataAnnotations.Compare("password", ErrorMessage = "password not match")]
        public string confirm_password { get; set; }
        [DisplayName("Age")]

        [Range(20, 60, ErrorMessage = "age must between 20 and 60")]

        public int? age { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TbNew> TbNews { get; set; }
    }
}
