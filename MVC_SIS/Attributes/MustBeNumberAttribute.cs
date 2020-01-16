using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Attributes
{
    public class MustBeNumberAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            
            if (value is decimal)
            {
                return true;
            }
            return false;
        }
    }
}