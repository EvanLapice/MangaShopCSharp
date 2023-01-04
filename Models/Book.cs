using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSSA_Assignment_12._2.Models
{
    public class Book
    {
        [Display(Name = "Book ID")]
        [Required(ErrorMessage = "Field cannot be empty")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Display(Name = "Book Name")]
        [Required(ErrorMessage = "Field cannot be empty")]
        public string? Name { get; set; }

        [Display(Name = "Author Name")]
        [Required(ErrorMessage = "Field cannot be empty")]
        public string? Author { get; set; }

        [Display(Name = "Product Description")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public string? ImageName { get; set; }
    }
}
