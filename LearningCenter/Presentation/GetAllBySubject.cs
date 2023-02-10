

using LearningCenter.Domain.Enums;
using LearningCenter.Service.Services;

namespace LearningCenter.Presentation;

public class GetAllBySubject
{
    StudentService studentService = new StudentService();

    public async void GetAll()
    {
        Console.Clear();
        Console.WriteLine("1.Math");
        Console.WriteLine("2.English");
        Console.WriteLine("3.Biology");
        Console.WriteLine("4.Chemistry");
        Console.WriteLine("5.History");
        Console.WriteLine("6.Russian");

        Console.Write("\n Which students do you want see? -->");
        byte pressKey = byte.Parse(Console.ReadLine());
        var response = await studentService.GetAllAsync(p => p.Type == (SubjectType.CHemistry));

        var lists = response.Students.ToList();
        foreach ( var list in lists )
        {
            Console.WriteLine($"{list.Id} ||{list.FirstName}\t||{list.LastName}\t||{list.DateOfBirth.Date}\t||" +
                $"{list.Type}\t||{list.CreatedAt}");
        }
        
    }
}
