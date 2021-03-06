﻿using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Quadrivia
{
    public class QuestionAuthorizer : ITypeAuthorizer<QuestionMetaData>
    {
        public bool IsEditable(IPrincipal principal, QuestionMetaData target, string memberName)
        {
            throw new NotImplementedException();
            //No fields are editable once status is Final -  can only be superseded
            //In draft, only editable by owning teacher
        }

        public bool IsVisible(IPrincipal principal, QuestionMetaData target, string memberName)
        {
            throw new NotImplementedException();
            //Visible directly only to Teachers
        }
    }
}
