using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrate
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactUserName { get; set; }
        public string ContactMail { get; set; }
        public int ContactSubject { get; set; }
        public int ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }
        public bool ContactStatus { get; set; }

    }
}
