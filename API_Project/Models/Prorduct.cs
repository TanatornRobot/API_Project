namespace API_Project.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public required string First_name { get; set; }

        [Column("last_name")]
        public required string Last_name { get; set; }

        [Column("phone")]
        public required string phone { get; set; }
    }
}
