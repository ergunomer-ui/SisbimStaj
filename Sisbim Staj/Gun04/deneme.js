// Müşteri Listesi Tanımlaması
const musteriler = [
    { id: 1, isim: "Ahmet Yılmaz", firma: "Yılmaz Tekstil", aktif: true },
    { id: 2, isim: "Ayşe Demir", firma: "Demir İnşaat", aktif: false },
    { id: 3, isim: "Mehmet Kaya", firma: "Kaya Bilişim", aktif: true },
    { id: 4, isim: "Fatma Şahin", firma: "Şahin Gıda", aktif: false },
    { id: 5, isim: "Ali Çelik", firma: "Çelik Otomotiv", aktif: true }
];

console.log("TÜM MÜŞTERİLER");
console.log(musteriler);


// Aktif Müşterileri Filtreleyen Fonksiyon
function aktifMusteriGetir(liste) {
    return liste.filter(musteri => musteri.aktif === true);
}

console.log("AKTİF MÜŞTERİLER");
console.log(aktifMusteriGetir(musteriler));


// Toplam Müşteri Sayısını Bulan Fonksiyon
function musteriSayisiBul(liste) {
    return liste.length;
}

console.log("TOPLAM MÜŞTERİ SAYISI");
console.log(musteriSayisiBul(musteriler));


// İsme Göre Müşteri Arama Fonksiyonu
function musteriAra(liste, arananKelime) {
    return liste.filter(musteri => 
        musteri.isim.toLowerCase().includes(arananKelime.toLowerCase())
    );
}

console.log("MÜŞTERİ ARAMA SONUCU ('Mehmet')");
console.log(musteriAra(musteriler, "Mehmet"));

// Dört İşlem Fonksiyonu
function topla(sayi1, sayi2) {
    return sayi1 + sayi2;
}

function cikar(sayi1, sayi2) {
    return sayi1 - sayi2;
}

function carp(sayi1, sayi2) {
    return sayi1 * sayi2;
}

function bol(sayi1, sayi2) {
    if (sayi2 === 0) {
        return "Hata:Sıfıra bölünemez";
    }
    return sayi1 / sayi2;
}

console.log("DÖRT İŞLEM TESTLERİ");
console.log("Toplama (10 + 5):", topla(10, 5));
console.log("Çıkarma (10 - 3):", cikar(10, 3));
console.log("Çarpma (4 * 5):", carp(4, 5));
console.log("Bölme (20 / 4):", bol(20, 4));


// Duruma Göre Mesaj
function gorevDurumuMesaji(durum) {
    switch (durum) {
        case "beklemede":
            return "Görev sırasını bekliyor, henüz başlanmadı.";
        case "devam":
            return "Görev şu anda aktif olarak devam ediyor.";
        case "tamamlandi":
            return "Görev başarıyla tamamlandı.";
        default:
            return "Bilinmeyen bir görev durumu.";
    }
}

console.log("DURUM MESAJLARI");
console.log(gorevDurumuMesaji("devam"));
console.log(gorevDurumuMesaji("tamamlandi"));
console.log(gorevDurumuMesaji("beklemede"));