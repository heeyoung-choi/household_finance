using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FinanceManagement.Models
{
    public class Household
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public int? ProfilePictureKey { get; set; } = null;
        [ForeignKey("ProfilePictureKey")]
        public AppFile? ProfilePicture { get; set; } = null;
        [Required]
        public string OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        public ApplicationUser Owner { get; set; }

        public List<HouseholdMember> Members { get; set; }
        public List<Category> Categories { get; set; }
        
    }
}
