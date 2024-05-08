using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display order")]
        [Range(0, 200,ErrorMessage = "Display Order should 1 to 200 only!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public virtual ICollection<book> books { get; set; }
        public Category() { 
            books = new List<book>();
        }
    }
}
