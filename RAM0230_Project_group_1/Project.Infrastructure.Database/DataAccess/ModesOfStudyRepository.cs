using Project.Domain.Repository;
using System;
using System.Linq;
using Project.Domain.Core;
using System.Linq.Expressions;
using Project.Infrastructure.Database.Connection;

namespace Project.Infrastructure.Database.DataAccess
{
    public class ModesOfStudyRepository : IModeOfStudy
    {
        private KolledzDBContext context;

        public ModesOfStudyRepository(KolledzDBContext context)
        {
            this.context = context;
        }

        public void Delete(ModeOfStudy entity)
        {
            this.context.ModesOfStudy.Remove(entity);
        }

        public IQueryable<ModeOfStudy> FindBy(Expression<Func<ModeOfStudy, bool>> predicate)
        {
            return this.GetAllEntries().Where(predicate);
        }

        public IQueryable<ModeOfStudy> GetAllEntries()
        {
            return this.context.ModesOfStudy.AsQueryable<ModeOfStudy>();
        }

        public ModeOfStudy GetByKey(int key)
        {
            return this.context.ModesOfStudy.FirstOrDefault(o => o.Id == key);
        }

        public void Insert(ModeOfStudy entity)
        {
            this.context.ModesOfStudy.Add(entity);
        }

        public void Update(ModeOfStudy entity)
        {
            var oldEntry = this.GetByKey(entity.Id);
            if (oldEntry != null)
            {
                this.context.Entry(oldEntry).CurrentValues.SetValues(entity);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
