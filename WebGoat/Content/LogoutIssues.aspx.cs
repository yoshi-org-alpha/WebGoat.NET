using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OWASP.WebGoat.NET
{
    public partial class LogoutIssues : System.Web.UI.Page
    {
        // CodeQL: cs/web/unvalidated-url-redirection (Medium) - query string value used as a redirect target
        protected void Page_Load(object sender, EventArgs e)
        {
            string returnUrl = Request.QueryString["returnUrl"];
            if (!string.IsNullOrEmpty(returnUrl))
            {
                Session.Abandon();
                Response.Redirect(returnUrl);
            }
        }
    }
}