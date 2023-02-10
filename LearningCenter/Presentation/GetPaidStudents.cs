
using LearningCenter.Service.Services;

namespace LearningCenter.Presentation;

public class GetPaidStudents
{
    PaidStudentService paidStudentService = new PaidStudentService();

    public async void GetAll()
    {
        Console.Clear();
        var response = await paidStudentService.GetAllPaidStudentAsync();

        var lists = response.PaidStudents.ToList();
        foreach (var list in lists)
        {
            Console.WriteLine($"{list.Id} ||{list.FirstName}\t||{list.LastName}\t||{list.DateOfBirth.Date}\t||" +
                $"{list.Type}\t||{list.PaidFor.ToString("MMMM")}\t||{list.Amount}\t||{list.PaidAt}\t||{list.PayType}");
        }
    }
}
