using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager.Models
{
    public class ChurchMember: UserActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
        public Boolean IsAdmin { get; set; }

        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
