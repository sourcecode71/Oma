using Microsoft.AspNetCore.Mvc.Filters;

namespace Oma.Server.Helper
{
    public interface IActionTransactionHelper
    {
        void BeginTransaction();
        void EndTransaction(ActionExecutedContext filterContext);
        void CloseSession();
    }
}
