using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace OWASP.WebGoat.NET
{
    public partial class CommandInjection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string host = Request.QueryString["host"];
            if (!string.IsNullOrEmpty(host))
                RunConnectivityCheck(host);
        }

        // CodeQL: cs/command-line-injection (Critical) - query string value concatenated into a shell command line
        private void RunConnectivityCheck(string host)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "/bin/bash";
            startInfo.Arguments = "-c \"ping -c 1 " + host + "\"";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;

            Process process = Process.Start(startInfo);
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            Response.Write("<pre>" + Server.HtmlEncode(result) + "</pre>");
        }
    }
}