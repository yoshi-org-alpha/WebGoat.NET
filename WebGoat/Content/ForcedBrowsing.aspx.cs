using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace OWASP.WebGoat.NET
{
    public partial class ForcedBrowsing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string report = Request.QueryString["report"];
            if (!string.IsNullOrEmpty(report))
                ShowReport(report);
        }

        // CodeQL: cs/path-injection (High) - query string value used to build a file path with no containment check
        private void ShowReport(string report)
        {
            string path = Path.Combine(Server.MapPath("~/Downloads"), report);
            string contents = File.ReadAllText(path);

            Response.Write("<pre>" + Server.HtmlEncode(contents) + "</pre>");
        }
    }
}