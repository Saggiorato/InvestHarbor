using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;

namespace InvestHarbor.Service.Extension
{
    public static class HttpContextExtension
    {
        private const string AuthCookieName = "BlueHarbor";

        public static void SetAuthCookie(this HttpContext context, IDataProtectionProvider dataProtectionProvider, bool rememberMe, object userData)
        {
            var dataProtector = GetDataProtector(dataProtectionProvider);
            //if rememberMe == true set CookieOptions expiration on Append

            //else append cookie with that expires with browser session
            if (rememberMe)
            {
                context.Response.Cookies.Append(AuthCookieName,
                    dataProtector.Protect(JsonConvert.SerializeObject(userData)),
                    new CookieOptions()
                    {
                        Expires = DateTime.Now.AddDays(30)
                    });
            }
            else
            {
                context.Response.Cookies.Append(AuthCookieName, dataProtector.Protect(JsonConvert.SerializeObject(userData)));
            }

            //var cookie = context.Request.Cookies[AuthCookieName].ToString();
            context.Session.Set(AuthCookieName, Encoding.UTF8.GetBytes(dataProtector.Protect(JsonConvert.SerializeObject(userData))));
        }

        public static void RemoveAuthCookie(this HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey(AuthCookieName))
            {
                context.Response.Cookies.Delete(AuthCookieName, new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(-1)
                });
            }
        }

        public static T GetAuthCookieData<T>(this HttpContext context, IDataProtectionProvider dataProtectionProvider)
        {
            var dataProtector = GetDataProtector(dataProtectionProvider);

            if (!context.Request.Cookies.ContainsKey(AuthCookieName))
            {
                throw new Exception("Invalid Auth Cookie Name");
            }

            var cookie = context.Request.Cookies[AuthCookieName].ToString();
            context.Session.Set(AuthCookieName, Encoding.UTF8.GetBytes(dataProtector.Unprotect(cookie)));

            return JsonConvert.DeserializeObject<T>(dataProtector.Unprotect(cookie));
        }

        private static IDataProtector GetDataProtector(IDataProtectionProvider dataProtectionProvider)
        {
            return dataProtectionProvider.CreateProtector("IdentitySecurity");
        }
    }
}
