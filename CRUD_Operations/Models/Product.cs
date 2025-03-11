using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Operations.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        /*
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and spaces are allowed.")]
        */
        public string Name { get; set; }

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
        [Required, Range(0, int.MaxValue, ErrorMessage = "Stock Quantity must be a non-negative integer.")]
        public int StockQuantity {  get; set; }
    }
}
