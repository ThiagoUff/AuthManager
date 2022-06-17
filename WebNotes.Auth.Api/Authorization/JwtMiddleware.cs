using Microsoft.AspNetCore.Identity;
using WebNotes.Auth.Domain.Interfaces.Helper;

namespace WebNotes.Auth.Api.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userName = jwtUtils.ValidateJwtToken(token!);
            await _next(context);
        }
    }
}
