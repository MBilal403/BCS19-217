using System.ComponentModel.DataAnnotations;

namespace BookShop.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string URl { get; set; }

    }
}
