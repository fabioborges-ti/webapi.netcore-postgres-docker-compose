using Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Interfaces
{
    public interface IRepositoryBase<T> where T : Base
    {
        Task<T> Add(T obj);
        Task<T> Update(T obj);
        Task Remove(T obj);
        Task<IEnumerable<T>> Get();
        Task<T> GetById(Guid id);
    }
}
