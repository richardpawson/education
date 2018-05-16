using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Quadrivia
{
    public class TeacherAuthorizer : ITypeAuthorizer<Teacher>
    {
        public bool IsEditable(IPrincipal principal, Teacher target, string memberName)
        {
            throw new NotImplementedException();
        }

        public bool IsVisible(IPrincipal principal, Teacher target, string memberName)
        {
            throw new NotImplementedException();
        }
    }
}
