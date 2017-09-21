using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aanvragen.Entities {
    public class RequestAttachment {
        public int ID { get; set; }
        public int RequestID { get; set; }
        public int AttachmentID { get; set; }

        [Display(Name = "Actie")]
        public AttachmentAction Action { get; set; }

        public virtual Request Request { get; set; }
        public virtual Attachment Attachment { get; set; }

    }
}
