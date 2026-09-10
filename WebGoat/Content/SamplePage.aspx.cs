using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OWASP.WebGoat.NET
{
    public partial class SamplePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string term = Request.QueryString["q"];
            if (term != null)
                RenderSearchSummary(term);
        }

        // CodeQL: cs/web/xss (High) - query string value written to the response without HTML encoding
        private void RenderSearchSummary(string term)
        {
            Response.Write("<div class=\"search-summary\">No results found for: " + term + "</div>");
        }
    }
}