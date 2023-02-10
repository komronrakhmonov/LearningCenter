
using LearningCenter.Domain.Entities;

namespace LearningCenter.Service.Helpers;

public class Response
{
    public int StatusCode { get; set; }
    public string Message { get; set; }


    public Student Student { get; set; }
}
