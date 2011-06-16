<%@ WebHandler Language="C#" Class="JsonHandler" %>

using System;
using System.IO;
using System.Web;
using Newtonsoft.Json;


public class JsonHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        File.AppendAllText(@"C:\MS-DOS\coop.txt", DateTime.Now.ToString() + Environment.NewLine);
        if (context.Request["traino"] != null)
        {
            try
            {
                dbInteraction DBI = new dbInteraction();
               
                JSONObject coop = JsonConvert.DeserializeObject<JSONObject>((string)context.Request["traino"]);
                Log((string)context.Request["traino"]);
                
                //Piloti trainatori
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

                //Piloti alianti
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
                
                //Piloti istruttori
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
                
                //Alianti
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

                //Aereo da traino
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
                
                //Sessioni giornaliere
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
                
                //Traini effettuati
                
                foreach (Traini tr in coop.TrainiEff)
                {
                    DBI.AddTraino(tr);
                }
            }
            catch (Exception e)
            {
                File.AppendAllText(@"C:\MS-DOS\ErrorLog.txt", e.Message + Environment.NewLine);
            }
        }
        else
            File.AppendAllText(@"C:\MS-DOS\coop.txt", "Succhia" + Environment.NewLine);

        context.Response.ContentType = "text/plain";
        context.Response.Write("OK");
    }

    public void Log(string text)
    {
        File.AppendAllText(@"C:\MS-DOS\coop.txt", text + Environment.NewLine);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}