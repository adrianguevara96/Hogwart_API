using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwart_API.Models
{
    public class Request
    {
        public int id { get; set; }

        [Required]
        [RegularExpression(@"^[ a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Name cannot be longer than 20 characters and less than 1 characters")]
        public string name { get; set; }

        [Required]
        [RegularExpression(@"^[ a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Lastname cannot be longer than 20 characters and less than 1 characters")]
        public string lastname { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage = "Identity cannot be longer than 10 numbers and less than 1 number")]
        public long identification { get; set; }

        [Required]
        [RegularExpression(@"^\d{1,2}$", ErrorMessage = "Age cannot be longer than 2 numbers and less than 1 number")]
        public int age { get; set; }

        [Required]
        public string house { get; set; }

    }
}
