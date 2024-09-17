using Microsoft.EntityFrameworkCore;
using VelorusNet8.Domain.Entities.Aggregates.AngularDersleri;

namespace VelorusNet8.Infrastructure.DataSeeding.AngularDersleri;

public static class AngularCustomerSeeder
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AngularCustomer>().HasData(
    new AngularCustomer { id = 1, firstName = "Ahmet", lastName = "Yandan Bakar", email = "ahmet@abc.com", phone = "5328457000", address = "xxx sok no:2 d:15", city = "Tokat", country = "Türkiye", postalCode = "12345", company = "ABC Turizm", position = "Manager", notes = "canavar manager" },
    new AngularCustomer { id = 2, firstName = "Mehmet", lastName = "Yan Güler", email = "mehmet@def.com", phone = "5328457001", address = "yyy sok no:3 d:5", city = "Ankara", country = "Türkiye", postalCode = "54321", company = "DEF Lojistik", position = "Supervisor", notes = "Başarılı supervisor" },
    new AngularCustomer { id = 3, firstName = "Ayşe", lastName = "Gözde Bakar", email = "ayse@ghi.com", phone = "5328457002", address = "zzz sok no:8 d:10", city = "İstanbul", country = "Türkiye", postalCode = "67890", company = "GHI İnşaat", position = "CEO", notes = "Yönetim dehası" },
    new AngularCustomer { id = 4, firstName = "Fatma", lastName = "Yıldız", email = "fatma@jkl.com", phone = "5328457003", address = "aaa sok no:7 d:12", city = "İzmir", country = "Türkiye", postalCode = "11122", company = "JKL Tekstil", position = "HR Manager", notes = "İnsan kaynakları uzmanı" },
    new AngularCustomer { id = 5, firstName = "Ali", lastName = "Öztürk", email = "ali@abc.com", phone = "5328457004", address = "bbb sok no:1 d:16", city = "Bursa", country = "Türkiye", postalCode = "54333", company = "MNO Gıda", position = "Satış Müdürü", notes = "Satış sihirbazı" },
    new AngularCustomer { id = 6, firstName = "Deniz", lastName = "Akdeniz", email = "deniz@def.com", phone = "5328457005", address = "ccc sok no:4 d:18", city = "Antalya", country = "Türkiye", postalCode = "87654", company = "PQR Bilişim", position = "IT Manager", notes = "Teknoloji gurusu" },
    new AngularCustomer { id = 7, firstName = "Berk", lastName = "Kaya", email = "berk@ghi.com", phone = "5328457006", address = "ddd sok no:6 d:20", city = "Kocaeli", country = "Türkiye", postalCode = "23456", company = "STU Otomotiv", position = "Operasyon Müdürü", notes = "Operasyon ustası" },
    new AngularCustomer { id = 8, firstName = "Zeynep", lastName = "Çelik", email = "zeynep@jkl.com", phone = "5328457007", address = "eee sok no:5 d:22", city = "Adana", country = "Türkiye", postalCode = "99887", company = "VWX Kimya", position = "Pazarlama Direktörü", notes = "Pazarlama uzmanı" },
    new AngularCustomer { id = 9, firstName = "Can", lastName = "Demir", email = "can@abc.com", phone = "5328457008", address = "fff sok no:9 d:24", city = "Eskişehir", country = "Türkiye", postalCode = "45567", company = "YZA Medya", position = "Medya Danışmanı", notes = "Medya sihirbazı" },
    new AngularCustomer { id = 10, firstName = "Eda", lastName = "Kırmızı", email = "eda@def.com", phone = "5328457009", address = "ggg sok no:11 d:26", city = "Kayseri", country = "Türkiye", postalCode = "98765", company = "BCD Sigorta", position = "Finansal Danışman", notes = "Finans uzmanı" },
    new AngularCustomer { id = 11, firstName = "Cem", lastName = "Yeşil", email = "cem@ghi.com", phone = "5328457010", address = "hhh sok no:12 d:28", city = "Gaziantep", country = "Türkiye", postalCode = "33221", company = "EFG Turizm", position = "Genel Müdür", notes = "Turizm dehası" },
    new AngularCustomer { id = 12, firstName = "Murat", lastName = "Altın", email = "murat@jkl.com", phone = "5328457011", address = "iii sok no:15 d:30", city = "Trabzon", country = "Türkiye", postalCode = "44122", company = "HIJ Sağlık", position = "Sağlık Direktörü", notes = "Sağlık uzmanı" },
    new AngularCustomer { id = 13, firstName = "Gül", lastName = "Deniz", email = "gul@abc.com", phone = "5328457012", address = "jjj sok no:13 d:32", city = "Muğla", country = "Türkiye", postalCode = "55667", company = "KLM Mühendislik", position = "Baş Mühendis", notes = "Mühendislik sihirbazı" },
    new AngularCustomer { id = 14, firstName = "Selim", lastName = "Toprak", email = "selim@def.com", phone = "5328457013", address = "kkk sok no:17 d:34", city = "Mersin", country = "Türkiye", postalCode = "66543", company = "NOP Emlak", position = "Emlak Danışmanı", notes = "Emlak ustası" },
    new AngularCustomer { id = 15, firstName = "Tuba", lastName = "Aslan", email = "tuba@ghi.com", phone = "5328457014", address = "lll sok no:19 d:36", city = "Samsun", country = "Türkiye", postalCode = "77755", company = "QRS İnşaat", position = "Şantiye Şefi", notes = "Şantiye uzmanı" }
        );
    }
}
