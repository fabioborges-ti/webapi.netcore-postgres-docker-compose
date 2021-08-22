using Api.Models;
using System;
using System.Threading.Tasks;

namespace Api.Data.Interfaces
{
    public interface IRepositoryTeachers : IRepositoryBase<Teacher>
    {
        Task<object> GetStudentsByTeacherId(Guid id);
        Task<object> GetDisciplinesByTeacherId(Guid id);
    }
}
