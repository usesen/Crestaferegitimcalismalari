 namespace VelorusNet8.Domain.Entities.Aggregates.GeneralDefinitions.ValueObjects;

public class Stock
{
    public bool HideInactiveStocks { get; private set; } // Pasif Stoklar Gösterilmesin
    public bool DisableTransactionsForInactiveStocks { get; private set; } // Pasif Stoklarla İşlem Yapılamasın
    public bool SkipQuantityCheckInWarehouseTransfer { get; private set; } // Depo Aktarım İşleminde Depo Miktarları Kontrol Edilmesin
    public bool AllowSameAccountingCodeForDifferentStocks { get; private set; } // Aynı Muhasebe Kodu Farklı Stoklarda Kullanılabilsin

    // Constructor
    public Stock(bool hideInactiveStocks, bool disableTransactionsForInactiveStocks,
                 bool skipQuantityCheckInWarehouseTransfer, bool allowSameAccountingCodeForDifferentStocks)
    {
        HideInactiveStocks = hideInactiveStocks;
        DisableTransactionsForInactiveStocks = disableTransactionsForInactiveStocks;
        SkipQuantityCheckInWarehouseTransfer = skipQuantityCheckInWarehouseTransfer;
        AllowSameAccountingCodeForDifferentStocks = allowSameAccountingCodeForDifferentStocks;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is Stock stock)
        {
            return HideInactiveStocks == stock.HideInactiveStocks &&
                   DisableTransactionsForInactiveStocks == stock.DisableTransactionsForInactiveStocks &&
                   SkipQuantityCheckInWarehouseTransfer == stock.SkipQuantityCheckInWarehouseTransfer &&
                   AllowSameAccountingCodeForDifferentStocks == stock.AllowSameAccountingCodeForDifferentStocks;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        int hash1 = HashCode.Combine(HideInactiveStocks, DisableTransactionsForInactiveStocks);
        int hash2 = HashCode.Combine(SkipQuantityCheckInWarehouseTransfer, AllowSameAccountingCodeForDifferentStocks);

        return HashCode.Combine(hash1, hash2);
    }
}

