using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BulkyBookWeb.Models
{
    public class book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }

        [ForeignKey("Category")]
        [AllowNull]
        public int cid { get; set; }

        public virtual Category Category { get; set; }

    }
}
