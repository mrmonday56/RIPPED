﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RIPPEDD
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblIncorrectLogin.Visible = false;
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
            //HELLO
          
        }


    }
}