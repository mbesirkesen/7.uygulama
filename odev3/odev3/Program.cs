using System;

class Hesap
{
    public string HesapNumarasi { get; set; }
    public decimal Bakiye { get; set; }
    public string HesapSahibi { get; set; }

    public Hesap(string hesapNumarasi, decimal bakiye, string hesapSahibi)
    {
        HesapNumarasi = hesapNumarasi;
        Bakiye = bakiye;
        HesapSahibi = hesapSahibi;
    }

    public virtual string ParaYatir(decimal miktar)
    {
        Bakiye += miktar;
        return $"{miktar} TL yatırıldı. Güncel bakiye: {Bakiye} TL";
    }

    public virtual string ParaCek(decimal miktar)
    {
        if (Bakiye >= miktar)
        {
            Bakiye -= miktar;
            return $"{miktar} TL çekildi. Güncel bakiye: {Bakiye} TL";
        }
        else
        {
            return "Yetersiz bakiye.";
        }
    }

    public virtual string BilgiYazdir()
    {
        return $"Hesap Numarası: {HesapNumarasi}, Bakiye: {Bakiye} TL, Hesap Sahibi: {HesapSahibi}";
    }
}

class VadesizHesap : Hesap
{
    public decimal EkHesapLimiti { get; set; }

    public VadesizHesap(string hesapNumarasi, decimal bakiye, string hesapSahibi, decimal ekHesapLimiti)
        : base(hesapNumarasi, bakiye, hesapSahibi)
    {
        EkHesapLimiti = ekHesapLimiti;
    }

    public override string ParaYatir(decimal miktar)
    {
        return base.ParaYatir(miktar) + $", Ek Hesap Limiti: {EkHesapLimiti} TL";
    }

    public override string BilgiYazdir()
    {
        return base.BilgiYazdir() + $", Ek Hesap Limiti: {EkHesapLimiti} TL";
    }
}

class VadeliHesap : Hesap
{
    public int VadeSuresi { get; set; }
    public decimal FaizOrani { get; set; }

    public VadeliHesap(string hesapNumarasi, decimal bakiye, string hesapSahibi, int vadeSuresi, decimal faizOrani)
        : base(hesapNumarasi, bakiye, hesapSahibi)
    {
        VadeSuresi = vadeSuresi;
        FaizOrani = faizOrani;
    }

    public override string ParaYatir(decimal miktar)
    {
        return base.ParaYatir(miktar) + $", Faiz Oranı: {FaizOrani}%";
    }

    public override string ParaCek(decimal miktar)
    {
        if (VadeSuresi <= 0)
        {
            return base.ParaCek(miktar);
        }
        else
        {
            return "Vade süresi dolmadan para çekemezsiniz.";
        }
    }

    public override string BilgiYazdir()
    {
        return base.BilgiYazdir() + $", Vade Süresi: {VadeSuresi} gün, Faiz Oranı: {FaizOrani}%";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Hesap türünü seçin (VadesizHesap/VadeliHesap): ");
        string hesapTuru = Console.ReadLine();

        Console.Write("Hesap Numarası: ");
        string hesapNumarasi = Console.ReadLine();
        Console.Write("Hesap Sahibi: ");
        string hesapSahibi = Console.ReadLine();
        Console.Write("Bakiye: ");
        decimal bakiye = decimal.Parse(Console.ReadLine());

        Hesap hesap;
        if (hesapTuru == "VadesizHesap")
        {
            Console.Write("Ek Hesap Limiti: ");
            decimal ekHesapLimiti = decimal.Parse(Console.ReadLine());
            hesap = new VadesizHesap(hesapNumarasi, bakiye, hesapSahibi, ekHesapLimiti);
        }
        else if (hesapTuru == "VadeliHesap")
        {
            Console.Write("Vade Süresi (gün): ");
            int vadeSuresi = int.Parse(Console.ReadLine());
            Console.Write("Faiz Oranı (%): ");
            decimal faizOrani = decimal.Parse(Console.ReadLine());
            hesap = new VadeliHesap(hesapNumarasi, bakiye, hesapSahibi, vadeSuresi, faizOrani);
        }
        else
        {
            Console.WriteLine("Geçersiz hesap türü.");
            return;
        }

        Console.WriteLine(hesap.BilgiYazdir());

        Console.Write("Yatırılacak miktar: ");
        decimal yatirMiktar = decimal.Parse(Console.ReadLine());
        Console.WriteLine(hesap.ParaYatir(yatirMiktar));

        Console.Write("Çekilecek miktar: ");
        decimal cekMiktar = decimal.Parse(Console.ReadLine());
        Console.WriteLine(hesap.ParaCek(cekMiktar));
    }
}
