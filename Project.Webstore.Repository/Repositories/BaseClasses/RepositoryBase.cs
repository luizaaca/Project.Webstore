using Project.Webstore.Infrastructure.Domain.BaseClasses;
using Project.Webstore.Infrastructure.Domain.Interfaces;
using Project.Webstore.Infrastructure.Querying;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Webstore.Repository.Repositories
{
    public abstract class RepositoryBase<T, TEntityKey> where T : EntityBase<TEntityKey>, IAggregateRoot
    {
        public void Add(T entity)
        {
            SessionFactory.CurrentSession.Save(entity);
        }

        public void Remove(T entity)
        {
            SessionFactory.CurrentSession.Delete(entity);
        }

        public void Save(T entity)
        {
            SessionFactory.CurrentSession.Update(entity);
        }

        public T FindBy(TEntityKey id)
        {
            var query = SessionFactory.CurrentSession.Query<T>();

            return query.Where(e => e.Id.Equals(id)).Single();
        }

        public IEnumerable<T> FindAll()
        {
            var query = SessionFactory.CurrentSession.Query<T>();

            return query.ToList();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            var query = SessionFactory.CurrentSession.Query<T>();

            return query
                .Skip(index)
                .Take(count)
                .ToList();
        }

        public IEnumerable<T> FindBy(Query<T> query)
        {
            var sessionQuery = SessionFactory.CurrentSession.Query<T>();

            query.TranslateIntoNHQuery(sessionQuery);

            return sessionQuery.ToList();
        }

        public IEnumerable<T> FindBy(Query<T> query, int index, int count)
        {
            var sessionQuery = SessionFactory.CurrentSession.Query<T>();

            query.TranslateIntoNHQuery(sessionQuery);

            return sessionQuery.Skip(index).Take(count).ToList();
        }

        public void Commit()
        {
            using (var transaction = SessionFactory.CurrentSession.BeginTransaction())
            {
                try
                {
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
