using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Domain.Entities.Common.ValueObjects;

namespace VelorusNet8.Domain.Entities.Aggregates.Customer.Events;

public class AddressChangedEvent
{
    public Address OldAddress { get; }
    public Address NewAddress { get; }

    public AddressChangedEvent(Address oldAddress, Address newAddress)
    {
        OldAddress = oldAddress;
        NewAddress = newAddress;
    }
}