using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quadrivia
{
    public class QuestionRepository
    {
        #region Injected Services

        public IDomainObjectContainer Container { set; protected get; }

        #endregion

        public QuestionMetaData CreateNewQuestion(bool copyMetaDataFromLastQuestionICreated)
        {
            throw new NotImplementedException();
            //QuestionMetaData obj = Container.NewTransientInstance<QuestionMetaData>();
            //set up any parameters
            //Container.Persist(ref obj);
            //return obj;
        }

    }
}
