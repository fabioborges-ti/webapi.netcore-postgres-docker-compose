using System;
using Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Interfaces
{
    public interface IRepositoryStudents : IRepositoryBase<Student>
    {
        Task<IEnumerable<Student>> GetByName(string name);
        Task<object> GetDisciplinesByStudentId(Guid id);
    }
}
