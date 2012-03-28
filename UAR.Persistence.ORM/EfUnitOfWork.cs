﻿using System;
using System.Diagnostics;
using System.Linq;

using UAR.Persistence.Contracts;

namespace UAR.Persistence.ORM
{
    internal class EfUnitOfWork : IUnitOfWork
    {
        private IDbContext _wrappedContext; //entspricht der UnitOfWork vom EntityFramework
        internal int NumberOfDisposes = 0;

        public EfUnitOfWork(IDbContext dbContext)
        {
            //_contextFactory = contextFactory;
        }

        public TResult ExecuteQuery<TResult, T>(IQuery<TResult, T> query) where T : class
        {
            GetOrCreateContext<T>();
            return query.Execute(_wrappedContext.Set<T>());
        }

        public void Add<T>(T entity) where T : class
        {
            GetOrCreateContext<T>();
            _wrappedContext.Set<T>().Add(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            GetOrCreateContext<T>();
            _wrappedContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> Entities<T>() where T : class
        {
            GetOrCreateContext<T>();
            return _wrappedContext.Set<T>();
        }

        public string GetConnectionString()
        {
            return _wrappedContext == null ? "" : _wrappedContext.Context.Database.Connection.ConnectionString;
        }

        private void GetOrCreateContext<T>()
        {
            if (_wrappedContext == null)
            {
                _wrappedContext = new WrappedContext(new AdventureWorksContext());
                Debug.WriteLine("context created");
            }

            if (_wrappedContext == null)
                throw new NotImplementedException("can't find a proper context for the requested entity");
        }

        public void Commit()
        {
            if (_wrappedContext == null)
                throw new ApplicationException("can't commit changes because context was null");

            _wrappedContext.Context.SaveChanges();
            Debug.WriteLine("commit successful");
        }

        public void Dispose()
        {
            if (_wrappedContext == null)
                return;

            NumberOfDisposes += 1;
            _wrappedContext.Context.Dispose();
            _wrappedContext = null;
            Debug.WriteLine("context disposed");
        }
    }
}