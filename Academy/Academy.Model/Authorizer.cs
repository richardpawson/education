using NakedObjects;
using NakedObjects.Security;
using System.Security.Principal;

namespace Academy.Model
{
    public class Authorizer : ITypeAuthorizer<object>
    {

        public bool IsEditable(IPrincipal principal, object target, string memberName) {
            return IsInSysAdminMode;
        }


        public bool IsVisible(IPrincipal principal, object target, string memberName) {

            return true;
        }

        public const bool IsInSysAdminMode = false;

        public static string DisableIfNotSysAdmin()
        {
            var rb = new ReasonBuilder();
            rb.AppendOnCondition(!IsInSysAdminMode, "You are not authorized to use this action.");
            return rb.Reason;
        }
    }

}
