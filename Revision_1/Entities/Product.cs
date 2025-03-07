using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Revision_1.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }  

        [Required]
        public string name { get; set; } = string.Empty;  

        public string description { get; set; } = string.Empty;

        [Required]
        public decimal price { get; set; }

        public Product() { }

        public Product(string _name, decimal _price, string _description)
        {
            name = _name;
            price = _price;
            description = _description;
        }
    }
}