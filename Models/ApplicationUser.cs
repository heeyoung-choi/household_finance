using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? ProfilePictureKey { get; set; } = null;
        [ForeignKey("ProfilePictureKey")]
        public AppFile? ProfilePicture { get; set; } = null;
        public List<Household> HouseholdsOwned { get; set; }
        public List<HouseholdMember> HouseholdsBelong { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
