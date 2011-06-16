using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DeSerializeSupport
/// </summary>
public static class DeSerializeSupport
{
  #region metodi in deserializzazione

  public static void ElaboraSessioni(dbInteraction DBI, JSONObject coop)
  {
    foreach (SessioneGiorno sg in coop.Sessioni)
    {
      int idSessione = DBI.AddGiornata(sg);
      for (int i = 0; i < coop.TrainiEff.Count; i++)
      {
        Traini tr = coop.TrainiEff[i];
        tr.IDGiornata = idSessione;
        coop.TrainiEff[i] = tr;
      }
    }
  }

  public static void ElaboraAereiDaTraino(dbInteraction DBI, JSONObject coop)
  {
    foreach (ModelloAereo ma in coop.AereiTrainanti)
    {
      int idAereo = DBI.AddModTrainatore(ma);
      if (idAereo == -1)
      {
        for (int i = 0; i < coop.Sessioni.Count; i++)
        {
          SessioneGiorno sg = coop.Sessioni[i];
          sg.IDModTrainatore = idAereo;
          coop.Sessioni[i] = sg;
        }
      }
    }
  }

  public static void ElaboraAlianti(dbInteraction DBI, JSONObject coop)
  {
    foreach (ModelloAereo ma in coop.Alianti)
    {
      int idAliante = DBI.AddModAliante(ma);
      if (idAliante != -1)
      {
        for (int i = 0; i < coop.TrainiEff.Count; i++)
        {
          Traini tr = coop.TrainiEff[i];
          tr.IDAliante = idAliante;
          coop.TrainiEff[i] = tr;
        }
      }
    }
  }

  public static void ElaboraIstruttori(dbInteraction DBI, JSONObject coop)
  {
    foreach (Pilota p in coop.Instructors)
    {
      int idPilot = DBI.AddInstructor(p);
      if (idPilot != -1)
      {
        for (int i = 0; i < coop.TrainiEff.Count; i++)
        {
          Traini tr = coop.TrainiEff[i];
          tr.IDIstruttore = idPilot;
          coop.TrainiEff[i] = tr;
        }
      }
    }
  }

  public static void ElaboraPilotiAlianti(dbInteraction DBI, JSONObject coop)
  {
    foreach (Pilota p in coop.PilsAli)
    {
      int idPilot = DBI.AddPilotAliante(p);
      if (idPilot != -1)
      {
        for (int i = 0; i < coop.TrainiEff.Count; i++)
        {
          Traini tr = coop.TrainiEff[i];
          tr.IDPilota = idPilot;
          coop.TrainiEff[i] = tr;
        }
      }
    }
  }

  public static void ElaboraTrainatori(dbInteraction DBI, JSONObject coop)
  {
    foreach (Pilota p in coop.Pils)
    {
      int idPilot = DBI.AddPilot(p);
      if (idPilot != -1)
      {
        for (int i = 0; i < coop.Sessioni.Count; i++)
        {
          SessioneGiorno sg = coop.Sessioni[i];
          sg.IDTrainatore = idPilot;
          coop.Sessioni[i] = sg;
        }
      }
    }
  }

  public static void ElaboraTraini(dbInteraction DBI, JSONObject coop)
  {
    foreach (Traini tr in coop.TrainiEff)
    {
      DBI.AddTraino(tr);
    }
  }

  #endregion
}