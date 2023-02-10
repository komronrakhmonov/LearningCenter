

using LearningCenter.Domain.Entities;
using LearningCenter.Service.DTOs;
using LearningCenter.Service.Helpers;

namespace LearningCenter.Service.Interfaces;

public interface IStudentService
{
    Task<Response> CreateAsync(StudentCreationDto student);
    Task<Response> UpdateAsync(int id, StudentCreationDto student);
    Task<Response> DeleteAsync(int id);
    Task<Response> GetAsync(int id);
    Task<ListResponse> GetAllAsync (Func<Student,bool> predicate);
}
