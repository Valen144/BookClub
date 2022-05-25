namespace BookClub.BLL.DTO
{
    public class BookHistoryDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateTime ReadDate { get; set; }
    }
}
