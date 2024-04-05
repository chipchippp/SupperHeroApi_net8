using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SuperHeroApi_net8.Entity
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string ImageName { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
