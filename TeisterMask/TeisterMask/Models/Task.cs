using System.ComponentModel.DataAnnotations;

namespace TeisterMask.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Status { get; set; }
    }
}
