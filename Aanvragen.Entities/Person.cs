using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aanvragen.Entities {
    public class Person {
        public int ID { get; set; }

        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Display(Name = "Tussenvoegsel")]
        public string Preposition { get; set; }

        [Display(Name = "Achternaam")]
        public string LastName { get; set; }

        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Display(Name = "Telefoon")]
        public string Phone { get; set; }

        [Display(Name = "Actief"), DefaultValue(true)]
        public bool Active { get; set; }

        public int CompanyID { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Toevoeging")]
        public string AddressAddition { get; set; }

        [Display(Name = "Postcode")]
        public string ZipCode { get; set; }

        [Display(Name = "Woonplaats")]
        public string City { get; set; }

        [Display(Name = "Rol")]
        public Role Role { get; set; }

        public HireType HireType { get; set; }

        public virtual ICollection<PersonAttachment> PersonAttachments { get; set; }

        public virtual Company Company { get; set; }
    }

    public enum HireType {
        Inhuur, Verhuur, Geen, Overig
    }

    public enum Role {
        Operationmanager, Accountmanager, Directeur, Jobcoach, Overig
    }

}
