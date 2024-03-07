using System.ComponentModel.DataAnnotations;

namespace SuperHeroApi_net8.Entities
{
    public class SuperHero
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;

    }
}
