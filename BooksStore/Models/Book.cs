using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BooksStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "Cover")]
        public string CoverUrl { get; set; }

        [Display(Name = "Name")]
        [StringLength(500, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Author")]
        [Required]
        [StringLength(500, MinimumLength = 2)]
        public string Author { get; set; }

        [Display(Name = "Year")]
        [Required]
        public int Year { get; set; }

        [Display(Name = "Month")]
        [Range(1, 12)]
        [Required]
        public int Month { get; set; }

        [Display(Name = "Price")]
        [Required]
        public float Price { get; set; }
    }
}