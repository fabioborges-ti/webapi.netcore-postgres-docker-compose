using Microsoft.EntityFrameworkCore;
using Api.Data.Interfaces;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Repositories
{
    public class RepositoryTeachers : IRepositoryTeachers
    {
        protected readonly DataContext Context;
        protected readonly DbSet<Teacher> DataSet;

        public RepositoryTeachers(DataContext context)
        {
            Context = context;
            DataSet = Context.Set<Teacher>();
        }

        public async Task<Teacher> Add(Teacher teacher)
        {
            DataSet.Add(teacher);

            await Context.SaveChangesAsync();

            return teacher;
        }

        public async Task<Teacher> Update(Teacher teacher)
        {
            DataSet.Update(teacher);

            await Context.SaveChangesAsync();

            return teacher;
        }

        public async Task Remove(Teacher teacher)
        {
            DataSet.Remove(teacher);

            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Teacher>> Get()
        {
            return await DataSet.ToListAsync();
        }

        public async Task<Teacher> GetById(Guid id)
        {
            return await DataSet.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task<object> GetStudentsByTeacherId(Guid id)
        {
            var db = await DataSet
                .AsNoTracking()
                .Include(sd => sd.Disciplines)
                .ThenInclude(d => d.StudentsDisciplines)
                .ThenInclude(t => t.Student)
                .Where(c => c.Id.Equals(id))
                .ToListAsync();

            var data = db.FirstOrDefault();

            if (data == null) return null;

            var teacher = new
            {
                data.Id,
                data.CreatedAt,
                data.Name,
                Students = new List<object>()
            };

            if (!data.Disciplines.Any()) return teacher;

            foreach (var discipline in data.Disciplines)
            {
                if (!discipline.StudentsDisciplines.Any()) return teacher;

                foreach (var studentsDisciplines in discipline.StudentsDisciplines)
                {
                    var student = new
                    {
                        studentsDisciplines.Student.Name,
                        studentsDisciplines.Student.Lastname,
                        studentsDisciplines.Student.Phone
                    };

                    teacher.Students.Add(student);
                }
            }

            return teacher;
        }

        public async Task<object> GetDisciplinesByTeacherId(Guid id)
        {
            var db = await DataSet
                .AsNoTracking()
                .Include(sd => sd.Disciplines)
                .Where(c => c.Id.Equals(id))
                .ToListAsync();

            var data = db.FirstOrDefault();

            if (data == null) return null;

            var teacher = new
            {
                data.Id,
                data.CreatedAt,
                data.Name,
                Disciplines = new List<string>()
            };

            if (!data.Disciplines.Any()) return teacher;

            foreach (var discipline in data.Disciplines)
            {
                teacher.Disciplines.Add(discipline.Name);
            }

            return teacher;
        }
    }
}
