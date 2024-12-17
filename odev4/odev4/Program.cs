using System;

abstract class Hesap
{
    public string HesapNo { get; set; }
    public decimal Bakiye { get; set; }
    public string HesapSahibi { get; set; }

    public Hesap(string hesapNo, decimal bakiye, string hesapSahibi)
    {
        HesapNo = hesapNo;
        Bakiye = bakiye;
        HesapSahibi = hesapSahibi;
    }

    public virtual void ParaYatir(decimal miktar)
    {
        Bakiye += miktar;
        Console.WriteLine($"{miktar} TL yatırıldı. Güncel bakiye: {Bakiye} TL");
    }

    public abstract void ParaCek(decimal miktar);

    public virtual string BilgiYazdir()
    {
        return $"Hesap No: {HesapNo}, Bakiye: {Bakiye} TL, Hesap Sahibi: {HesapSahibi}";
    }
}

class BirikimHesabi : Hesap
{
    public decimal FaizOrani { get; set; }

    public BirikimHesabi(string hesapNo, decimal bakiye, string hesapSahibi, decimal faizOrani)
        : base(hesapNo, bakiye, hesapSahibi)
    {
        FaizOrani = faizOrani;
    }

    public override void ParaYatir(decimal miktar)
    {
        base.ParaYatir(miktar);
        decimal faiz = (Bakiye * FaizOrani) / 100;
        Bakiye += faiz;
        Console.WriteLine($"Faiz hesaplandı: {faiz} TL. Güncel bakiye: {Bakiye} TL");
    }

    public override void ParaCek(decimal miktar)
    {
        if (Bakiye >= miktar)
        {
            Bakiye -= miktar;
            Console.WriteLine($"{miktar} TL çekildi. Güncel bakiye: {Bakiye} TL");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye.");
        }
    }

    public override string BilgiYazdir()
    {
        return base.BilgiYazdir() + $", Faiz Oranı: {FaizOrani}%";
    }
}

class VadesizHesap : Hesap
{
    public decimal IslemUcreti { get; set; }

    public VadesizHesap(string hesapNo, decimal bakiye, string hesapSahibi, decimal islemUcreti)
        : base(hesapNo, bakiye, hesapSahibi)
    {
        IslemUcreti = islemUcreti;
    }

    public override void ParaCek(decimal miktar)
    {
        decimal toplamMiktar = miktar + IslemUcreti;
        if (Bakiye >= toplamMiktar)
        {
            Bakiye -= toplamMiktar;
            Console.WriteLine($"{miktar} TL çekildi. İşlem ücreti: {IslemUcreti} TL. Güncel bakiye: {Bakiye} TL");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye.");
        }
    }

    public override string BilgiYazdir()
    {
        return base.BilgiYazdir() + $", İşlem Ücreti: {IslemUcreti} TL";
    }
}

interface IBankaHesabi
{
    DateTime HesapAcilisTarihi { get; set; }
    string HesapOzeti();
}

class BankaHesabi : Hesap, IBankaHesabi
{
    public DateTime HesapAcilisTarihi { get; set; }

    public BankaHesabi(string hesapNo, decimal bakiye, string hesapSahibi, DateTime hesapAcilisTarihi)
        : base(hesapNo, bakiye, hesapSahibi)
    {
        HesapAcilisTarihi = hesapAcilisTarihi;
    }

    public override void ParaCek(decimal miktar)
    {
        // Boş bırakıldı çünkü bu sınıf bir türetilmiş sınıf değil, sadece arayüzü uygulamak için.
    }

    public string HesapOzeti()
    {
        return $"{BilgiYazdir()}, Hesap Açılış Tarihi: {HesapAcilisTarihi.ToShortDateString()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        BirikimHesabi birikimHesabi = new BirikimHesabi("TR1234567890", 5000, "Ahmet Yılmaz", 3.5m);
        birikimHesabi.ParaYatir(2000);
        birikimHesabi.ParaCek(1000);
        Console.WriteLine(birikimHesabi.BilgiYazdir());

        VadesizHesap vadesizHesap = new VadesizHesap("TR0987654321", 3000, "Mehmet Kaya", 2m);
        vadesizHesap.ParaYatir(1000);
        vadesizHesap.ParaCek(500);
        Console.WriteLine(vadesizHesap.BilgiYazdir());

        BankaHesabi bankaHesabi1 = new BankaHesabi("TR5678901234", 8000, "Ayşe Demir", DateTime.Now.AddYears(-2));
        Console.WriteLine(bankaHesabi1.HesapOzeti());

        BankaHesabi bankaHesabi2 = new BankaHesabi("TR4321098765", 15000, "Fatma Gül", DateTime.Now.AddYears(-1));
        Console.WriteLine(bankaHesabi2.HesapOzeti());
    }
}
