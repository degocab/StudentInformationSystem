using Exercises.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Address
    {
        [Required(ErrorMessage ="Can not be blank")]
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Can not be blank")]
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required(ErrorMessage = "Can not be blank")]
        public string City { get; set; }
        public State State { get; set; }
        [Required(ErrorMessage = "Can not be blank")]
        
        public string PostalCode { get; set; }
    }
}