using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace uStoreMVCconvert.Models
{
    public class ContactViewModel
    {


        [Required(ErrorMessage = "Required***")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address***")]
        [Required(ErrorMessage = "Required***")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required***")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Required***")]
        public string Message { get; set; }


    }
}