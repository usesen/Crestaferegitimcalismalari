namespace VelorusNet8.Domain.Entities.Common.Enum;

public enum CheckDocumentStatuss
{
    NewChecks,                // Yeni Çekler
    CollectedChecks,          // Tahsil Edilenler
    EndorsedToCustomer,       // Cariye Ciro Edilenler
    EndorsedToBank,           // Bankaya Ciro Edilenler
    BouncedChecks,            // Karşılıksız Çekler
    PaidChecks,               // Ödemesi Yapılanlar
    ReturnedChecks            // İade Edilen Çekler
}