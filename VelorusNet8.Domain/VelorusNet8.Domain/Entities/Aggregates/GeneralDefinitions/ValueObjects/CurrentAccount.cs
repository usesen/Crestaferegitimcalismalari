namespace VelorusNet8.Domain.Entities.Aggregates.GeneralDefinitions.ValueObjects;

public class CurrentAccount
{
    public bool IsAutoAssignCustomerCode { get; private set; } // Cari Kodu Otomatik Verilsin
    public bool HideInactiveCustomers { get; private set; } // Pasif Cariler Gösterilmesin
    public bool DisableTransactionsForInactiveCustomers { get; private set; } // Pasif Carilerde İşlem Yapılamasın
    public bool AllowSameAccountingCodeForDifferentCustomers { get; private set; } // Aynı Muhasebe Kodu Farklı Carilerde Kullanılabilsin
    public bool PreventInvoiceIfBalanceExceedsRiskLimit { get; private set; } // Cari Bakiyesi Risk Limitinden Fazla Ise Irsaliye Kesilemesin
    public bool AllowMultipleSpecialCodesForCustomers { get; private set; } // Cariler Birden Fazla Özel Kod İle Çalışabilsin
    public bool AllowAndOperatorForMultipleSpecialCodes { get; private set; } // Cariler Birden Fazla Özel Kod İle Ve'li Çalışabilsin
    public bool HideOtherBranchTransactions { get; private set; } // Diğer şubelerin hareketleri görünmesin
    public bool ShowCurrencyFieldsInCustomerTransactionReports { get; private set; } // Cari Hareket Dökümünde Döviz Alanları Gösterilsin

    // Constructor
    public CurrentAccount(bool isAutoAssignCustomerCode, bool hideInactiveCustomers, bool disableTransactionsForInactiveCustomers,
                          bool allowSameAccountingCodeForDifferentCustomers, bool preventInvoiceIfBalanceExceedsRiskLimit,
                          bool allowMultipleSpecialCodesForCustomers, bool allowAndOperatorForMultipleSpecialCodes,
                          bool hideOtherBranchTransactions, bool showCurrencyFieldsInCustomerTransactionReports)
    {
        IsAutoAssignCustomerCode = isAutoAssignCustomerCode;
        HideInactiveCustomers = hideInactiveCustomers;
        DisableTransactionsForInactiveCustomers = disableTransactionsForInactiveCustomers;
        AllowSameAccountingCodeForDifferentCustomers = allowSameAccountingCodeForDifferentCustomers;
        PreventInvoiceIfBalanceExceedsRiskLimit = preventInvoiceIfBalanceExceedsRiskLimit;
        AllowMultipleSpecialCodesForCustomers = allowMultipleSpecialCodesForCustomers;
        AllowAndOperatorForMultipleSpecialCodes = allowAndOperatorForMultipleSpecialCodes;
        HideOtherBranchTransactions = hideOtherBranchTransactions;
        ShowCurrencyFieldsInCustomerTransactionReports = showCurrencyFieldsInCustomerTransactionReports;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is CurrentAccount account)
        {
            return IsAutoAssignCustomerCode == account.IsAutoAssignCustomerCode &&
                   HideInactiveCustomers == account.HideInactiveCustomers &&
                   DisableTransactionsForInactiveCustomers == account.DisableTransactionsForInactiveCustomers &&
                   AllowSameAccountingCodeForDifferentCustomers == account.AllowSameAccountingCodeForDifferentCustomers &&
                   PreventInvoiceIfBalanceExceedsRiskLimit == account.PreventInvoiceIfBalanceExceedsRiskLimit &&
                   AllowMultipleSpecialCodesForCustomers == account.AllowMultipleSpecialCodesForCustomers &&
                   AllowAndOperatorForMultipleSpecialCodes == account.AllowAndOperatorForMultipleSpecialCodes &&
                   HideOtherBranchTransactions == account.HideOtherBranchTransactions &&
                   ShowCurrencyFieldsInCustomerTransactionReports == account.ShowCurrencyFieldsInCustomerTransactionReports;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        int hash1 = HashCode.Combine(IsAutoAssignCustomerCode, HideInactiveCustomers, DisableTransactionsForInactiveCustomers);
        int hash2 = HashCode.Combine(AllowSameAccountingCodeForDifferentCustomers, PreventInvoiceIfBalanceExceedsRiskLimit, AllowMultipleSpecialCodesForCustomers);
        int hash3 = HashCode.Combine(AllowAndOperatorForMultipleSpecialCodes, HideOtherBranchTransactions, ShowCurrencyFieldsInCustomerTransactionReports);

        return HashCode.Combine(hash1, hash2, hash3);
    }
}

