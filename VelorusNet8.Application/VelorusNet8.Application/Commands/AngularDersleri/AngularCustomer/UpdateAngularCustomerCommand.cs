﻿using MediatR;

namespace VelorusNet8.Application.Commands.AngularDersleri.AngularCustomer;

public class UpdateAngularCustomerCommand : IRequest<int>
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
    public bool IsActive { get; set; }
    public decimal Debt { get; set; } = decimal.Zero; //Borç
    public decimal Credit { get; set; } = decimal.Zero; // Alacak
    public decimal BalanceDebt { get; private set; } = decimal.Zero; //borç bakiye
    public decimal BalanceCredit { get; private set; } = decimal.Zero; // alacak bakiye

    public UpdateAngularCustomerCommand(
         int id,
         string? firstName,
         string? lastName,
         string? email,
         string? phone,
         string? address,
         string? city,
         string? country,
         string? postalCode,
         string? company,
         string? position,
         string? notes,
         bool isActive,
         decimal debt,
         decimal credit,
         decimal balanceDebt,
         decimal balanceCredit)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.phone = phone;
        this.address = address;
        this.city = city;
        this.country = country;
        this.postalCode = postalCode;
        this.company = company;
        this.position = position;
        this.notes = notes;
        IsActive = isActive;
        Debt = debt;
        Credit = credit;
        BalanceDebt = balanceDebt;
        BalanceCredit = balanceCredit;
    }
    // Parametresiz constructor ekleyin
    public UpdateAngularCustomerCommand() { }
}
