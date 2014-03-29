﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using RIPPEDD.Health_Input;
using RIPPEDD.Controllers;

namespace RIPPEDD
{
    public partial class HealthInput : System.Web.UI.Page
    {
        private string imageMapClick = "";
        
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            WorkoutChoices_Initialize();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            lblSubmissionInfo.Visible = false;

            if (ddlWorkoutChoices.Items.Count < 1)
            {
                foreach (View view in WorkoutChoices.Views)
                {
                    ddlWorkoutChoices.Items.Add(view.ID.ToString());
                }
            }


        }

        protected void WorkoutChoices_Initialize()
        {
            foreach (View view in WorkoutChoices.Views)
            {
                if (view.ID.ToString().Equals("Welcome"))
                {
                    WorkoutChoices.SetActiveView(view);
                }
            }
        }

        protected void WorkoutChoices_SetView(object sender, EventArgs e)
        {
            foreach (View view in WorkoutChoices.Views)
            {
                if (view.ID.ToString().Equals(ddlWorkoutChoices.Text))
                {
                    WorkoutChoices.SetActiveView(view);
                }
            }

        }

        protected void SetInjury(object sender, ImageMapEventArgs e)
        {

           /* if (dictInjury.ContainsKey(e.PostBackValue))
            {
                dictInjury[e.PostBackValue] = 1;
            }*/

            

        }

        protected void btnSubmitResults_Click(object sender, EventArgs e)
        {
            //http://stackoverflow.com/questions/13362904/convert-control-to-textbox-and-assign-it-a-value
            //foreach (TextBox txtBox in this.Controls)
            //{
             
            //    if (txtBox.Visible && txtBox.Text.Length > 0)
            //    {
            //        float dControl;
            //        float.TryParse(txtBox.Text, NumberStyles.Currency, NumberFormatInfo.InvariantInfo, out dControl);

            //        HealthInputSessionVariables.Activity.Add(txtBox.ID.Remove(0, 3), dControl);
            //    }
            //}

            System.Diagnostics.Debug.WriteLine("Click test");
            //System.Diagnostics.Debug.WriteLine(WorkoutChoices.GetActiveView().ToString());

            // string current = WorkoutChoices.GetActiveView().ID.ToString();

            HealthInputController controller = new HealthInputController();

            switch (WorkoutChoices.GetActiveView().ID.ToString())
            {

                case "Welcome":
                    System.Diagnostics.Debug.WriteLine("1");
                    break;

                case "CardioWorkout":

                    if (controller.inputCardioWorkout(txtRoadRunning.Text, txtTreadmill.Text, txtCycling.Text, txtSwimming.Text, txtWalking.Text, txtRowing.Text))
                    {
                        //Input is valid
                        string script = "alert(\"Success!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                    else
                    {
                        //Input invalid
                        string script = "alert(\"Warning: One of your inputs is not a numeric value\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }



                    System.Diagnostics.Debug.WriteLine("2");
                    break;

                case "StrengthWorkout":
                    System.Diagnostics.Debug.WriteLine("3");
                    break;

                case "WorkActivities":
                    System.Diagnostics.Debug.WriteLine("4");
                    break;


                case "HealthIndicators":
                    System.Diagnostics.Debug.WriteLine("5");
                    break;

                case "CouchPotato":
                    System.Diagnostics.Debug.WriteLine("6");
                    break;

                case "Injuries":
                    System.Diagnostics.Debug.WriteLine("7");
                    break;


            }

            //Response.Redirect("HealthInputReport.aspx");
            controller = null;
            GC.Collect();
        }


    }
}