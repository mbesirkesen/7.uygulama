using System;
using System.Collections.Generic;

abstract class Urun
{
    public string Ad { get; set; }
    public decimal Fiyat { get; set; }

    protected Urun(string ad, decimal fiyat)
    {
        Ad = ad;
        Fiyat = fiyat;
    }

    public abstract decimal HesaplaOdeme();

    public virtual string BilgiYazdir()
    {
        return $"Ürün: {Ad}, Fiyat: {Fiyat:C}";
    }
}

class Kitap : Urun
{
    public string Yazar { get; set; }
    public string ISBN { get; set; }

    public Kitap(string ad, decimal fiyat, string yazar, string isbn)
        : base(ad, fiyat)
    {
        Yazar = yazar;
        ISBN = isbn;
    }

    public override decimal HesaplaOdeme()
    {
        return Fiyat * 1.10m; 
    }

    public override string BilgiYazdir()
    {
        return base.BilgiYazdir() + $", Yazar: {Yazar}, ISBN: {ISBN}, Ödenecek Tutar: {HesaplaOdeme():C}";
    }
}

class Elektronik : Urun
{
    public string Marka { get; set; }
    public string Model { get; set; }

    public Elektronik(string ad, decimal fiyat, string marka, string model)
        : base(ad, fiyat)
    {
        Marka = marka;
        Model = model;
    }

    public override decimal HesaplaOdeme()
    {
        return Fiyat * 1.25m; 
    }

    public override string BilgiYazdir()
    {
        return base.BilgiYazdir() + $", Marka: {Marka}, Model: {Model}, Ödenecek Tutar: {HesaplaOdeme():C}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Urun> urunler = new List<Urun>();

        urunler.Add(new Kitap("Yüzüklerin Efendisi", 50m, "J.R.R. Tolkien", "978-975-342-418-8"));
        urunler.Add(new Elektronik("Laptop", 3000m, "Dell", "Inspiron 15"));
        urunler.Add(new Kitap("Harry Potter ve Felsefe Taşı", 40m, "J.K. Rowling", "978-975-080-438-3"));
        urunler.Add(new Elektronik("Akıllı Telefon", 5000m, "Apple", "iPhone 13"));

        foreach (var urun in urunler)
        {
            Console.WriteLine(urun.BilgiYazdir());
        }
    }
}
