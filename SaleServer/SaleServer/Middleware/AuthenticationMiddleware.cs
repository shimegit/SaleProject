using Microsoft.IdentityModel.Tokens;
using SaleServer.BL;
using SaleServer.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace SaleServer.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthenticationMiddleware> _logger;

        public AuthenticationMiddleware(RequestDelegate next, ILogger<AuthenticationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var identity = context.User.Identity as ClaimsIdentity;
                if (identity == null)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized");
                    return;
                }

                var userClaims = identity.Claims;
                User user = new User();
                user.UserId = int.Parse(userClaims.FirstOrDefault(o => o.Type == "userId")?.Value);
                context.Items["User"] = user;
                await _next(context);

            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in the middleware.");

            }
        }

    }
}
