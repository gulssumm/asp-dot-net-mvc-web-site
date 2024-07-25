using System.ComponentModel.DataAnnotations;
namespace DotNetCore_First.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Department { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}

