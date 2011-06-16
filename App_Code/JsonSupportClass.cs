using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for JsonSupportClass
/// </summary>
public class JSONObject
{
    private List<Pilota> Pils; 
    private List<Pilota> PilsAli; 
    private List<Pilota> Instructors; 
    private List<ModelloAereo> AereiTrainanti;
    private List<ModelloAereo> Alianti;
    private List<SessioneGiorno> Sessioni;
    private List<Traini> TrainiEff;

    public List<Pilota> pils
    {
        get { return Pils; }
        set { Pils = value; }
    }   

    public List<Pilota> pilsAli
    {
        get { return PilsAli; }
        set { PilsAli = value; }
    }
    
    public List<Pilota> instructors
    {
        get { return Instructors; }
        set { Instructors = value; }
    }
    
    public List<ModelloAereo> aereiTrainanti
    {
        get { return AereiTrainanti; }
        set { AereiTrainanti = value; }
    }
    
    public List<ModelloAereo> alianti
    {
        get { return Alianti; }
        set { Alianti = value; }
    }
    

    public List<SessioneGiorno> sessioni
    {
        get { return Sessioni; }
        set { Sessioni = value; }
    }
    

    public List<Traini> trainiEff
    {
        get { return TrainiEff; }
        set { TrainiEff = value; }
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

    public int id
    {
        get { return _id; }
        set { _id = value; }
    }
    private string _nome, _cognome;

    public string cognome
    {
        get { return _cognome; }
        set { _cognome = value; }
    }

    public string nome
    {
        get { return _nome; }
        set { _nome = value; }
    }

    public Pilota(string nome, string cognome)
    {
        _nome = nome;
        _cognome = cognome;
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

    public int id
    {
        get { return _id; }
        set { _id = value; }
    }
    private string _model;

    public string model
    {
        get { return _model; }
        set { _model = value; }
    }

    private string _code;

    public string code
    {
        get { return _code; }
        set { _code = value; }
    }

    public ModelloAereo(string codice, string modello)
    {
        _code = codice;
        _model = modello;
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