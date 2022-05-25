using System.ComponentModel.DataAnnotations;

namespace BookClub.DAL.Entities
{
    public class BookHistory
    { 
        public int Id { get; set; }
        public DateTime ReadDate { get; set; }  
        [Required]
        public User User { get; set; }
        [Required]
        public Book Book { get; set; }  
    }
}
