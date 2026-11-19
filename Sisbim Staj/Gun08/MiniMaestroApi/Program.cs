var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MusteriDeposunu>();

var app = builder.Build();

app.MapGet("/", () => "Mini Maestro Minimal API çalışıyor!");

// GET: Tüm müşterileri listele
app.MapGet("/musteriler", (MusteriDeposunu depo) =>
{
    return Results.Ok(depo.Musteriler);
});

// GET: ID'ye göre tek müşteri getir
app.MapGet("/musteriler/{id:int}", (int id, MusteriDeposunu depo) =>
{
    var musteri = depo.Musteriler.FirstOrDefault(m => m.Id == id);
    if (musteri is null)
    {
        return Results.NotFound(new { mesaj = $"{id} ID'li müşteri bulunamadı." });
    }

    return Results.Ok(musteri);
});

// POST: Yeni müşteri ekle
app.MapPost("/musteriler", (Musteri yeniMusteri, MusteriDeposunu depo) =>
{
    if (string.IsNullOrWhiteSpace(yeniMusteri.Ad))
    {
        return Results.BadRequest(new { hata = "Müşteri adı boş bırakılamaz." });
    }

    int yeniId = depo.Musteriler.Count > 0 ? depo.Musteriler.Max(m => m.Id) + 1 : 1;
    yeniMusteri.Id = yeniId;
    depo.Musteriler.Add(yeniMusteri);

    return Results.Created($"/musteriler/{yeniMusteri.Id}", yeniMusteri);
});

// PUT: Mevcut müşteriyi güncelle
app.MapPut("/musteriler/{id:int}", (int id, Musteri guncelMusteri, MusteriDeposunu depo) =>
{
    var mevcut = depo.Musteriler.FirstOrDefault(m => m.Id == id);
    if (mevcut is null)
    {
        return Results.NotFound(new { mesaj = $"{id} ID'li müşteri bulunamadı." });
    }

    if (string.IsNullOrWhiteSpace(guncelMusteri.Ad))
    {
        return Results.BadRequest(new { hata = "Müşteri adı boş bırakılamaz." });
    }

    mevcut.Ad = guncelMusteri.Ad.Trim();
    mevcut.Eposta = guncelMusteri.Eposta;

    return Results.Ok(mevcut);
});

// DELETE: Müşteri sil
app.MapDelete("/musteriler/{id:int}", (int id, MusteriDeposunu depo) =>
{
    var mevcut = depo.Musteriler.FirstOrDefault(m => m.Id == id);
    if (mevcut is null)
    {
        return Results.NotFound(new { mesaj = $"{id} ID'li müşteri bulunamadı." });
    }

    depo.Musteriler.Remove(mevcut);
    return Results.Ok(new { mesaj = $"{id} ID'li müşteri silindi." });
});

app.Run();

public class Musteri
{
    public int Id { get; set; }
    public string Ad { get; set; } = string.Empty;
    public string Eposta { get; set; } = string.Empty;
}

public class MusteriDeposunu
{
    public List<Musteri> Musteriler { get; } = new()
    {
        new Musteri { Id = 1, Ad = "Ahmet Yılmaz", Eposta = "ahmet@yilmaz.com" },
        new Musteri { Id = 2, Ad = "Ayşe Demir", Eposta = "ayse@demir.com" },
        new Musteri { Id = 3, Ad = "Mehmet Kaya", Eposta = "mehmet@kaya.com" }
    };
}