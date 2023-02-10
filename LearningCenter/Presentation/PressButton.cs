
namespace LearningCenter.Presentation;

public class PressButton
{
    public void Start()
    {
        Start:
        Console.WriteLine("1.Create new student");
        Console.WriteLine("2.Delete student");
        Console.WriteLine("3.Search student");
        Console.WriteLine("4.Search student by learning subject");
        Console.WriteLine("5.Payment");
        Console.WriteLine("6.Get Paid Students");


        Console.Write("\nChoose your purpose --> ");
        byte pressKey = byte.Parse(Console.ReadLine());
        switch(pressKey)
        {
            case 1:
                var createStudent = new CreateStudent();
                createStudent.Create();
                Menu();
                goto Start;
            case 2:
                var deleteStudent = new DeleteStudent();
                deleteStudent.Delete();
                Menu();
                goto Start;
            case 3:
                var searchStudent = new SearchStudent();
                searchStudent.Search();
                Menu();
                goto Start;
            case 4:
                var getStudents = new GetAllBySubject();
                getStudents.GetAll();
                Menu();
                goto Start;
            case 5:
                var payment = new Payment();
                payment.Pay();
                Menu();
                goto Start;
            case 6:
                var getPaidStudsnts = new GetPaidStudents();
                getPaidStudsnts.GetAll();
                Menu();
                goto Start;
            default:              
                Menu();
                goto Start;

        }
    }

    public static void Menu()
    {
        Console.WriteLine("\nPress any key to return to Main Menu!");
        Console.ReadKey();
        Console.Clear();
    }
}
