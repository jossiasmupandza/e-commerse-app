using System;
using System.Collections;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using Persistence;

namespace Infrastracture.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private Hashtable _repositories;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if(_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var reposistoryInstance =
                    Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                
                _repositories.Add(type, reposistoryInstance);
            }

            return (IGenericRepository<TEntity>) _repositories[type];
        }

    }
}