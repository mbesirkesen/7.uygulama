using System;
using System.Collections.Generic;
interface IYayinci
{
    void AboneEkle(IAbone abone);
    void AboneCikar(IAbone abone);
    void AboneleriBilgilendir();
}
interface IAbone
{
    void BilgiAl(string mesaj);
}
class Yayinci : IYayinci
{
    private List<IAbone> aboneler = new List<IAbone>();
    private string _mesaj;

    public string Mesaj
    {
        get { return _mesaj; }
        set
        {
            _mesaj = value;
            AboneleriBilgilendir();
        }
    }

    public void AboneEkle(IAbone abone)
    {
        aboneler.Add(abone);
    }

    public void AboneCikar(IAbone abone)
    {
        aboneler.Remove(abone);
    }

    public void AboneleriBilgilendir()
    {
        foreach (var abone in aboneler)
        {
            abone.BilgiAl(_mesaj);
        }
    }
}
class Abone : IAbone
{
    private string _ad;

    public Abone(string ad)
    {
        _ad = ad;
    }

    public void BilgiAl(string mesaj)
    {
        Console.WriteLine($"{_ad} bilgilendirildi: {mesaj}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Yayinci yayinci = new Yayinci();

        Abone abone1 = new Abone("Abone 1");
        Abone abone2 = new Abone("Abone 2");
        Abone abone3 = new Abone("Abone 3");

        yayinci.AboneEkle(abone1);
        yayinci.AboneEkle(abone2);
        yayinci.AboneEkle(abone3);

        yayinci.Mesaj = "Yeni mesaj yayınlandı!";
        yayinci.AboneCikar(abone2);
        yayinci.Mesaj = "Başka bir mesaj yayınlandı!";
    }
}
