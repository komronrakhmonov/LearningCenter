using LearningCenter.Service.DTOs;
using LearningCenter.Service.Helpers;

namespace LearningCenter.Service.Interfaces;

public interface IPaidStudentService
{
    Task<PaidResponse> AddPaymentAsync(int id,PaymentDto payment);
    Task<PaidListResponse> GetAllPaidStudentAsync();

}
