using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FinanceManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public int HouseholdID { get; set; }
        [ForeignKey("HouseholdID")]
        public Household Household { get; set; }


    }
}
