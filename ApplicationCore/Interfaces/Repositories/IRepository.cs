using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> FindAll { get; }
        T FindById(int entityId);
        void Create(T entity);
        void Delete(int entityId);
    }
}
