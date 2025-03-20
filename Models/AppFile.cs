using System.ComponentModel.DataAnnotations;
namespace FinanceManagement.Models
{
    public class AppFile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public byte[] Content { get; set; }
    }
}