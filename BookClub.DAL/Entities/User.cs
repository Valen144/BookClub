namespace BookClub.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Login { get; set; } = null!;
    }
}
