using Core.Abstract;
using Core.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public IResult Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IResult Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
