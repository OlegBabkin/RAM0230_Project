using Project.Domain.Repository;
using System;
using System.Linq;
using Project.Domain.Core;
using System.Linq.Expressions;
using Project.Infrastructure.Database.Connection;
using System.Collections.Generic;

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
            this.context.ModeOfStudies.Remove(entity);
        }

        public IEnumerable<ModeOfStudy> FindBy(Expression<Func<ModeOfStudy, bool>> predicate)
        {
            return this.context.ModeOfStudies.Where(predicate).ToList();
        }

        public IEnumerable<ModeOfStudy> GetAllEntries()
        {
            return this.context.ModeOfStudies;
        }

        public IEnumerable<Student> GetModeOfStudyStudents(ModeOfStudy modeOfStudy)
        {
            return this.GetByKey(modeOfStudy.Id).Students;
        }

        public IEnumerable<Subject> GetModeOfStudySubjects(ModeOfStudy modeOfStudy)
        {
            return this.GetByKey(modeOfStudy.Id).Subjects;
        }

        public ModeOfStudy GetByKey(int key)
        {
            return this.context.ModeOfStudies.FirstOrDefault(o => o.Id == key);
        }

        public void Insert(ModeOfStudy entity)
        {
            this.context.ModeOfStudies.Add(entity);
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
