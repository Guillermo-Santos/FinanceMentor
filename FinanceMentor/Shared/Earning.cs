using System.ComponentModel.DataAnnotations;

namespace FinanceMentor.Shared
{
    public sealed class Earning
    {
        public Earning()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(50)]
        public string Subject { get; set; }
        [Required]
        public EarningCategory Category { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
