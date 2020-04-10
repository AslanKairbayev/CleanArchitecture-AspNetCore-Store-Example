using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Categories();
    }
}
