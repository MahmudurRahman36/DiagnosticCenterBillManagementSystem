﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiagnosticCenterBillMgmtApp.UI
{
    public partial class StartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void startButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        
    }
}