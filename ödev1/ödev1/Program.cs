using System;

class Calisan
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public decimal Maas { get; set; }
    public string Pozisyon { get; set; }

    public Calisan(string ad, string soyad, decimal maas, string pozisyon)
    {
        Ad = ad;
        Soyad = soyad;
        Maas = maas;
        Pozisyon = pozisyon;
    }

    public virtual string BilgiYazdir()
    {
        return $"{Ad} {Soyad} - {Pozisyon}, Maaş: {Maas} TL";
    }
}

class Yazilimci : Calisan
{
    public string YazilimDili { get; set; }

    public Yazilimci(string ad, string soyad, decimal maas, string pozisyon, string yazilimDili)
        : base(ad, soyad, maas, pozisyon)
    {
        YazilimDili = yazilimDili;
    }

    public override string BilgiYazdir()
    {
        return base.BilgiYazdir() + $", Yazılım Dili: {YazilimDili}";
    }
}

class Muhasebeci : Calisan
{
    public string MuhasebeYazilimi { get; set; }

    public Muhasebeci(string ad, string soyad, decimal maas, string pozisyon, string muhasebeYazilimi)
        : base(ad, soyad, maas, pozisyon)
    {
        MuhasebeYazilimi = muhasebeYazilimi;
    }

    public override string BilgiYazdir()
    {
        return base.BilgiYazdir() + $", Muhasebe Yazılımı: {MuhasebeYazilimi}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Çalışan türünü seçin (Yazilimci/Muhasebeci): ");
        string calisanTuru = Console.ReadLine();

        Console.Write("Ad: ");
        string ad = Console.ReadLine();
        Console.Write("Soyad: ");
        string soyad = Console.ReadLine();
        Console.Write("Maaş: ");
        decimal maas = decimal.Parse(Console.ReadLine());

        Calisan calisan;
        if (calisanTuru == "Yazilimci")
        {
            Console.Write("Yazılım Dili: ");
            string yazilimDili = Console.ReadLine();
            calisan = new Yazilimci(ad, soyad, maas, calisanTuru, yazilimDili);
        }
        else if (calisanTuru == "Muhasebeci")
        {
            Console.Write("Muhasebe Yazılımı: ");
            string muhasebeYazilimi = Console.ReadLine();
            calisan = new Muhasebeci(ad, soyad, maas, calisanTuru, muhasebeYazilimi);
        }
        else
        {
            Console.WriteLine("Geçersiz çalışan türü.");
            return;
        }

        Console.WriteLine(calisan.BilgiYazdir());
    }
}
