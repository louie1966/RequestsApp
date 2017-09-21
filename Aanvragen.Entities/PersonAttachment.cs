using System.ComponentModel.DataAnnotations;

namespace Aanvragen.Entities {
    public class PersonAttachment {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public int AttachmentID { get; set; }

        [Display(Name = "Actie")]
        public AttachmentAction Action { get; set; }

        public virtual Person Person { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
