using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["logIn"] == null || !(bool)Session["logIn"])
        {
            HyperLink0.Visible = false;
            HyperLink1.Visible = false;
            HyperLink2.Visible = false;
            HyperLink3.Visible = false;
            Label1.Text = "Login";

            if (Session["logIn"] != null)
            {
                lblErr.Visible = true;
            }
        }
        else
        {
            Label1.Text = "Link rapidi";
            lblPass.Visible = false;
            lblUsr.Visible = false;
            usrName.Visible = false;
            usrPass.Visible = false;
            lgnButt.Visible = false;
        }

    }
    protected void lgnButt_Click(object sender, EventArgs e)
    {
        dbInteraction DBI = new dbInteraction();
        Session["Login"] = DBI.ExecuteLogin(usrName.Text, usrPass.Text);
        Response.Redirect("~/index.aspx");
    }
}