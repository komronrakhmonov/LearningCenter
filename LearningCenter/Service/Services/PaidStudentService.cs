
using LearningCenter.Data.IRepositories;
using LearningCenter.Data.Repositories;
using LearningCenter.Domain.Entities;
using LearningCenter.Service.DTOs;
using LearningCenter.Service.Helpers;
using LearningCenter.Service.Interfaces;

namespace LearningCenter.Service.Services;

public class PaidStudentService : IPaidStudentService
{
    private readonly IGenericRepository<Student> studentRepository = new GenericRepository<Student>();
    private readonly IGenericRepository<PaidStudent> paidStudentRepository = new GenericRepository<PaidStudent>();

    public async Task<PaidResponse> AddPaymentAsync(int id,PaymentDto payment)
    {
        var student = await studentRepository.SelectAsync(id);
        if (student is null)
            return new PaidResponse()
            {
                StatusCode = 404,
                Message = "Student Not Found",
                PaidStudent = null
            };
        var newPayment = new PaidStudent()
        {
            Id = id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            DateOfBirth = student.DateOfBirth,
            Type= student.Type,
            Amount = payment.Amount,
            PaidFor = payment.PaidFor,
            PayType = payment.PayType,
            PaidAt = DateTime.Now,
        };
        var paidStudent = await paidStudentRepository.InsertAsync(newPayment);
        return new PaidResponse()
        {
            StatusCode = 200,
            Message = "Successfully paid!",
            PaidStudent = paidStudent
        };
    }

    public async Task<PaidListResponse> GetAllPaidStudentAsync()
    {
        var model = await paidStudentRepository.SelectAllAsync(p => p.Id > 0);
        return new PaidListResponse()
        {
            StatusCode = 200,
            Message = "Success",
            PaidStudents = model
        };
    }
}
