//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class doctors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public doctors()
        {
            this.patients = new HashSet<patients>();
        }
        [Key]
        public int idDoctors { get; set; }
        [DisplayName("Nom :")]
        [Required(ErrorMessage = "This field is required")]
        public string nameDoctors { get; set; }
        [EmailAddress]
        [DisplayName("Email")]
        [Required(ErrorMessage = "This field is required")]
        public string emailDoctors { get; set; }
        public string phoneDoctors { get; set; }
        public Nullable<int> gender { get; set; }
        public string specialist { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<patients> patients { get; set; }
    }
}
