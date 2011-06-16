using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class visualizzaTraini : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      DropDownList1.Items.Clear();
      dbInteraction DBI = new dbInteraction();
      DataTable dt = DBI.RetrievePiloti("Trainatore");
      for (int i = 0; i < dt.Rows.Count; i++)
      {
        DropDownList1.Items.Add(new ListItem(string.Format("{0} {1}", dt.Rows[i][1], dt.Rows[i][2]), dt.Rows[i][0].ToString()));
      }
    }
  }

  protected void RetrieveSessioni(int idPilota)
  {
    dbInteraction DBI = new dbInteraction();
    DropDownList2.Items.Clear();
    DataTable dt = DBI.RetrieveSessioni(idPilota);
    for (int i = 0; i < dt.Rows.Count; i++)
    {
      string data = dt.Rows[i][1].ToString().Split(' ')[0];
      DropDownList2.Items.Add(new ListItem(data, dt.Rows[i][0].ToString()));
    }
    if (DropDownList2.Items.Count > 0)
      RetrieveTraini(Convert.ToInt32(DropDownList2.Items[0].Value));
    else
    {
      GridView1.DataSource = null;
      GridView1.DataBind();
    }

  }

  protected void RetrieveTraini(int idTraino)
  {
    dbInteraction DBI = new dbInteraction();
    DataTable dt = DBI.RetrieveTraini(idTraino);
    GridView1.DataSource = dt;
    GridView1.DataBind();
  }

  protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
  {
    RetrieveSessioni(Convert.ToInt32(DropDownList1.SelectedItem.Value));
  }
  protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
  {
    RetrieveTraini(Convert.ToInt32(DropDownList2.SelectedItem.Value));
  }
}