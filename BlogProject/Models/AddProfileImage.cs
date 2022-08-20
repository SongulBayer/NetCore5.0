using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore5._0.Models
{
    public class AddProfileImage
    {
        public int WriterId { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterMail { get; set; }
        public IFormFile WriterImage { get; set; }
        public bool WriterStatus { get; set; }
        public string WriterPassword { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
