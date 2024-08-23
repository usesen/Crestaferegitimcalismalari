namespace VelorusNet8.Domain.Entities.Aggregates.GeneralDefinitions.ValueObjects;

public class Personnel
{
    public bool CalculateSalaryBasedOnPaymentDate { get; private set; } // Ödemeye Esas Tarihe Göre Maaşı Hesapla
    public bool CanCashierCloseSalesCashRegister { get; private set; } // Kasiyer Satış Kasasını Kapatabilsin

    // Constructor
    public Personnel(bool calculateSalaryBasedOnPaymentDate, bool canCashierCloseSalesCashRegister)
    {
        CalculateSalaryBasedOnPaymentDate = calculateSalaryBasedOnPaymentDate;
        CanCashierCloseSalesCashRegister = canCashierCloseSalesCashRegister;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is Personnel personnel)
        {
            return CalculateSalaryBasedOnPaymentDate == personnel.CalculateSalaryBasedOnPaymentDate &&
                   CanCashierCloseSalesCashRegister == personnel.CanCashierCloseSalesCashRegister;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        return HashCode.Combine(CalculateSalaryBasedOnPaymentDate, CanCashierCloseSalesCashRegister);
    }
}

