﻿using VelorusNet8.Domain.Entities.Common;

namespace VelorusNet8.Domain.Entities.Aggregates.AngularDersleri;

public  class AngularCustomer: EntityBase
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
    public AngularCustomer(
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
         bool isActive)
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
        this.IsActive = isActive;
    }
    
    // Parametresiz constructor
    public AngularCustomer()
    {
    }
}
