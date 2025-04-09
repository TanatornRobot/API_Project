namespace API_Project.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }
    }
}
