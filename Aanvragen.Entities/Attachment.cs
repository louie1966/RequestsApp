using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Aanvragen.Entities {
    public class Attachment {
        public int ID { get; set; }

        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Display(Name = "Omschrijving")]
        public string Description { get; set; }

        [Display(Name = "Bestandsnaam")]
        public string FileName { get; set; }

        [Display(Name = "Extentie")]
        public string Extention { get; set; }

        [Display(Name = "Link")]
        public string Url { get; set; }

        [Display(Name = "Actief"), DefaultValue(true)]
        public bool Active { get; set; }

        public AttachmentType Type { get; set; }

        public virtual ICollection<RequestAttachment> RequestAttachments { get; set; }
        public virtual ICollection<PersonAttachment> PersonAttachments { get; set; }
    }
}
