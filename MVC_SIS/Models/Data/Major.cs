﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Major
    {
        public int MajorId { get; set; }
        [Required(ErrorMessage = "Can not be blank")]
        public string MajorName { get; set; }
    }
}