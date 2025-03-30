using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FinanceManagement.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        
        public int? HouseholdId { get; set; }
        [ForeignKey("HouseholdId")]
        public Household Household { get; set; }
        
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public long Amount { get; set; }
        //income or expense
        [Required]
        public string Type { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public ApplicationUser Creator { get; set; }
    }
}
