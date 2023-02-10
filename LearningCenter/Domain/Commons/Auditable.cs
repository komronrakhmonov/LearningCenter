
using LearningCenter.Domain.Enums;

namespace LearningCenter.Domain.Commons;

public class Auditable
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public SubjectType Type { get; set; }
}
