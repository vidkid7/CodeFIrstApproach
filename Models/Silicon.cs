using System.ComponentModel.DataAnnotations;

namespace CodeFirstApproach.Models
{
    public class Silicon
    {
        [Key]
        public int SiliconId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }

    }
}
