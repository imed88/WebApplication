//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApps.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using WebApps.Models;

    public partial class nurses
    {
        
        public ()
        {
            this.patients = new HashSet<patients>();
        }
        [Key]
        public int idNurse { get; set; }
        public string nameNurse { get; set; }
        [EmailAddress]
        [DisplayName("Email")]
        [Required(ErrorMessage = "This field is required")]
        public string emailNurse { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        public string passwordNurse { get; set; }
        public string phoneNurse { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<patients> patients { get; set; }
    }
}
