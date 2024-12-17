
using System;

class Hayvan
{
    public string Ad { get; set; }
    public string Tur { get; set; }
    public int Yas { get; set; }

    public Hayvan(string ad, string tur, int yas)
    {
        Ad = ad;
        Tur = tur;
        Yas = yas;
    }

    public virtual string SesCikar()
    {
        return "Hayvan sesi";
    }

    public virtual string BilgiYazdir()
    {
        return $"Ad: {Ad}, Tür: {Tur}, Yaş: {Yas}";
    }
}

class Memeli : Hayvan
{
    public string TuyRengi { get; set; }

    public Memeli(string ad, string tur, int yas, string tuyRengi)
        : base(ad, tur, yas)
    {
        TuyRengi = tuyRengi;
    }

    public override string SesCikar()
    {
        return "Memeli sesi";
    }

    public override string BilgiYazdir()
    {
        return base.BilgiYazdir() + $", Tüy Rengi: {TuyRengi}";
    }
}

class Kus : Hayvan
{
    public double KanatGenisligi { get; set; }

    public Kus(string ad, string tur, int yas, double kanatGenisligi)
        : base(ad, tur, yas)
    {
        KanatGenisligi = kanatGenisligi;
    }

    public override string SesCikar()
    {
        return "Kuş sesi";
    }

    public override string BilgiYazdir()
    {
        return base.BilgiYazdir() + $", Kanat Genişliği: {KanatGenisligi} cm";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Hayvan türünü seçin (Memeli/Kus): ");
        string hayvanTuru = Console.ReadLine();

        Console.Write("Ad: ");
        string ad = Console.ReadLine();
        Console.Write("Tür: ");
        string tur = Console.ReadLine();
        Console.Write("Yaş: ");
        int yas = int.Parse(Console.ReadLine());

        Hayvan hayvan;
        if (hayvanTuru == "Memeli")
        {
            Console.Write("Tüy Rengi: ");
            string tuyRengi = Console.ReadLine();
            hayvan = new Memeli(ad, tur, yas, tuyRengi);
        }
        else if (hayvanTuru == "Kus")
        {
            Console.Write("Kanat Genişliği (cm): ");
            double kanatGenisligi = double.Parse(Console.ReadLine());
            hayvan = new Kus(ad, tur, yas, kanatGenisligi);
        }
        else
        {
            Console.WriteLine("Geçersiz hayvan türü.");
            return;
        }

        Console.WriteLine(hayvan.BilgiYazdir());
        Console.WriteLine("Ses: " + hayvan.SesCikar());
    }
}
