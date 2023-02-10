
using LearningCenter.Domain.Enums;
using LearningCenter.Service.DTOs;
using LearningCenter.Service.Services;

namespace LearningCenter.Presentation;

public class Payment
{
    PaidStudentService paidStudentService = new PaidStudentService();

    public async void Pay()
    {
        Console.Clear();
        var paidStudent = new PaymentDto();
        Console.Write("Enter ID: ");
        paidStudent.Id = int.Parse(Console.ReadLine());
        Console.Write("Amount: ");
        paidStudent.Amount = decimal.Parse(Console.ReadLine());
        Console.Write("Paid For (MM.YYYY): ");
        paidStudent.PaidFor=DateTime.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("1.Cash");
        Console.WriteLine("2.UzCard");
        Console.WriteLine("3.Humo");
        Console.Write("\nPaymentType:-->  ");
        byte paymentType = byte.Parse(Console.ReadLine());
        switch (paymentType)
        {
            case 1:
                paidStudent.PayType = PaymentType.Cash;
                break;
            case 2:
                paidStudent.PayType = PaymentType.UzCard;
                break;
            case 3:
                paidStudent.PayType = PaymentType.Humo;
                break;
        }

        var response = await paidStudentService.AddPaymentAsync(paidStudent.Id, paidStudent);
        Console.WriteLine($"\nCode: {response.StatusCode}\nMessage: {response.Message}");


    }

}
