using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IA.Model
{
    public class Article
    {
        public int ArticleID { get; set; }

        [Required(ErrorMessage = "Rubrik måste anges.")]
        [StringLength(255, ErrorMessage = "Rubrik kan bestå av som mest 255 tecken.")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Innehåll måste anges.")]
        [StringLength(8000, ErrorMessage = "Innehållet kan bestå av som mest 8000 tecken.")]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AuthorID { get; set; }
    }
}