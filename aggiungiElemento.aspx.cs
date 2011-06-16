using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class aggiungiElemento : System.Web.UI.Page
{
  int c;
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["idTbl"] == null)
    {

    }
    else
    {
      c = Convert.ToInt32(Session["idTbl"]);
      switch (c)
      {
        case 0: PreparaPilota(); break;
        case 1: PreparaPilota(); break;
        case 2: PreparaPilota(); break;
        case 3: PreparaAereo(); break;
        case 4: PreparaAereo(); break;
        default: break;
      }
      if (Session["result"] != null)
      {
        lblStat.Visible = true;
        if ((int)Session["result"] == -1)
          lblStat.Text = "Elemento aggiunto correttamente";
        else if ((int)Session["result"] != -1)
          lblStat.Text = "Elemento già presente nel database";
        Session["result"] = null;
      }
    }
  }

  protected void PreparaPilota()
  {
    lblPara1.Text = "Nome Pilota:";
    lblPara2.Text = "Cognome Pilota:";
  }
  protected void PreparaAereo()
  {
    lblPara1.Text = "Codice veicolo";
    lblPara2.Text = "Descrizione del veicolo";
  }

  protected void btnAdd_Click(object sender, EventArgs e)
  {
    dbInteraction DBI = new dbInteraction();
    if (txtPara1.Text != "" && txtpara2.Text != "")
    {
      switch (c)
      {
        case 0: Session["result"] = DBI.AddPilot(new Pilota(txtPara1.Text, txtpara2.Text)); break;
        case 1: Session["result"] = DBI.AddPilotAliante(new Pilota(txtPara1.Text, txtpara2.Text)); break;
        case 2: Session["result"] = DBI.AddInstructor(new Pilota(txtPara1.Text, txtpara2.Text)); break;
        case 3: Session["result"] = DBI.AddModTrainatore(new ModelloAereo(txtPara1.Text, txtpara2.Text)); break;
        case 4: Session["result"] = DBI.AddModAliante(new ModelloAereo(txtPara1.Text, txtpara2.Text)); break;
        default: break;
      }
    }
    Response.Redirect("~/aggiungiElemento.aspx");
  }
}