using System;
using System.ComponentModel.DataAnnotations;

namespace BLS.Api.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Author")]
        public string Author { get; set; }
        [Display(Name = "ISBN")]
        public string Isbn { get; set; }
        [Display(Name = "Edition")]
        public string Edition { get; set; }
        [Display(Name = "Publisher")]
        public string Publisher { get; set; }
        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }
    }
}