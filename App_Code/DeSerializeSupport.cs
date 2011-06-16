using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;

/// <summary>
/// Summary description for DeSerializeSupport
/// </summary>
public static class DeSerializeSupport
{
  #region metodi in deserializzazione

  public static void ElaboraSessioni(dbInteraction DBI, JSONObject coop)
  {
    foreach (SessioneGiorno sg in coop.sessioni)
    {
      int idSessione = DBI.AddGiornata(sg);
      for (int i = 0; i < coop.trainiEff.Count; i++)
      {
        Traini tr = coop.trainiEff[i];
        tr.IDGiornata = idSessione;
        coop.trainiEff[i] = tr;
      }
    }
  }

  public static void ElaboraAereiDaTraino(dbInteraction DBI, JSONObject coop)
  {
    foreach (ModelloAereo ma in coop.aereiTrainanti)
    {
      int idAereo = DBI.AddModTrainatore(ma);
      if (idAereo == -1)
      {
        for (int i = 0; i < coop.sessioni.Count; i++)
        {
          SessioneGiorno sg = coop.sessioni[i];
          sg.IDModTrainatore = idAereo;
          coop.sessioni[i] = sg;
        }
      }
    }
  }

  public static void ElaboraAlianti(dbInteraction DBI, JSONObject coop)
  {
    foreach (ModelloAereo ma in coop.alianti)
    {
      int idAliante = DBI.AddModAliante(ma);
      if (idAliante != -1)
      {
        for (int i = 0; i < coop.trainiEff.Count; i++)
        {
          Traini tr = coop.trainiEff[i];
          tr.IDAliante = idAliante;
          coop.trainiEff[i] = tr;
        }
      }
    }
  }

  public static void ElaboraIstruttori(dbInteraction DBI, JSONObject coop)
  {
    foreach (Pilota p in coop.instructors)
    {
      int idPilot = DBI.AddInstructor(p);
      if (idPilot != -1)
      {
        for (int i = 0; i < coop.trainiEff.Count; i++)
        {
          Traini tr = coop.trainiEff[i];
          tr.IDIstruttore = idPilot;
          coop.trainiEff[i] = tr;
        }
      }
    }
  }

  public static void ElaboraPilotiAlianti(dbInteraction DBI, JSONObject coop)
  {
    foreach (Pilota p in coop.pilsAli)
    {
      int idPilot = DBI.AddPilotAliante(p);
      if (idPilot != -1)
      {
        for (int i = 0; i < coop.trainiEff.Count; i++)
        {
          Traini tr = coop.trainiEff[i];
          tr.IDPilota = idPilot;
          coop.trainiEff[i] = tr;
        }
      }
    }
  }

  public static void ElaboraTrainatori(dbInteraction DBI, JSONObject coop)
  {
    foreach (Pilota p in coop.pils)
    {
      int idPilot = DBI.AddPilot(p);
      if (idPilot != -1)
      {
        for (int i = 0; i < coop.sessioni.Count; i++)
        {
          SessioneGiorno sg = coop.sessioni[i];
          sg.IDTrainatore = idPilot;
          coop.sessioni[i] = sg;
        }
      }
    }
  }

  public static void ElaboraTraini(dbInteraction DBI, JSONObject coop)
  {
    foreach (Traini tr in coop.trainiEff)
    {
      DBI.AddTraino(tr);
    }
  }

  #endregion

  #region metodi di serializzazione

  public static string Serializzo()
  {
    dbInteraction DBI = new dbInteraction();
    JSONObject jObj = new JSONObject();
    DataTable dt = DBI.RetrievePiloti("Pilota");
    for (int i = 0; i < dt.Rows.Count; i++)
      jObj.pilsAli.Add(new Pilota(dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()));
    dt = DBI.RetrievePiloti("Trainatore");
    for (int i = 0; i < dt.Rows.Count; i++)
      jObj.pils.Add(new Pilota(dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()));
    
    dt = DBI.RetrievePiloti("Istruttore");
    for (int i = 0; i < dt.Rows.Count; i++)
      jObj.instructors.Add(new Pilota(dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()));
    dt = DBI.RetrieveAereo("ModelloAliante");
    for (int i = 0; i < dt.Rows.Count; i++)
      jObj.alianti.Add(new ModelloAereo(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString()));
    dt = DBI.RetrieveAereo("ModelloTrainatore");
    for (int i = 0; i < dt.Rows.Count; i++)
      jObj.aereiTrainanti.Add(new ModelloAereo(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString()));
    return JsonConvert.SerializeObject(jObj);
  }

  #endregion
}