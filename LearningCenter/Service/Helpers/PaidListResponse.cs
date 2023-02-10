
using LearningCenter.Domain.Entities;

namespace LearningCenter.Service.Helpers;

public class PaidListResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public List<PaidStudent> PaidStudents { get; set; }
}
