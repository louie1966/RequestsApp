using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aanvragen.Entities {
    public class Company {
        public int ID { get; set; }

        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Toevoeging")]
        public string AddressAddition { get; set; }

        [Display(Name = "Postcode")]
        public string ZipCode { get; set; }

        [Display(Name = "Woonplaats")]
        public string City { get; set; }

        [Display(Name = "Actief"), DefaultValue(true)]
        public bool Active { get; set; }
    }
}
