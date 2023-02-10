
using LearningCenter.Domain.Enums;

namespace LearningCenter.Service.DTOs;

public class PaymentDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PayType { get; set; }
    public DateTime PaidFor { get; set; }
}
