
using LearningCenter.Data.IRepositories;
using LearningCenter.Data.Repositories;
using LearningCenter.Domain.Entities;
using LearningCenter.Service.DTOs;
using LearningCenter.Service.Helpers;
using LearningCenter.Service.Interfaces;

namespace LearningCenter.Service.Services;

public class StudentService : IStudentService
{
    private readonly IGenericRepository<Student> studentRepository = new GenericRepository<Student>();
    private int lastId;
    public async Task<Response> CreateAsync(StudentCreationDto student)
    {
        var models = await studentRepository.SelectAllAsync(p => p.Id > 0);
        if (models.Count==0)
            lastId = 0;
        else
            lastId = lastId = models[models.Count - 1].Id;
        var newStudent = new Student()
        {
            Id = ++lastId,
            FirstName = student.FirstName,
            LastName = student.LastName,
            DateOfBirth = student.DateOfBirth,
            Type = student.Type,
            CreatedAt = DateTime.UtcNow
        };
        var res = await studentRepository.InsertAsync(newStudent);
        return new Response()
        {
            StatusCode = 200,
            Message = "Created!!!",
            Student = res
        };
    }

    public async Task<Response> DeleteAsync(int id)
    {
        var student = await studentRepository.SelectAsync(id);
        if (student is null)
            return new Response()
            {
                StatusCode = 404,
                Message = "Student not found!!!",
                Student = null
            };
        await studentRepository.DeleteAsync(id);
        return new Response()
        {
            StatusCode = 200,
            Message = "Student successfully deleted!!!",
            Student = student
        };

    }

    public async Task<ListResponse> GetAllAsync(Func<Student,bool> predicate)
    {
        var students = await studentRepository.SelectAllAsync(predicate);
        return new ListResponse()
        {
            StatusCode = 200,
            Message = "Successfully!!!",
            Students = students
        };
    }

    public async Task<Response> GetAsync(int id)
    {
        var student = await studentRepository.SelectAsync(id);
        if (student is null)
            return new Response()
            {
                StatusCode = 404,
                Message = "Student not found!!!",
                Student = null
            };
        return new Response()
        {
            StatusCode = 200,
            Message = "Student successfully found!!!",
            Student = student
        };
    }

    public async Task<Response> UpdateAsync(int id, StudentCreationDto student)
    {
        var model = await studentRepository.SelectAsync(id);
        if (model is null)
            return new Response()
            {
                StatusCode = 404,
                Message = "Student Not Found!!!",
                Student = null
            };
        var newStudent = new Student()
        {
            Id = id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            DateOfBirth = student.DateOfBirth,
            Type = student.Type,
            CreatedAt = DateTime.UtcNow
        };
        var updateStudent = await studentRepository.UpdateAsync(id, newStudent);
        return new Response()
        {
            StatusCode = 200,
            Message = "Updated",
            Student = updateStudent
        };
    }
}
