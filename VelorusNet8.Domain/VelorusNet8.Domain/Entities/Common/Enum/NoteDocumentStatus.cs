namespace VelorusNet8.Domain.Entities.Common.Enum;

public enum NoteDocumentStatus
{
    NewNotes,                // Yeni Senetler
    CollectedNotes,          // Tahsil Edilenler
    EndorsedToCustomer,      // Cariye Ciro Edilenler
    EndorsedToBank,          // Bankaya Ciro Edilenler
    BouncedNotes,            // Karşılıksız Senetler
    PaidNotes,               // Ödemesi Yapılanlar
    ReturnedNotes            // İade Edilen Senetler
}
