using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;
using NEO.Core;
using NEO.Common.Extension;

namespace NEO.Repository
{
    public class UserContext
    {
        public UserContext()
        {
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                return ;
            }

            try
            {
                var ticket = FormsAuthentication.Decrypt(cookie.Value);

                if (ticket == null || cookie.Value.IsNullOrEmpty())
                    return ;

                var userData =  JsonConvert.DeserializeObject<Profile>(ticket.UserData);
                UserProfile = userData;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Redirect("/Member/Member/Login");
                HttpContext.Current.Response.End();
            }
        }

        public static Profile UserProfile { get; set; }
    }
}
