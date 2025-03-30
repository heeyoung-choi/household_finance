using FinanceManagement.Data;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FinanceManagement.Models
{
    [PrimaryKey(nameof(UserId), nameof(HouseholdID))]
    public class HouseholdMember
    {
      
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Required]
        public int HouseholdID { get; set; }
        [ForeignKey("HouseholdID")]
        public Household Household { get; set; }

        public bool IsEditor { get; set; } = false;



    }
}
