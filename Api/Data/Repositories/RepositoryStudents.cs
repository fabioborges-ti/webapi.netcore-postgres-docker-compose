using Microsoft.EntityFrameworkCore;
using Api.Data.Interfaces;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Repositories
{
    public class RepositoryStudents : IRepositoryStudents
    {
        protected readonly DataContext Context;
        protected readonly DbSet<Student> DataSet;

        public RepositoryStudents(DataContext context)
        {
            Context = context;
            DataSet = Context.Set<Student>();
        }

        public async Task<Student> Add(Student student)
        {
            DataSet.Add(student);

            await Context.SaveChangesAsync();

            return student;
        }

        public async Task<Student> Update(Student student)
        {
            DataSet.Update(student);

            await Context.SaveChangesAsync();

            return student;
        }

        public async Task Remove(Student student)
        {
            DataSet.Remove(student);

            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> Get()
        {
            return await DataSet.AsNoTracking().ToListAsync();
        }

        public async Task<Student> GetById(Guid id)
        {
            return await DataSet.AsNoTracking().FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task<IEnumerable<Student>> GetByName(string name)
        {
            return await DataSet.AsNoTracking().Where(c => c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task<object> GetDisciplinesByStudentId(Guid id)
        {
            var db = await DataSet
                .AsNoTracking()
                .Include(sd => sd.StudentsDisciplines)
                .ThenInclude(d => d.Discipline)
                .ThenInclude(t => t.Teacher)
                .Where(c => c.Id.Equals(id))
                .ToListAsync();

            var data = db.FirstOrDefault();

            if (data == null) return null;

            var student = new
            {
                data.Id,
                data.CreatedAt,
                data.Name,
                data.Lastname,
                data.Phone,
                Disciplines = new List<object>()
            };

            if (!data.StudentsDisciplines.Any()) return student;

            foreach (var item in data.StudentsDisciplines)
            {
                var discipline = new
                {
                    Discipline = item.Discipline.Name,
                    Teacher = item.Discipline.Teacher.Name
                };

                student.Disciplines.Add(discipline);
            }

            return student;
        }
    }
}
