using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace XuongMayBE.Attribute
{
    public class AnthorizationAttribute : TypeFilterAttribute
    {
        public AnthorizationAttribute(string roleName)
            : base(typeof(AnthorizationFilter))
        {
            Arguments = new object[] { roleName };
        }
    }

    public class AnthorizationFilter : IAuthorizationFilter
    {
        private readonly string _roleName;

        public AnthorizationFilter(string roleName)
        {
            _roleName = roleName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            // Kiểm tra xem người dùng đã xác thực chưa
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // Kiểm tra quyền của người dùng
            var userRoles = user.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);

            if (!_roleName.Split(',').Any(role => userRoles.Contains(role)))
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
