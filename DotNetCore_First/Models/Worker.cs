using System.ComponentModel.DataAnnotations;
namespace DotNetCore_First.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Unit { get; set; }
    }
}

