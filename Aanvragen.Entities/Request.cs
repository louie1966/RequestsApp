using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aanvragen.Entities {
    public class Request {
        public int ID { get; set; }

        public string RequestNumber { get; set; }

        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Display(Name = "Omschrijving")]
        public string Description { get; set; }

        public RequestType Type { get; set; }

        public RequestStatus Status { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Aangemaakt")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Begin")]
        public DateTime Start { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Eind")]
        public DateTime End { get; set; }

        public int CompanyID { get; set; }

        [Display(Name = "Actief"), DefaultValue(true)]
        public bool Active { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<RequestAttachment> RequestAttachments { get; set; }
    }
}
