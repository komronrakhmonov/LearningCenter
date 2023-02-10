
using LearningCenter.Data.Configurations;
using LearningCenter.Data.IRepositories;
using LearningCenter.Domain.Commons;
using LearningCenter.Domain.Entities;
using Newtonsoft.Json;

namespace LearningCenter.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
{
    private readonly string path;

    public GenericRepository()
    {
        if (typeof(T) == typeof(Student))
            path = DataBasePath.STUDENT_BASE;
        else if (typeof(T) == typeof(PaidStudent))
            path = DataBasePath.PAID_STUDENT_BASE;
    }


    public async Task<T> InsertAsync(T student)
    {
        var students = await SelectAllAsync(p => p.Id > 0);
        students.Add(student);

        var json = JsonConvert.SerializeObject(students, Formatting.Indented);
        await File.WriteAllTextAsync(path, json);

        return student;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var students = await SelectAllAsync(p => p.Id > 0);
        var student = students.FirstOrDefault(p => p.Id == id);

        if (student is null)
            return false;

        students.Remove(student);

        var json = JsonConvert.SerializeObject(students, Formatting.Indented);
        await File.WriteAllTextAsync(path, json);
        return true;

    }
    public async Task<T> SelectAsync(int id)
    {
        var students = await SelectAllAsync(p => p.Id > 0);
        var student = students.FirstOrDefault(p => p.Id == id);
        if (student is null)
            return null;
        return student;
    }
    public async Task<List<T>> SelectAllAsync(Func<T,bool> predicate)
    {

        var models = await File.ReadAllTextAsync(path);
        if (string.IsNullOrEmpty(models))
            models = "[]";
        var json = JsonConvert.DeserializeObject<List<T>>(models);
        return json;
    }
    public async Task<T> UpdateAsync(int id, T student)
    {
        var students = await SelectAllAsync(p => p.Id > 0);
        var model = students.FirstOrDefault(p => p.Id == id);
        var index = students.IndexOf(model);

        students.Insert(index,student);
        var json = JsonConvert.SerializeObject(students, Formatting.Indented);
        await File.WriteAllTextAsync(path, json);

        return student;

    }
}
