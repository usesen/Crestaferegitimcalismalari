namespace VelorusNet8.Domain.Entities.Aggregates.GeneralDefinitions.ValueObjects;

public class Invoice
{
    public bool IsVATIncludedByDefault { get; private set; } // KDV Dahil Seçeneği İşaretli Gelsin
    public bool IsPreviewPrinted { get; private set; } // Fatura Ön İzlemeli Basılsın (Satış Faturası Girişi)
    public bool IsDiscountAffectingPurchasePrice { get; private set; } // İskonto Alış Fiyatını Etkilesin
    public bool IsInstallationMandatory { get; private set; } // Tesisat Tanımı Zorunlu Olarak Seçilsin (Alış Faturası Girişi)
    public bool UseDateBasedSellingPriceForProfitMargin { get; private set; } // Alış Faturasındaki Kar Marjı için Satış Fiyatını Tarihe Göre Getir
    public bool IsTopDescriptionHiddenInEInvoice { get; private set; } // Faturalardaki Üst Açıklama E-Fatura da Görünmesin
    public int InvoiceRoundingUpperLimit { get; private set; } // Fatura Yuvarlama Tutarı Üst Sınırı
    public int DaysBeforeEntryAllowedForNonCentralBranch { get; private set; } // Merkez Şube Haricinde Alış ve Alış-İade Faturaları 0 Gün Öncesine Kadar Girilemesin

    // Constructor
    public Invoice(bool isVATIncludedByDefault, bool isPreviewPrinted, bool isDiscountAffectingPurchasePrice, bool isInstallationMandatory,
                   bool useDateBasedSellingPriceForProfitMargin, bool isTopDescriptionHiddenInEInvoice,
                   int invoiceRoundingUpperLimit, int daysBeforeEntryAllowedForNonCentralBranch)
    {
        IsVATIncludedByDefault = isVATIncludedByDefault;
        IsPreviewPrinted = isPreviewPrinted;
        IsDiscountAffectingPurchasePrice = isDiscountAffectingPurchasePrice;
        IsInstallationMandatory = isInstallationMandatory;
        UseDateBasedSellingPriceForProfitMargin = useDateBasedSellingPriceForProfitMargin;
        IsTopDescriptionHiddenInEInvoice = isTopDescriptionHiddenInEInvoice;
        InvoiceRoundingUpperLimit = invoiceRoundingUpperLimit;
        DaysBeforeEntryAllowedForNonCentralBranch = daysBeforeEntryAllowedForNonCentralBranch;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is Invoice invoice)
        {
            return IsVATIncludedByDefault == invoice.IsVATIncludedByDefault &&
                   IsPreviewPrinted == invoice.IsPreviewPrinted &&
                   IsDiscountAffectingPurchasePrice == invoice.IsDiscountAffectingPurchasePrice &&
                   IsInstallationMandatory == invoice.IsInstallationMandatory &&
                   UseDateBasedSellingPriceForProfitMargin == invoice.UseDateBasedSellingPriceForProfitMargin &&
                   IsTopDescriptionHiddenInEInvoice == invoice.IsTopDescriptionHiddenInEInvoice &&
                   InvoiceRoundingUpperLimit == invoice.InvoiceRoundingUpperLimit &&
                   DaysBeforeEntryAllowedForNonCentralBranch == invoice.DaysBeforeEntryAllowedForNonCentralBranch;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        return HashCode.Combine(IsVATIncludedByDefault, IsPreviewPrinted, IsDiscountAffectingPurchasePrice,
                                IsInstallationMandatory, UseDateBasedSellingPriceForProfitMargin,
                                IsTopDescriptionHiddenInEInvoice, InvoiceRoundingUpperLimit,
                                DaysBeforeEntryAllowedForNonCentralBranch);
    }
}

