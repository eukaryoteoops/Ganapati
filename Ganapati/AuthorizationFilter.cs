using Dapper;
using Ganapati.Models.Entity;
using System;
using System.Data.SQLite;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Ganapati
{
    public static class Const
    {
        public static string connString = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}Ganapati.db";
    }
    public class CustomAuthorization : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value?.FirstOrDefault();
            if (token == null)
            {
                return false;
            }
            using (var conn = new SQLiteConnection(Const.connString))
            {
                var player = conn.QueryFirstOrDefault<Player>("Select * From Player Where Token = @token And ExpiredOn > datetime(\"now\")", new { token = token });
                if (player == null)
                {
                    return false;
                }
                var claimsIdentity = new ClaimsIdentity();
                claimsIdentity.AddClaim(new Claim("PlayerId", player.Id.ToString()));
                actionContext.RequestContext.Principal = new ClaimsPrincipal(claimsIdentity);

            }
            return true;
        }
    }
}
