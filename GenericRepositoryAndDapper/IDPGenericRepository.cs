using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryAndDapper
{
    public interface IDPGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetData(object filter);
        Task<IEnumerable<TEntity>> GetDataAsync(object filter);
    }
}
