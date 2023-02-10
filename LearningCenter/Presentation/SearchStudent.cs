
using LearningCenter.Service.Services;

namespace LearningCenter.Presentation;

public class SearchStudent
{
    StudentService studentService = new StudentService();

    public async void Search()
    {
        Console.Clear();
        Console.Write("Enter Id -->  ");
        int id = int.Parse(Console.ReadLine());
        var response = await studentService.GetAsync(id);

        Console.WriteLine($"\nCode: {response.StatusCode}\nMessage: {response.Message}\n");

        var student = response.Student;
        Console.WriteLine($"Id: {student.Id}\nFirstName: {student.FirstName}\nLastName: {student.LastName}\n" +
            $"Date of Birth: {student.DateOfBirth}\nSubject Type: {student.Type}\nCreatedAt: {student.CreatedAt}");

    }
}
