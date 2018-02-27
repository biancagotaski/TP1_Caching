using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstApplication.Models
{
    public class PessoaViewModel
    {

        public int Id { get; set; }

        //DataAnnotations
        [Required]
        [StringLength(60)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Nome { get; set; }

        //DataAnnotations
        [Required]
        [StringLength(60)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Sobrenome { get; set; }

        //DataAnnotations
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Nascimento { get; set; }

        public bool IsChecked { get; set; }

    }
}