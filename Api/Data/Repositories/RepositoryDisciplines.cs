using Microsoft.EntityFrameworkCore;
using Api.Data.Interfaces;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Repositories
{
    public class RepositoryDisciplines : IRepositoryDisciplines
    {
        protected readonly DataContext Context;
        protected readonly DbSet<Discipline> DataSet;

        public RepositoryDisciplines(DataContext context)
        {
            Context = context;
            DataSet = Context.Set<Discipline>();
        }

        public async Task<Discipline> Add(Discipline discipline)
        {
            DataSet.Add(discipline);

            await Context.SaveChangesAsync();

            return discipline;
        }

        public async Task<Discipline> Update(Discipline discipline)
        {
            DataSet.Update(discipline);

            await Context.SaveChangesAsync();

            return discipline;
        }

        public async Task Remove(Discipline discipline)
        {
            DataSet.Remove(discipline);

            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Discipline>> Get()
        {
            return await DataSet
                            .AsNoTracking()
                            .Include(t => t.Teacher)
                            .ToListAsync();
        }

        public async Task<Discipline> GetById(Guid id)
        {
            return await DataSet
                            .AsNoTracking()
                            .Include(t => t.Teacher)
                            .FirstOrDefaultAsync(c => c.Id.Equals(id));
        }
    }
}
