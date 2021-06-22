using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SATProject.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage ="Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Subject Required")]
        public string Subject { get; set; }
        [UIHint("MultilineTex")]
        [Required(ErrorMessage ="Message Required")]
        public string Message { get; set; }
    }
}