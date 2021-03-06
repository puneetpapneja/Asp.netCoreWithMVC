﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Data
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter book name")]
        public string BookName { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter auther name")]
        [Display(Name = "Book Auther Name")]
        public string AutherName { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        [Required]
        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
