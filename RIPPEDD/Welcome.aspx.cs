﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RIPPEDD.Controllers;
using RIPPEDD.Entities;

namespace RIPPEDD
{
    public partial class Welcome : System.Web.UI.Page
    {
        WelcomeController dbObject = new WelcomeController();

        protected void Page_Load(object sender, System.EventArgs e)
        {

            NumberOfActivitesByDate.Series["Series1"].YValueMembers = "# of Activities";
            NumberOfActivitesByDate.Series["Series1"].XValueMember = "# of Weeks";

            NumberOfActivitesByDate.DataSource = dbObject.GetActivityData(((SessionData)Session["User_Data"])._loginID, 1);
            NumberOfActivitesByDate.DataBind();

        }
        protected void InputHealth_Click(object sender, EventArgs e)
        {
            Response.Redirect("HealthInput.aspx");
        }

        protected void HealthProfessionals_Click(object sender, EventArgs e)
        {
            Response.Redirect("HealthProfessionals.aspx");
        }

        protected void GenerateHealthReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("HealthInputReport.aspx");
        }


    }
}