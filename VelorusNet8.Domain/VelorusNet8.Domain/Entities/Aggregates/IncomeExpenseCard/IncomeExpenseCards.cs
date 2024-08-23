namespace VelorusNet8.Domain.Entities.Aggregates.IncomeExpenseCard;

public class IncomeExpenseCard
{
    public int Id { get; set; } // Ind (Türkçe: ID)
    public int TypeId { get; set; } // TipInd (Türkçe: Tip ID)
    public string AccountCode { get; set; } // HesapKodu (Türkçe: Hesap Kodu)
    public string AccountName { get; set; } // HesapAdi (Türkçe: Hesap Adı)
    public string SpecialCode { get; set; } // OzelKodu (Türkçe: Özel Kodu)
    public int ContentStatus { get; set; } // MuhteviyatDurumu (Türkçe: Muhteviyat Durumu)
    public int SpecialCodeId { get; set; } // OzelKodInd (Türkçe: Özel Kod ID)
    public string Description { get; set; } // Aciklama (Türkçe: Açıklama)
    public int GroupId { get; set; } // GrupInd (Türkçe: Grup ID)
    public string IncomeExpenseTagsIds { get; set; } // GelirGiderEtiketleriInds (Türkçe: Gelir Gider Etiketleri ID)
    public string AccountingCode { get; set; } // MuhasebeKodu (Türkçe: Muhasebe Kodu)

    // Constructor
    public IncomeExpenseCard(int id, int typeId, string accountCode, string accountName, string specialCode,
                             int contentStatus, int specialCodeId, string description, int groupId,
                             string incomeExpenseTagsIds, string accountingCode)
    {
        Id = id;
        TypeId = typeId;
        AccountCode = accountCode;
        AccountName = accountName;
        SpecialCode = specialCode;
        ContentStatus = contentStatus;
        SpecialCodeId = specialCodeId;
        Description = description;
        GroupId = groupId;
        IncomeExpenseTagsIds = incomeExpenseTagsIds;
        AccountingCode = accountingCode;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is IncomeExpenseCard card)
        {
            return Id == card.Id &&
                   TypeId == card.TypeId &&
                   AccountCode == card.AccountCode &&
                   AccountName == card.AccountName &&
                   SpecialCode == card.SpecialCode &&
                   ContentStatus == card.ContentStatus &&
                   SpecialCodeId == card.SpecialCodeId &&
                   Description == card.Description &&
                   GroupId == card.GroupId &&
                   IncomeExpenseTagsIds == card.IncomeExpenseTagsIds &&
                   AccountingCode == card.AccountingCode;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        int hash1 = HashCode.Combine(Id, TypeId, AccountCode, AccountName, SpecialCode);
        int hash2 = HashCode.Combine(ContentStatus, SpecialCodeId, Description, GroupId, IncomeExpenseTagsIds);
        int hash3 = HashCode.Combine(AccountingCode);

        return HashCode.Combine(hash1, hash2, hash3);
    }
}
