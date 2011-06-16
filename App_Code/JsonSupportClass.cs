using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for JsonSupportClass
/// </summary>
public class JSONObject
{
    private List<Pilota> pils; 
    private List<Pilota> pilsAli; 
    private List<Pilota> instructors; 
    private List<ModelloAereo> aereiTrainanti;
    private List<ModelloAereo> alianti;
    private List<SessioneGiorno> sessioni;
    private List<Traini> trainiEff;

    public List<Pilota> Pils
    {
        get { return pils; }
        set { pils = value; }
    }   

    public List<Pilota> PilsAli
    {
        get { return pilsAli; }
        set { pilsAli = value; }
    }
    
    public List<Pilota> Instructors
    {
        get { return instructors; }
        set { instructors = value; }
    }
    
    public List<ModelloAereo> AereiTrainanti
    {
        get { return aereiTrainanti; }
        set { aereiTrainanti = value; }
    }
    
    public List<ModelloAereo> Alianti
    {
        get { return alianti; }
        set { alianti = value; }
    }
    

    public List<SessioneGiorno> Sessioni
    {
        get { return sessioni; }
        set { sessioni = value; }
    }
    

    public List<Traini> TrainiEff
    {
        get { return trainiEff; }
        set { trainiEff = value; }
    }

	public JSONObject()
	{
        pils = new List<Pilota>();
        pilsAli = new List<Pilota>();
        instructors = new List<Pilota>();
        aereiTrainanti = new List<ModelloAereo>();
        alianti = new List<ModelloAereo>();
        sessioni = new List<SessioneGiorno>();
        trainiEff = new List<Traini>();
	}
}

public class Pilota
{
    private int _id;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    private string _nome, _cognome;

    public string Cognome
    {
        get { return _cognome; }
        set { _cognome = value; }
    }

    public string Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }

    public Pilota()
    {
    }
}

public class SessioneGiorno
{

    private int _id, _IDTrainatore, _IDModTrainatore;

    public int IDModTrainatore
    {
        get { return _IDModTrainatore; }
        set { _IDModTrainatore = value; }
    }

    public int IDTrainatore
    {
        get { return _IDTrainatore; }
        set { _IDTrainatore = value; }
    }

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    private string _data, uniOrametro;

    public string UniOrametro
    {
        get { return uniOrametro; }
        set { uniOrametro = value; }
    }

    public string Data
    {
        get { return _data; }
        set { _data = value; }
    }

    public SessioneGiorno()
    {
    }
}

public class ModelloAereo
{
    private int _id;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    private string _model;

    public string Model
    {
        get { return _model; }
        set { _model = value; }
    }

    public ModelloAereo()
    {

    }
}

public class Traini
{
    private int _id, _IDGiornata, _IDAliante, _IDPilota, _IDIstruttore;
    private double _tempoOrametro;

    public int IDIstruttore
    {
        get { return _IDIstruttore; }
        set { _IDIstruttore = value; }
    }

    public int IDPilota
    {
        get { return _IDPilota; }
        set { _IDPilota = value; }
    }

    public int IDAliante
    {
        get { return _IDAliante; }
        set { _IDAliante = value; }
    }

    public int IDGiornata
    {
        get { return _IDGiornata; }
        set { _IDGiornata = value; }
    }

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    
    public double TempoOrametro
    {
        get { return _tempoOrametro; }
        set { _tempoOrametro = value; }
    }

    public Traini()
    {

    }
}