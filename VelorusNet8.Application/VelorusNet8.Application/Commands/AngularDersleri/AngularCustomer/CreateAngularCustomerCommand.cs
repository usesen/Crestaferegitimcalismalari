using MediatR;

namespace VelorusNet8.Application.Commands.AngularDersleri.AngularCustomer;

public class CreateAngularCustomerCommand : IRequest<int>
{
    public int id { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? email { get; set; }
    public string? phone { get; set; }
    public string? address { get; set; }
    public string? city { get; set; }
    public string? country { get; set; }
    public string? postalCode { get; set; }
    public string? company { get; set; }
    public string? position { get; set; }
    public string? notes { get; set; }
    public bool IsActive { get; set; } = true;
    public decimal Debt { get; set; } = decimal.Zero; //Borç
    public decimal Credit { get; set; } = decimal.Zero; // Alacak
    public decimal BalanceDebt { get;  set; } = decimal.Zero; //borç bakiye
    public decimal BalanceCredit { get;  set; } = decimal.Zero; // alacak bakiye


    public CreateAngularCustomerCommand(
         int _id,
         string _firstName,
         string _lastName,
         string _email,
         string _phone,
         string _address,
         string _city,
         string _country,
         string _postalCode,
         string _company,
         string _position,
         string _notes,
         bool _isActive,
         decimal debt,
         decimal credit,
         decimal balanceDebt,
         decimal balanceCredit)
    {
        this.id = _id;
        this.firstName = _firstName;
        this.lastName = _lastName;
        this.email = _email;
        this.phone = _phone;
        this.address = _address;
        this.city = _city;
        this.country = _country;
        this.postalCode = _postalCode;
        this.company = _company;
        this.position = _position;
        this.notes = _notes;
        IsActive = _isActive;
        Debt = debt;
        Credit = credit;
        BalanceDebt = balanceDebt;
        BalanceCredit = balanceCredit;
    }
    // Parametresiz constructor ekleyin
    public CreateAngularCustomerCommand () { }
}
