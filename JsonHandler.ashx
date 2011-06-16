<%@ WebHandler Language="C#" Class="JsonHandler" %>

using System;
using System.IO;
using System.Web;
using Newtonsoft.Json;

public class JsonHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        if (context.Request["traino"] != null)
        {
            try
            {
                dbInteraction DBI = new dbInteraction();
                JSONObject coop = JsonConvert.DeserializeObject<JSONObject>((string)context.Request["traino"]);
                //Piloti trainatori
                DeSerializeSupport.ElaboraTrainatori(DBI, coop);
                //Piloti alianti
                DeSerializeSupport.ElaboraPilotiAlianti(DBI, coop);
                //Piloti istruttori
                DeSerializeSupport.ElaboraIstruttori(DBI, coop);
                //Alianti
                DeSerializeSupport.ElaboraAlianti(DBI, coop);
                //Aereo da traino
                DeSerializeSupport.ElaboraAereiDaTraino(DBI, coop);
                //Sessioni giornaliere
                DeSerializeSupport.ElaboraSessioni(DBI, coop);
                //Traini effettuati
                DeSerializeSupport.ElaboraTraini(DBI, coop);
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