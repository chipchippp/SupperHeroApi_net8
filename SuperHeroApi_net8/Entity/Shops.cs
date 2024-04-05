namespace SuperHeroApi_net8.Entity
{
    public class Shops
    {
        public string Phone_Number { get; set; }
        public string Description { get; set; }
        public int Category_Id { get; set; }
        public Category Category { get; set; }
    }
}
