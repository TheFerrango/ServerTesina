using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class visualizzaVari : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["logIn"] == null)
        {
            Label1.Text = "Accesso non consentito!";
            Label2.Text = "Eseguire il login";
        }
        else
        {
            try
            {
                int scelta = Convert.ToInt32(Request.QueryString["tblInd"]);
                dbInteraction DBI = new dbInteraction();
                DataTable dt = new DataTable();
                switch (scelta)
                {
                    case 0: Label1.Text = "Piloti Trainatori"; Label2.Text = "Lista dei pilota trainatori"; Label3.Text = "Aggiungi Trainatore"; 
                        dt = DBI.RetrievePiloti("Trainatore"); ; break;
                    case 1: Label1.Text = "Piloti Alianti"; Label2.Text = "Lista dei piloti degli alianti"; Label3.Text = "Aggiungi Pilota aliante"; 
                        dt = DBI.RetrievePiloti("Pilota"); break;
                    case 2: Label1.Text = "Istruttori"; Label2.Text = "Lista dei piloti istruttori"; Label3.Text = "Aggiungi Istruttore"; 
                        dt = DBI.RetrievePiloti("Istruttore"); break;
                    case 3: Label1.Text = "Modelli aerei trainanti"; Label2.Text = "Lista dei modelli degli aerei trainanti registrati"; Label3.Text = "Aggiungi Aereo da traino"; 
                        dt = DBI.RetrieveAereo("ModelloTrainatore"); break;
                    case 4: Label1.Text = "Modelli Alianti"; Label2.Text = "Lista dei modelli degli alianti registrati"; Label3.Text = "Aggiungi Aliante";
                        dt = DBI.RetrieveAereo("ModelloAliante"); break;
                    default: throw new FormatException(); break;
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (FormatException)
            {
                Label1.Text = "Scelta errata";
                Label1.ForeColor = Color.Red;
                Label2.Text = "Si prega di selezionare una voce corretta";
            }
        }
    }
    protected void addBtn_Click(object sender, EventArgs e)
    {
        Session["idTbl"] = Request.QueryString["tblInd"].ToString();
        Response.Redirect("~/aggiungiElemento.aspx");
    }
}