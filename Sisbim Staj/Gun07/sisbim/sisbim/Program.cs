using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniMaestroConsole
{
    // Proje Sınıfı Tanımlaması
    public class Proje
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int MusteriId { get; set; }
        public string Durum { get; set; }
        public DateTime BaslangicTarihi { get; set; }
    }

    // Müşteri Sınıfı
    public class Musteri
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Eposta { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MİNİ MAESTRO YÖNETİM PANELİ");

            // Müşteri Listesi
            List<Musteri> musteriler = new List<Musteri>()
            {
                new Musteri { Id = 1, Ad = "Ahmet Yılmaz", Eposta = "ahmet@yilmaz.com" },
                new Musteri { Id = 2, Ad = "Ayşe Demir", Eposta = "ayse@demir.com" },
                new Musteri { Id = 3, Ad = "Mehmet Kaya", Eposta = "mehmet@kaya.com" },
                new Musteri { Id = 4, Ad = "Fatma Çelik", Eposta = "fatma@celik.com" },
                new Musteri { Id = 5, Ad = "Ali Şahin", Eposta = "ali@sahin.com" }
            };

            // Sayma Metodu Testi
            MusteriSayisiniYazdir(musteriler);

            // Arama Metodu Testi
            MusteriAra(musteriler, "Ayşe");

            // Ekleme Metodu Testi
            Musteri yeniMusteri = new Musteri { Id = 6, Ad = "Zeynep Koç", Eposta = "zeynep@koc.com" };
            MusteriEkle(musteriler, yeniMusteri);

            // Son Durumdaki Müşteri Sayısı
            MusteriSayisiniYazdir(musteriler);

            Proje yeniProje = new Proje
            {
                Id = 1,
                Ad = "E-Ticaret Web Sitesi",
                MusteriId = 1,
                Durum = "Devam Ediyor",
                BaslangicTarihi = DateTime.Now
            };

            Console.WriteLine($"\nOluşturulan Proje: {yeniProje.Ad} ({yeniProje.Durum})");
        }

        // Metotlar

        // Sayma Metodu
        static void MusteriSayisiniYazdir(List<Musteri> liste)
        {
            Console.WriteLine($"\n[BİLGİ] Toplam Müşteri Sayısı: {liste.Count}");
        }

        // Arama Metodu
        static void MusteriAra(List<Musteri> liste, string arananAd)
        {
            Console.WriteLine($"\n[ARAMA] '{arananAd}' için arama yapılıyor...");
            var bulunanlar = liste.FindAll(m => m.Ad.ToLower().Contains(arananAd.ToLower()));
            foreach (var m in bulunanlar)
            {
                Console.WriteLine($"-> Bulundu: ID: {m.Id} | Ad: {m.Ad} | E-posta: {m.Eposta}");
            }
        }

        // Ekleme Metodu
        static void MusteriEkle(List<Musteri> liste, Musteri m)
        {
            liste.Add(m);
            Console.WriteLine($"\n[BAŞARILI] {m.Ad} listeye eklendi!");
        }
    }
}