using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quadrivia
{
    public class SubjectRepository
    {
        #region Injected Services

        public IDomainObjectContainer Container { set; protected get; }

        #endregion

        public IQueryable<Subject> AllSubjects()
        {
            return Container.Instances<Subject>();
        }

    }
}
