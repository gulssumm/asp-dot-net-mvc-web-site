using System.ComponentModel.DataAnnotations;
namespace DotNetCore_First.Models
{
    public class Rector
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
