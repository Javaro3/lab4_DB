using lab4.Data;
using Microsoft.EntityFrameworkCore;

namespace lab4 {
    public class DbInitializerMiddleware {
        private readonly RequestDelegate _next;

        public DbInitializerMiddleware(RequestDelegate next) {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, InsuranceCompanyContext db) {
            if (!(httpContext.Session.Keys.Contains("starting"))) {
                DbInitializer.Initialize(db);
                httpContext.Session.SetString("starting", "Yes");
            }
            return _next.Invoke(httpContext);
        }
    }

    public static class DbInitializerMiddlewareExtensions {
        public static IApplicationBuilder UseDbInitializerMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<DbInitializerMiddleware>();
        }
    }
}
