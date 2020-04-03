using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll { get; }
        T GetById(int entityId);
        void Create(T entity);
        void Delete(int entityId);
    }
}
