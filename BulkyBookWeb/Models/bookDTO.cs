using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BulkyBookWeb.Models
{
    public class bookDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public int cid { get; set; }
    }
}
