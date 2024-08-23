namespace VelorusNet8.Domain.Entities.Aggregates.GeneralDefinitions.ValueObjects;

public class CashSetting // KasaAyarları
{
    public bool IsLimitedMode { get; private set; } // Sınırlı Çalışma Modu
    public bool IsDescendingOrderByLastTransaction { get; private set; } // Son İşleme Göre Azalan Sıralamalı
    public bool IsFreeMode { get; private set; } // Serbest Çalışma Modu
    public bool IsAscendingOrderByLastTransaction { get; private set; } // Son İşleme Göre Artan Sıralamalı
    public bool WarnOnRepeatedEntriesInDay { get; private set; } // Gün içinde tekrarlanan kasa girişlerinde uyar
    public bool ShowDetailedShiftRecordsInCash { get; private set; } // Vardiya kayıtları kasada detaylı gösterilsin
    public bool AllowIncomeExpenseCardSelectionOnTransactionEntry { get; private set; } // Hareket Girişlerinde Gelir-Gider Kartı Seçimi Yapılabilsin

    // Constructor
    public CashSetting(bool isLimitedMode, bool isDescendingOrderByLastTransaction, bool isFreeMode,
                       bool isAscendingOrderByLastTransaction, bool warnOnRepeatedEntriesInDay,
                       bool showDetailedShiftRecordsInCash, bool allowIncomeExpenseCardSelectionOnTransactionEntry)
    {
        IsLimitedMode = isLimitedMode;
        IsDescendingOrderByLastTransaction = isDescendingOrderByLastTransaction;
        IsFreeMode = isFreeMode;
        IsAscendingOrderByLastTransaction = isAscendingOrderByLastTransaction;
        WarnOnRepeatedEntriesInDay = warnOnRepeatedEntriesInDay;
        ShowDetailedShiftRecordsInCash = showDetailedShiftRecordsInCash;
        AllowIncomeExpenseCardSelectionOnTransactionEntry = allowIncomeExpenseCardSelectionOnTransactionEntry;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is CashSetting setting)
        {
            return IsLimitedMode == setting.IsLimitedMode &&
                   IsDescendingOrderByLastTransaction == setting.IsDescendingOrderByLastTransaction &&
                   IsFreeMode == setting.IsFreeMode &&
                   IsAscendingOrderByLastTransaction == setting.IsAscendingOrderByLastTransaction &&
                   WarnOnRepeatedEntriesInDay == setting.WarnOnRepeatedEntriesInDay &&
                   ShowDetailedShiftRecordsInCash == setting.ShowDetailedShiftRecordsInCash &&
                   AllowIncomeExpenseCardSelectionOnTransactionEntry == setting.AllowIncomeExpenseCardSelectionOnTransactionEntry;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        return HashCode.Combine(IsLimitedMode, IsDescendingOrderByLastTransaction, IsFreeMode,
                                IsAscendingOrderByLastTransaction, WarnOnRepeatedEntriesInDay,
                                ShowDetailedShiftRecordsInCash, AllowIncomeExpenseCardSelectionOnTransactionEntry);
    }
}
