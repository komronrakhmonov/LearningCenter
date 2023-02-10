
using LearningCenter.Domain.Commons;
using LearningCenter.Domain.Enums;

namespace LearningCenter.Domain.Entities;

public class PaidStudent : Auditable
{
    public DateTime PaidFor { get; set; }
    public decimal Amount { get; set; }
    public DateTime? PaidAt { get; set; }
    public PaymentType PayType { get; set; }
}
