namespace SuperHeroApi_net8.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public ICollection<Shops>? Shops { get; set; }

    }
}
