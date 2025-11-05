# C# Nesne Yönelimli Programlama Ödevleri

Bu repository, C# programlama dili ile nesne yönelimli programlama (OOP) kavramlarının uygulandığı 6 farklı ödev projesini içermektedir.

## Projeler

### Ödev 1 - Kalıtım (Inheritance) - Çalışan Yönetim Sistemi
**Klasör:** `ödev1/ödev1`

Çalışan sınıfı ve türetilmiş sınıflar (Yazılımcı, Muhasebeci) üzerinden kalıtım kavramını gösterir.

**Özellikler:**
- Temel `Calisan` sınıfı
- `Yazilimci` ve `Muhasebeci` türetilmiş sınıfları
- Method override kullanımı
- Kullanıcıdan veri alarak çalışan bilgilerini gösterme

### Ödev 2 - Kalıtım (Inheritance) - Hayvan Yönetim Sistemi
**Klasör:** `odev2/odev2`

Hayvan sınıfı ve türetilmiş sınıflar (Memeli, Kuş) üzerinden kalıtım kavramını gösterir.

**Özellikler:**
- Temel `Hayvan` sınıfı
- `Memeli` ve `Kus` türetilmiş sınıfları
- `SesCikar()` ve `BilgiYazdir()` method override'ları

### Ödev 3 - Kalıtım ve Polimorfizm - Banka Hesap Yönetimi
**Klasör:** `odev3/odev3`

Banka hesap türleri üzerinden kalıtım ve polimorfizm kavramlarını gösterir.

**Özellikler:**
- Temel `Hesap` sınıfı
- `VadesizHesap` ve `VadeliHesap` türetilmiş sınıfları
- `ParaYatir()` ve `ParaCek()` method override'ları
- Vade kontrolü ve faiz oranı hesaplama

### Ödev 4 - Abstract Class ve Interface - Gelişmiş Banka Hesap Yönetimi
**Klasör:** `odev4/odev4`

Abstract class ve interface kavramlarını birlikte kullanarak banka hesap yönetimi uygular.

**Özellikler:**
- `Hesap` abstract sınıfı
- `BirikimHesabi` ve `VadesizHesap` concrete sınıfları
- `IBankaHesabi` interface'i ve `BankaHesabi` implementasyonu
- Abstract method (`ParaCek`) ve virtual method kullanımı

### Ödev 5 - Abstract Class - Ürün Yönetim Sistemi
**Klasör:** `odev5/odev5`

Abstract class kullanarak ürün yönetim sistemi uygular.

**Özellikler:**
- `Urun` abstract sınıfı
- `Kitap` ve `Elektronik` concrete sınıfları
- Abstract method (`HesaplaOdeme`) ile farklı ürün türleri için farklı ödeme hesaplama
- List koleksiyonu ile ürün yönetimi

### Ödev 6 - Observer Pattern (Tasarım Deseni)
**Klasör:** `odev6/odev6`

Observer tasarım desenini interface'ler üzerinden uygular.

**Özellikler:**
- `IYayinci` ve `IAbone` interface'leri
- `Yayinci` ve `Abone` sınıfları
- Observer pattern implementasyonu
- Abone ekleme/çıkarma ve bilgilendirme mekanizması

## Teknolojiler

- **.NET 8.0**
- **C# 12**
- **Console Application**

## Gereksinimler

- .NET 8.0 SDK veya üzeri
- Visual Studio 2022 veya Visual Studio Code (opsiyonel)

## Çalıştırma

Her bir ödev bağımsız bir proje olarak çalıştırılabilir:

```bash
# Örnek: Ödev 1'i çalıştırma
cd ödev1/ödev1
dotnet run

# Örnek: Ödev 2'yi çalıştırma
cd odev2/odev2
dotnet run
```

## Kavramlar

Bu projeler aşağıdaki OOP kavramlarını kapsar:

- ✅ **Kalıtım (Inheritance)**
- ✅ **Polimorfizm (Polymorphism)**
- ✅ **Encapsulation (Kapsülleme)**
- ✅ **Abstract Class**
- ✅ **Interface**
- ✅ **Method Override**
- ✅ **Tasarım Desenleri (Observer Pattern)**

## Lisans

Bu projeler eğitim amaçlıdır.

