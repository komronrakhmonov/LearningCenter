
using LearningCenter.Service.Services;

namespace LearningCenter.Presentation;

public class DeleteStudent
{
    StudentService studentService = new StudentService();

    public async void Delete()
    {
        Console.Clear();
        Console.Write("Enter Id -->  ");
        int id = int.Parse(Console.ReadLine());
        var response = await studentService.DeleteAsync(id);

        Console.WriteLine($"\nCode: {response.StatusCode}\nMessage: {response.Message}");

    }
}
