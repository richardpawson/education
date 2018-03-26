using NakedObjects.Security;
using System.Security.Principal;

namespace Academy.Model
{
    public class Authorizer : ITypeAuthorizer<object>
    {

        public bool IsEditable(IPrincipal principal, object target, string memberName) {
            return false;
        }


        public bool IsVisible(IPrincipal principal, object target, string memberName) {

            return !memberName.Contains("New");
        }
    }

}
