
using LearningCenter.Domain.Enums;
using LearningCenter.Service.DTOs;
using LearningCenter.Service.Services;

namespace LearningCenter.Presentation;

public class CreateStudent
{
    StudentService studentService = new StudentService();
    public async void Create()
    {
        var student = new StudentCreationDto();
        Console.Clear();
        Console.Write("FirstName: ");
        student.FirstName = Console.ReadLine();
        Console.Write("LastName: ");
        student.LastName = Console.ReadLine();
        Console.Write("Date of Birth (dd.MM.YYYY): ");
        student.DateOfBirth = DateTime.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("1.Math");
        Console.WriteLine("2.English");
        Console.WriteLine("3.Biology");
        Console.WriteLine("4.Chemistry");
        Console.WriteLine("5.History");
        Console.WriteLine("6.Russian");

        Console.Write("\n Which subject? -->  ");
        byte subjectKey=byte.Parse(Console.ReadLine());
        switch (subjectKey)
        {
            case 1:
                student.Type = SubjectType.Math;
                break;
            case 2:
                student.Type = SubjectType.English;
                break;
            case 3:
                student.Type = SubjectType.Biology;
                break;
            case 4:
                student.Type = SubjectType.CHemistry;
                break;
            case 5:
                student.Type = SubjectType.History;
                break;
            case 6:
                student.Type = SubjectType.Russian;
                break;
            default:
                Console.WriteLine("EROR");
                break;
        }
        var response = await studentService.CreateAsync(student);
        

        Console.WriteLine($"\nCode: {response.StatusCode}\nMessage: {response.Message}");
    }
}
